using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlockChyp.Client
{
    public class BlockChypClient
    {
        public BlockChypClient() : this(DefaultGatewayEndpoint, DefaultGatewayTestEndpoint, null)
        {
        }

        public BlockChypClient(ApiCredentials credentials) : this(DefaultGatewayEndpoint, DefaultGatewayTestEndpoint, credentials)
        {
        }

        public BlockChypClient(string gateway) : this(gateway, DefaultGatewayTestEndpoint, null)
        {
        }

        public BlockChypClient(string gateway, ApiCredentials credentials) : this(gateway, DefaultGatewayTestEndpoint, credentials)
        {
        }

        public BlockChypClient(string gateway, string testGateway, ApiCredentials credentials)
        {
            GatewayEndpoint = gateway;
            GatewayTestEndpoint = testGateway;
            Credentials = credentials;

            InitializeGatewayClient();
            InitializeTerminalClient();
        }

        public const string OfflineCache = ".blockchyp_routes";
        private const string OfflineFixedKey = "a519bbdedf0d8ce1ae2a8d41e247effbe2e85fa6211e8203cad92307c7a843f2";
        public const string  DefaultGatewayEndpoint = "https://api.blockchyp.com";
        public const string DefaultGatewayTestEndpoint = "https://test.blockchyp.com";
        public const int TerminalHttpPort = 8080;
        public const int TerminalHttpsPort = 8443;

        public string GatewayEndpoint { get; set; }
        public string GatewayTestEndpoint { get; set; }
        public ApiCredentials Credentials { get; set; }

        // TODO logger override
        public bool OfflineRouteCacheEnabled { get; set; } = true;
        public TimeSpan RouteCacheTtl = TimeSpan.FromMinutes(60);
        public bool TerminalHttps { get; set; } = false;

        public string OfflineRouteCacheLocation { get; set; }

        private TimeSpan _requestTimeout = Timeout.InfiniteTimeSpan;
        public TimeSpan RequestTimeout
        {
            get
            {
                return _requestTimeout;
            }

            set
            {
                _gatewayClient.Timeout = value;
                _terminalClient.Timeout = value;
                _requestTimeout = value;
            }
        }

        private HttpClient _gatewayClient;
        private HttpClient _terminalClient;

        private Dictionary<string, TerminalRouteResponse> _routeCache = new Dictionary<string, TerminalRouteResponse>();

        public async Task<HeartbeatResponse> Heartbeat(bool test)
        {
            return await GatewayRequest<HeartbeatResponse>(HttpMethod.Get, "/api/heartbeat", null, null, test);
        }

        public async Task<Acknowledgement> Ping(PingRequest request)
        {
            return await TerminalRequest<Acknowledgement>(HttpMethod.Post, "/api/test", request.TerminalName, request);
        }

        public async Task<AuthResponse> Enroll(AuthRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName))
            {
                return await TerminalRequest<AuthResponse>(HttpMethod.Post, "/api/enroll", request.TerminalName, request);
            } else {
                return await GatewayRequest<AuthResponse>(HttpMethod.Post, "/api/enroll", request, null, request.Test);
            }
        }

        public async Task<AuthResponse> Charge(AuthRequest request)
        {
            PopulateSignatureOptions(request);

            AuthResponse response;
            if (await IsTerminalRouted(request.TerminalName))
            {
                response = await TerminalRequest<AuthResponse>(HttpMethod.Post, "/api/charge", request.TerminalName, request);
            } else {
                response = await GatewayRequest<AuthResponse>(HttpMethod.Post, "/api/charge", request, null, request.Test);
            }

            DumpSignatureFile(request, response);

            return response;
        }

        public async Task<AuthResponse> Reverse(AuthRequest request)
        {
            return await GatewayRequest<AuthResponse>(HttpMethod.Post, "/api/reverse", request, null, request.Test);
        }

        public async Task<AuthResponse> Preauth(AuthRequest request)
        {
            PopulateSignatureOptions(request);

            AuthResponse response;
            if (await IsTerminalRouted(request.TerminalName))
            {
                response = await TerminalRequest<AuthResponse>(HttpMethod.Post, "/api/preauth", request.TerminalName, request);
            } else {
                response = await GatewayRequest<AuthResponse>(HttpMethod.Post, "/api/preauth", request, null, request.Test);
            }

            DumpSignatureFile(request, response);

            return response;
        }

        public async Task<CaptureResponse> Capture(CaptureRequest request)
        {
            return await GatewayRequest<CaptureResponse>(HttpMethod.Post, "/api/capture", request, null, request.Test);
        }

        public async Task<VoidResponse> Void(VoidRequest request)
        {
            return await GatewayRequest<VoidResponse>(HttpMethod.Post, "/api/void", request, null, request.Test);
        }

        public async Task<AuthResponse> Refund(RefundRequest request)
        {
            PopulateSignatureOptions(request);

            if (!String.IsNullOrEmpty(request.TransactionId))
            {
                request.TerminalName = null;
            }

            AuthResponse response;
            if (await IsTerminalRouted(request.TerminalName))
            {
                response = await TerminalRequest<AuthResponse>(HttpMethod.Post, "/api/refund", request.TerminalName, request);
            } else {
                response = await GatewayRequest<AuthResponse>(HttpMethod.Post, "/api/refund", request, null, request.Test);
            }

            DumpSignatureFile(request, response);

            return response;
        }

        public async Task<CloseBatchResponse> CloseBatch(CloseBatchRequest request)
        {
            return await GatewayRequest<CloseBatchResponse>(HttpMethod.Post, "/api/close-batch", request, null, false);
        }

        public async Task<Acknowledgement> Message(MessageRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName))
            {
                return await TerminalRequest<BooleanPromptResponse>(HttpMethod.Post, "/api/message", request.TerminalName, request);
            } else {
                return await GatewayRequest<BooleanPromptResponse>(HttpMethod.Post, "/api/message", request, null, false);
            }
        }

        public async Task<TextPromptResponse> TextPrompt(TextPromptRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName))
            {
                return await TerminalRequest<TextPromptResponse>(HttpMethod.Post, "/api/text-prompt", request.TerminalName, request);
            } else {
                return await GatewayRequest<TextPromptResponse>(HttpMethod.Post, "/api/text-prompt", request, null, false);
            }
        }

        public async Task<BooleanPromptResponse> BooleanPrompt(BooleanPromptRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName))
            {
                return await TerminalRequest<BooleanPromptResponse>(HttpMethod.Post, "/api/boolean-prompt", request.TerminalName, request);
            } else {
                return await GatewayRequest<BooleanPromptResponse>(HttpMethod.Post, "/api/boolean-prompt", request, null, false);
            }
        }

        public async Task<Acknowledgement> NewTransactionDisplay(TransactionDisplayRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName))
            {
                return await TerminalRequest<Acknowledgement>(HttpMethod.Post, "/api/txdisplay", request.TerminalName, request);
            } else {
                return await GatewayRequest<Acknowledgement>(HttpMethod.Post, "/api/terminal-txdisplay", request, null, false);
            }
        }

        public async Task<Acknowledgement> UpdateTransactionDisplay(TransactionDisplayRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName))
            {
                return await TerminalRequest<Acknowledgement>(HttpMethod.Put, "/api/txdisplay", request.TerminalName, request);
            } else {
                return await GatewayRequest<Acknowledgement>(HttpMethod.Put, "/api/terminal-txdisplay", request, null, false);
            }
        }

        public async Task<Acknowledgement> Clear(ClearRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName))
            {
                return await TerminalRequest<Acknowledgement>(HttpMethod.Post, "/api/clear", request.TerminalName, request);
            } else {
                return await GatewayRequest<Acknowledgement>(HttpMethod.Post, "/api/terminal-clear", request, null, false);
            }
        }

        protected ApiCredentials Decrypt(ApiCredentials credentials)
        {
            var key = DeriveOfflineKey();

            return new ApiCredentials(
                Crypto.Decrypt(credentials.ApiKey, key),
                Crypto.Decrypt(credentials.BearerToken, key),
                Crypto.Decrypt(credentials.SigningKey, key));
        }

        protected ApiCredentials Encrypt(ApiCredentials credentials)
        {
            var key = DeriveOfflineKey();

            return new ApiCredentials(
                Crypto.Encrypt(credentials.ApiKey, key),
                Crypto.Encrypt(credentials.BearerToken, key),
                Crypto.Encrypt(credentials.SigningKey, key));
        }

        protected byte[] DeriveOfflineKey()
        {
            using (var sha256 = new SHA256Managed())
            {
                var offlineKeyBytes = Crypto.FromHex(OfflineFixedKey);
                var signingKeyBytes = Crypto.FromHex(Credentials.SigningKey);

                var input = new byte[offlineKeyBytes.Length + signingKeyBytes.Length];
                Buffer.BlockCopy(offlineKeyBytes, 0, input, 0, offlineKeyBytes.Length);
                Buffer.BlockCopy(signingKeyBytes, 0, input, offlineKeyBytes.Length, signingKeyBytes.Length);

                return sha256.ComputeHash(input);
            }
        }

        protected TerminalRouteResponse RouteCacheGet(string name)
        {
            var cacheKey = ToTerminalRouteKey(name);

            if (_routeCache.ContainsKey(cacheKey))
            {
                return _routeCache[cacheKey];
            }

            if (OfflineRouteCacheEnabled)
            {
                var route = GetOfflineCache(name);
                if (route != null) {
                    RouteCachePut(route);

                    return route;
                }
            }

            return null;
        }

        protected void RouteCachePut(TerminalRouteResponse route)
        {
            var cacheKey = ToTerminalRouteKey(route.TerminalName);

            _routeCache[cacheKey] = route;

            if (OfflineRouteCacheEnabled)
            {
                var offlineRoute = (TerminalRouteResponse) route.Clone();
                offlineRoute.TransientCredentials = Encrypt(offlineRoute.TransientCredentials);

                var offlineData = JsonConvert.SerializeObject(offlineRoute);
                var offlineFile = ResolveOfflineRouteCacheLocation(route.TerminalName);

                using (var file = new StreamWriter(offlineFile))
                {
                    file.Write(offlineData);
                }
            }
        }

        protected string ToTerminalRouteKey(string name)
        {
            return Credentials.ApiKey + name;
        }

        protected void DumpSignatureFile(PaymentRequest request, AuthResponse response)
        {
            if (String.IsNullOrEmpty(response.SignatureFile) || String.IsNullOrEmpty(request.SignatureFile))
            {
                return;
            }

            var rawSignature = Crypto.FromHex(response.SignatureFile);

            using (var file = new StreamWriter(request.SignatureFile))
            {
                file.Write(rawSignature);
            }

        }

        protected async Task<TerminalRouteResponse> ResolveTerminalRoute(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return null;
            }

            var cachedRoute = RouteCacheGet(name);
            if (cachedRoute != null && cachedRoute.Timestamp.GetValueOrDefault(default(DateTime)).Add(RouteCacheTtl) < DateTime.UtcNow)
            {
                return cachedRoute;
            }

            var requestedRoute = await GatewayRequest<TerminalRouteResponse>(
                HttpMethod.Get, $"/api/terminal-route", null, $"terminal={name}", false);
            if (requestedRoute != null)
            {
                if (OfflineRouteCacheEnabled)
                {
                    RouteCachePut(requestedRoute);
                }
                return requestedRoute;
            }

            return cachedRoute;
        }

        protected string ToFullyQualifiedTerminalPath(TerminalRouteResponse route, string path)
        {
            var builder = new UriBuilder(route.IpAddress);

            if (TerminalHttps)
            {
                builder.Scheme = Uri.UriSchemeHttps;
                builder.Port = TerminalHttpsPort;
            } else {
                builder.Scheme = Uri.UriSchemeHttp;
                builder.Port = TerminalHttpPort;
            }

            builder.Path = path;

            return builder.ToString();
        }

        protected async Task<bool> IsTerminalRouted(string name)
        {
            var route = await ResolveTerminalRoute(name);

            return (route != null && !route.CloudRelayEnabled);
        }

        protected async Task<T> TerminalRequest<T>(HttpMethod method, string path, string name, object request)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Terminal name must be provided");
            }

            var route = await ResolveTerminalRoute(name);
            // TODO Request timeout?

            if (route == null)
            {
                throw new InvalidOperationException("No route to terminal");
            }

            var requestUrl = ToFullyQualifiedTerminalPath(route, path);

            var terminalRequest = TerminalRequestForRoute(route, request);

            var httpRequest = new HttpRequestMessage(method, requestUrl);
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(terminalRequest), Encoding.UTF8, "application/json");

            using (var response = await _terminalClient.SendAsync(httpRequest))
            {
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                return DeserializeJson<T>(content);
            }
        }

        protected TerminalRequest TerminalRequestForRoute(TerminalRouteResponse route, object request)
        {
            if (route.TransientCredentials != null && !String.IsNullOrEmpty(route.TransientCredentials.ApiKey))
            {
                return new TerminalRequest(route.TransientCredentials, request);
            } else {
                return new TerminalRequest(Credentials, request);
            }
        }

        protected async Task<T> GatewayRequest<T>(HttpMethod method, string path, object body, string query, bool test)
        {
            var requestUrl = ToFullyQualifiedGatewayPath(path, query, test);
            var request = new HttpRequestMessage(method, requestUrl);

            if (body != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            }

            if (Credentials != null)
            {
                var headers = Crypto.GenerateAuthHeaders(Credentials);
                foreach (KeyValuePair<string, string> header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            using (var response = await _gatewayClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                return DeserializeJson<T>(content);
            }
        }

        protected static T DeserializeJson<T>(string content)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (JsonException)
            {
                Console.WriteLine($"JSON deserialization failed: {content}");
                throw;
            }
        }

        protected string ResolveOfflineRouteCacheLocation(string name)
        {
            var snekCase = ToTerminalRouteKey(name).Replace(" ", "_");

            string prefix;
            if (String.IsNullOrEmpty(OfflineRouteCacheLocation))
            {
                var tmp = Path.GetTempPath();
                prefix = Path.Combine(tmp, OfflineCache);
            } else {
                prefix = OfflineRouteCacheLocation;
            }

            return $"{prefix}_{snekCase}";
        }

        protected TerminalRouteResponse GetOfflineCache(string name)
        {
            var cacheFile = ResolveOfflineRouteCacheLocation(name);
            if (!File.Exists(cacheFile))
            {
                return null;
            }

            using (var file = new StreamReader(cacheFile))
            {
                var raw = file.ReadToEnd();
                return DeserializeJson<TerminalRouteResponse>(raw);
            }
        }

        protected string ToFullyQualifiedGatewayPath(string path, string query, bool test)
        {
            var prefix = test ? GatewayEndpoint : GatewayTestEndpoint;

            var builder = new UriBuilder(prefix);
            builder.Path = path;
            builder.Query = query;

            return builder.ToString();
        }

        protected void InitializeGatewayClient()
        {
            _gatewayClient = new HttpClient();
            _gatewayClient.Timeout = RequestTimeout;
            _gatewayClient.DefaultRequestHeaders.Clear();
            _gatewayClient.DefaultRequestHeaders.Accept.Clear();
            _gatewayClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _gatewayClient.DefaultRequestHeaders.Add("User-Agent", "BlockChyp-CSharp/0.1.0"); // TODO Version
        }

        protected void InitializeTerminalClient()
        {
            // TODO lazy load once on first https request

            var certData = new MemoryStream();
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("BlockChyp.Assets.BlockChyp.crt"))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("stream is null");
                }
                stream.CopyTo(certData);
            }

            var cert = new X509Certificate2(certData.ToArray());

            /*
            var clientHandler = new HttpClientHandler();
            clientHandler.ClientCertificates.Add(cert);
            // TODO Can we ignore only histname errors?
            clientHandler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };

            _terminalClient = new HttpClient(clientHandler);
            */
            _terminalClient = new HttpClient();
            _terminalClient.Timeout = RequestTimeout;
        }

        protected void PopulateSignatureOptions(PaymentRequest request)
        {
            if (!String.IsNullOrEmpty(request.SignatureFormat) || String.IsNullOrEmpty(request.SignatureFile))
            {
                return;
            }

            request.SignatureFormat = Path.GetExtension(request.SignatureFile);
        }
    }
}