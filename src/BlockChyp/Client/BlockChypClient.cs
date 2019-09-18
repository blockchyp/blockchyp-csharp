using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlockChyp.Entities;
using Newtonsoft.Json;

namespace BlockChyp.Client
{
    /// <summary>
    /// The main BlockChyp client, used to communicate with the gateway and
    /// terminal APIs.
    /// </summary>
    public class BlockChypClient
    {
        /// <summary>The default URL for the BlockChyp gateway.</summary>
        public const string DefaultGatewayEndpoint = "https://api.blockchyp.com";

        /// <summary>The default URL for the BlockChyp test gateway.</summary>
        public const string DefaultGatewayTestEndpoint = "https://test.blockchyp.com";

        /// <summary>The default HTTP port used by BlockChyp terminals.</summary>
        public const int TerminalHttpPort = 8080;

        /// <summary>The default HTTPS port used by BlockChyp terminals.</summary>
        public const int TerminalHttpsPort = 8443;

        private static readonly HttpClient GatewayClient = NewHttpClient();

        private static readonly HttpClient TerminalClient = NewTerminalHttpClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChypClient"/> class.
        /// </summary>
        public BlockChypClient()
            : this(DefaultGatewayEndpoint, DefaultGatewayTestEndpoint, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChypClient"/> class.
        /// </summary>
        /// <param name="credentials">API credentials used to make requests.</param>
        public BlockChypClient(ApiCredentials credentials)
            : this(DefaultGatewayEndpoint, DefaultGatewayTestEndpoint, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChypClient"/> class.
        /// </summary>
        /// <param name="gateway">A URL for the BlockChyp gateway.</param>
        public BlockChypClient(string gateway)
            : this(gateway, DefaultGatewayTestEndpoint, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChypClient"/> class.
        /// </summary>
        /// <param name="gateway">A URL for the BlockChyp gateway.</param>
        /// <param name="credentials">API credentials used to make requests.</param>
        public BlockChypClient(string gateway, ApiCredentials credentials)
            : this(gateway, DefaultGatewayTestEndpoint, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChypClient"/> class.
        /// </summary>
        /// <param name="gateway">A URL for the BlockChyp gateway.</param>
        /// <param name="testGateway">A URL for the BlockChyp test gateway.</param>
        /// <param name="credentials">API credentials used to make requests.</param>
        public BlockChypClient(string gateway, string testGateway, ApiCredentials credentials)
        {
            GatewayEndpoint = gateway;
            GatewayTestEndpoint = testGateway;
            Credentials = credentials;

#if NET45
            // net45 does not use TLS 1.2 unless you tell it to.
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol |
                SecurityProtocolType.Tls12;
#endif
        }

        /// <summary>Gets or sets the gateway base URL.</summary>
        /// <value>The base URL for the BlockChyp gateway.</value>
        public string GatewayEndpoint { get; set; }

        /// <summary>Gets or sets the test gateway base URL.</summary>
        /// <value>The base URL for the BlockChyp test gateway.</value>
        public string GatewayTestEndpoint { get; set; }

        /// <summary>Gets or sets the API credentials used for requests.</summary>
        /// <value>The API credentials used for requests.</value>
        public ApiCredentials Credentials { get; set; }

        /// <summary>Enables or disables TLS encrypted communication with terminals.</summary>
        /// <value>The state of terminal TLS encryption.</value>
        public bool TerminalHttps { get; set; } = false;

        /// <summary>Gets or sets the location of the persistent terminal route cache.</summary>
        /// <value>The location of the persistent terminal route cache.</value>
        public TerminalRouteCache RouteCache { get; set; } = new TerminalRouteCache();

        /// <summary>
        /// Gets or sets the HTTP timeout used for requests to the gateway.
        /// </summary>
        /// <value>The HTTP timeout used for requests to the gateway.</value>
        public TimeSpan GatewayRequestTimeout { get; set; } = Timeout.InfiniteTimeSpan;

        /// <summary>
        /// Gets or sets the HTTP timeout used for requests to terminals.
        /// </summary>
        /// <value>The HTTP timeout used for requests to terminals.</value>
        public TimeSpan TerminalRequestTimeout { get; set; } = Timeout.InfiniteTimeSpan;

        /// <summary>
        /// Tests communication with the Gateway as an asynchronous operation.
        /// If authentication is successful, a merchantPk value is returned.
        /// </summary>
        /// <param name="test">Whether or not to route the the transaction to the test gateway.</param>
        public async Task<HeartbeatResponse> HeartbeatAsync(bool test)
        {
            return await GatewayRequestAsync<HeartbeatResponse>(HttpMethod.Get, "/api/heartbeat", null, null, test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="HeartbeatAsync"/>.
        /// </summary>
        /// <param name="test">Whether or not to route the the transaction to the test gateway.</param>
        public HeartbeatResponse Heartbeat(bool test)
        {
            return GatewayRequest<HeartbeatResponse>(HttpMethod.Get, "/api/heartbeat", null, null, test);
        }

        /// <summary>
        /// Tests local communication with a terminal as an asynchronous operation.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> PingAsync(PingRequest request)
        {
            return await TerminalRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/test", request.TerminalName, request)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="PingAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement Ping(PingRequest request)
        {
            return TerminalRequest<Acknowledgement>(HttpMethod.Post, "/api/test", request.TerminalName, request);
        }

        /// <summary>
        /// Enrolls the payment method in the recurring payment token vault
        /// as an asynchronous operation. Any amounts passed in are ignored.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<AuthResponse> EnrollAsync(AuthRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                return await TerminalRequestAsync<AuthResponse>(HttpMethod.Post, "/api/enroll", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                return await GatewayRequestAsync<AuthResponse>(HttpMethod.Post, "/api/enroll", request, null, request.Test)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Synchronous form of <see cref="EnrollAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public AuthResponse Enroll(AuthRequest request)
        {
            return EnrollAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs a standard auth and capture as an asynchronous operation.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<AuthResponse> ChargeAsync(AuthRequest request)
        {
            PopulateSignatureOptions(request);

            AuthResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<AuthResponse>(HttpMethod.Post, "/api/charge", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<AuthResponse>(HttpMethod.Post, "/api/charge", request, null, request.Test)
                    .ConfigureAwait(false);
            }

            DumpSignatureFile(request, response);

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="ChargeAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public AuthResponse Charge(AuthRequest request)
        {
            return ChargeAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Executes a time out reversal as an asynchronous operation. This
        /// is an idempotent operation. You should perform a reversal in
        /// situations where your request for authorization times out or gives
        /// an ambiguous result. Reversal must be completed within 2 minutes of
        /// the original auth. To use this method, a unique transactionRef must
        /// be provided at authorization time. That transactionRef can then be
        /// used to reverse the transaction.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<AuthResponse> ReverseAsync(AuthRequest request)
        {
            return await GatewayRequestAsync<AuthResponse>(HttpMethod.Post, "/api/reverse", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="ReverseAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public AuthResponse Reverse(AuthRequest request)
        {
            return GatewayRequest<AuthResponse>(HttpMethod.Post, "/api/reverse", request, null, request.Test);
        }

        /// <summary>
        /// Preauthorizes a transaction for capture at a later time as an
        /// asynchronous operation.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<AuthResponse> PreauthAsync(AuthRequest request)
        {
            PopulateSignatureOptions(request);

            AuthResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<AuthResponse>(HttpMethod.Post, "/api/preauth", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<AuthResponse>(HttpMethod.Post, "/api/preauth", request, null, request.Test)
                    .ConfigureAwait(false);
            }

            DumpSignatureFile(request, response);

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="PreauthAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public AuthResponse Preauth(AuthRequest request)
        {
            return PreauthAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>Captures a preauth as an asynchronous operation.</summary>
        /// <param name="request">The request details.</param>
        public async Task<CaptureResponse> CaptureAsync(CaptureRequest request)
        {
            return await GatewayRequestAsync<CaptureResponse>(HttpMethod.Post, "/api/capture", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="CaptureAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public CaptureResponse Capture(CaptureRequest request)
        {
            return GatewayRequest<CaptureResponse>(HttpMethod.Post, "/api/capture", request, null, request.Test);
        }

        /// <summary>Voids an existing transaction as an asynchronous operation.</summary>
        /// <param name="request">The request details.</param>
        public async Task<VoidResponse> VoidAsync(VoidRequest request)
        {
            return await GatewayRequestAsync<VoidResponse>(HttpMethod.Post, "/api/void", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="VoidAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public VoidResponse Void(VoidRequest request)
        {
            return GatewayRequest<VoidResponse>(HttpMethod.Post, "/api/void", request, null, request.Test);
        }

        /// <summary>
        /// Initiates a refund transaction as an asynchronous operation.
        /// You can perform a full or partial refund by referencing a previous
        /// transaction. You can also do a free range refund without
        /// referencing a previous transaction, but please, pretty please,
        /// don't do this. Basing a refund on a previous transaction
        /// eliminates a lot of potential fraud.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<AuthResponse> RefundAsync(RefundRequest request)
        {
            PopulateSignatureOptions(request);

            if (!string.IsNullOrEmpty(request.TransactionId))
            {
                request.TerminalName = null;
            }

            AuthResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<AuthResponse>(HttpMethod.Post, "/api/refund", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<AuthResponse>(HttpMethod.Post, "/api/refund", request, null, request.Test)
                    .ConfigureAwait(false);
            }

            DumpSignatureFile(request, response);

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="Refund"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public AuthResponse Refund(RefundRequest request)
        {
            return RefundAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Executes a manual batch close. as an asynchronous operation By default,
        /// the BlockChyp gateway will close batches at 3 AM in the merchant's local
        /// time zone. You can turn this off and run batches manually if you want.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<CloseBatchResponse> CloseBatchAsync(CloseBatchRequest request)
        {
            return await GatewayRequestAsync<CloseBatchResponse>(HttpMethod.Post, "/api/close-batch", request, null, false)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="CloseBatchAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public CloseBatchResponse CloseBatch(CloseBatchRequest request)
        {
            return GatewayRequest<CloseBatchResponse>(HttpMethod.Post, "/api/close-batch", request, null, false);
        }

        /// <summary>Displays a message on the terminal screen as an asynchronous operation.</summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> MessageAsync(MessageRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                return await TerminalRequestAsync<BooleanPromptResponse>(HttpMethod.Post, "/api/message", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                return await GatewayRequestAsync<BooleanPromptResponse>(HttpMethod.Post, "/api/message", request, null, false)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Synchronous form of <see cref="MessageAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement Message(MessageRequest request)
        {
            return MessageAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Captures text input from the user as an asynchronous operation.
        /// This can be used for things like email addresses, phone numbers,
        /// and loyalty program numbers. You have to specify a promptType in
        /// the request, since free form prompt text is not permitted by
        /// PCI rules.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TextPromptResponse> TextPromptAsync(TextPromptRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                return await TerminalRequestAsync<TextPromptResponse>(HttpMethod.Post, "/api/text-prompt", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                return await GatewayRequestAsync<TextPromptResponse>(HttpMethod.Post, "/api/text-prompt", request, null, false)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Synchronous form of <see cref="TextPromptAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TextPromptResponse TextPrompt(TextPromptRequest request)
        {
            return TextPromptAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Asks the user a yes or no question as an asynchronous operation.
        /// You can use this for things like suggestive selling. You can also
        /// use this for surveys, but BlockChyp does have a built in survey
        /// feature that merchants can use with no custom code required.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<BooleanPromptResponse> BooleanPromptAsync(BooleanPromptRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                return await TerminalRequestAsync<BooleanPromptResponse>(HttpMethod.Post, "/api/boolean-prompt", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                return await GatewayRequestAsync<BooleanPromptResponse>(HttpMethod.Post, "/api/boolean-prompt", request, null, false)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Synchronous form of <see cref="BooleanPromptAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public BooleanPromptResponse BooleanPrompt(BooleanPromptRequest request)
        {
            return BooleanPromptAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Resets the line item display with a new transaction
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> NewTransactionDisplayAsync(TransactionDisplayRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                return await TerminalRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/txdisplay", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                return await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/terminal-txdisplay", request, null, false)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Synchronous form of <see cref="NewTransactionDisplayAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement NewTransactionDisplay(TransactionDisplayRequest request)
        {
            return NewTransactionDisplayAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Adds to an existing line item display as an asynchronous operation.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> UpdateTransactionDisplayAsync(TransactionDisplayRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                return await TerminalRequestAsync<Acknowledgement>(HttpMethod.Put, "/api/txdisplay", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                return await GatewayRequestAsync<Acknowledgement>(HttpMethod.Put, "/api/terminal-txdisplay", request, null, false)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Synchronous form of <see cref="UpdateTransactionDisplayAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement UpdateTransactionDisplay(TransactionDisplayRequest request)
        {
            return UpdateTransactionDisplayAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Clears the line item display and returns the terminal to idle
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> ClearAsync(ClearRequest request)
        {
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                return await TerminalRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/clear", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                return await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/terminal-clear", request, null, false)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Synchronous form of <see cref="ClearAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement Clear(ClearRequest request)
        {
            return ClearAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends a request to a terminal and returns its response
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="path">The relative path of the request.</param>
        /// <param name="name">The name of the target terminal.</param>
        /// <param name="body">The request body.</param>
        /// <typeparam name="T">The expected response entity.</typeparam>
        /// <exception cref="TimeoutException">if HTTP request time exceeds <c>TerminalRequestTimeout</c>.</exception>
        public async Task<T> TerminalRequestAsync<T>(HttpMethod method, string path, string name, object body)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Terminal name must be provided");
            }

            var route = await ResolveTerminalRoute(name).ConfigureAwait(false);

            if (route == null || !route.Success)
            {
                throw new BlockChypException($"No route to terminal: {name}");
            }

            var requestUrl = ToFullyQualifiedTerminalPath(route, path);

            var terminalRequest = TerminalRequestForRoute(route, body);

            var httpRequest = new HttpRequestMessage(method, requestUrl);
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(terminalRequest), Encoding.UTF8, "application/json");

            var cts = new CancellationTokenSource();
            cts.CancelAfter(TerminalRequestTimeout);

            try
            {
                using (var response = await TerminalClient.SendAsync(httpRequest, cts.Token).ConfigureAwait(false))
                {
                    string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return ProcessResponse<T>(response.StatusCode, responseBody);
                }
            }
            catch (TaskCanceledException e)
            {
                throw new TimeoutException("Terminal request timed out", e);
            }
        }

        /// <summary>
        /// Sends a request to a terminal and blocks until it responds.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="path">The relative path of the request.</param>
        /// <param name="name">The name of the target terminal.</param>
        /// <param name="body">The request body.</param>
        /// <typeparam name="T">The expected response entity.</typeparam>
        public T TerminalRequest<T>(HttpMethod method, string path, string name, object body)
        {
            return TerminalRequestAsync<T>(method, path, name, body)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends a request to the gateway and returns its response
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="path">The relative path of the request.</param>
        /// <param name="body">The request body.</param>
        /// <param name="query">A URL query string to send with the request.</param>
        /// <param name="test">Whether or not to route the request to the test gateway.</param>
        /// <typeparam name="T">The expected response entity.</typeparam>
        /// <exception cref="TimeoutException">if HTTP request time exceeds <c>GatewayRequestTimeout</c>.</exception>
        public async Task<T> GatewayRequestAsync<T>(HttpMethod method, string path, object body, string query, bool test)
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

            var cts = new CancellationTokenSource();
            cts.CancelAfter(GatewayRequestTimeout);

            try
            {
                using (var response = await GatewayClient.SendAsync(request, cts.Token).ConfigureAwait(false))
                {
                        string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        return ProcessResponse<T>(response.StatusCode, responseBody);
                }
            }
            catch (TaskCanceledException e)
            {
                throw new TimeoutException("Gateway request timed out", e);
            }
        }

        /// <summary>
        /// Sends a request to the gateway and blocks until it response.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="path">The relative path of the request.</param>
        /// <param name="body">The request body.</param>
        /// <param name="query">A URL query string to send with the request.</param>
        /// <param name="test">Whether or not to route the request to the test gateway.</param>
        /// <typeparam name="T">The expected response entity.</typeparam>
        public T GatewayRequest<T>(HttpMethod method, string path, object body, string query, bool test)
        {
            return GatewayRequestAsync<T>(method, path, body, query, test)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private static T ProcessResponse<T>(HttpStatusCode statusCode, string body)
        {
            if (statusCode != HttpStatusCode.OK)
            {
                try
                {
                    var core = JsonConvert.DeserializeObject<CoreResponse>(body);

                    string msg;
                    if (string.IsNullOrEmpty(core.ResponseDescription))
                    {
                        msg = $"HTTP {statusCode}: \"{body}\"";
                    }
                    else
                    {
                        msg = core.ResponseDescription;
                    }

                    throw new BlockChypException(
                        msg,
                        statusCode,
                        body);
                }
                catch (JsonException)
                {
                        throw new BlockChypException(
                            $"HTTP {statusCode}: \"{body}\"",
                            statusCode,
                            body);
                }
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(body);
            }
            catch (JsonException)
            {
                throw new BlockChypException(
                    $"Invalid response: \"{body}\"",
                    statusCode,
                    body);
            }
        }

        private static HttpClient NewHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.Timeout = Timeout.InfiniteTimeSpan;

            httpClient.DefaultRequestHeaders.Clear();
            var userAgent = AssembleUserAgent();
            httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);

            return httpClient;
        }

        private static HttpClient NewTerminalHttpClient()
        {
#if NET45
            ServicePointManager
                .ServerCertificateValidationCallback += Crypto.ValidateTerminalCertificate;

            var httpClient = NewHttpClient();
#else
            var clientHandler = new HttpClientHandler();
            clientHandler
                .ServerCertificateCustomValidationCallback += Crypto.ValidateTerminalCertificate;

            var httpClient = new HttpClient(clientHandler);
#endif

            httpClient.Timeout = Timeout.InfiniteTimeSpan;

            httpClient.DefaultRequestHeaders.Clear();
            var userAgent = AssembleUserAgent();
            httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);

            return httpClient;
        }

        private static string AssembleUserAgent()
        {
            var version = new AssemblyName(typeof(BlockChypClient).GetTypeInfo().Assembly.FullName).Version.ToString(3);
            return $"BlockChyp-CSharp/{version}";
        }

        private static void PopulateSignatureOptions(PaymentRequest request)
        {
            if (string.IsNullOrEmpty(request.SignatureFile) || request.SignatureFormat != SignatureFormat.None)
            {
                return;
            }

            string[] elements = request.SignatureFile.Split('.');

            request.SignatureFormat = (SignatureFormat)Enum
                .Parse(typeof(SignatureFormat), elements[elements.Length - 1], true);
        }

        private static void DumpSignatureFile(PaymentRequest request, AuthResponse response)
        {
            if (string.IsNullOrEmpty(response.SignatureFile) || string.IsNullOrEmpty(request.SignatureFile))
            {
                return;
            }

            var rawSignature = Crypto.FromHex(response.SignatureFile);

            File.WriteAllBytes(request.SignatureFile, rawSignature);
        }

        private async Task<TerminalRouteResponse> ResolveTerminalRoute(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            var cachedRoute = RouteCache.Get(name, Credentials);
            if (cachedRoute != null)
            {
                return cachedRoute;
            }

            var requestedRoute = await GatewayRequestAsync<TerminalRouteResponse>(
                HttpMethod.Get, $"/api/terminal-route", null, $"terminal={name}", false)
                    .ConfigureAwait(false);

            if (requestedRoute != null && requestedRoute.Success)
            {
                requestedRoute.Timestamp = DateTime.UtcNow;

                if (RouteCache.OfflineEnabled)
                {
                    RouteCache.Put(requestedRoute, Credentials);
                }

                return requestedRoute;
            }

            return cachedRoute;
        }

        private Uri ToFullyQualifiedTerminalPath(TerminalRouteResponse route, string path)
        {
            if (TerminalHttps)
            {
                return new UriBuilder(
                    Uri.UriSchemeHttps,
                    route.IpAddress,
                    TerminalHttpsPort,
                    path).Uri;
            }
            else
            {
                return new UriBuilder(
                    Uri.UriSchemeHttp,
                    route.IpAddress,
                    TerminalHttpPort,
                    path).Uri;
            }
        }

        private async Task<bool> IsTerminalRouted(string name)
        {
            var route = await ResolveTerminalRoute(name).ConfigureAwait(false);

            return route != null && route.Success && !route.CloudRelayEnabled;
        }

        private TerminalRequest TerminalRequestForRoute(TerminalRouteResponse route, object request)
        {
            if (route.TransientCredentials != null && !string.IsNullOrEmpty(route.TransientCredentials.ApiKey))
            {
                return new TerminalRequest(route.TransientCredentials, request);
            }
            else
            {
                return new TerminalRequest(Credentials, request);
            }
        }

        private Uri ToFullyQualifiedGatewayPath(string path, string query, bool test)
        {
            var prefix = test ? GatewayEndpoint : GatewayTestEndpoint;

            var builder = new UriBuilder(prefix);
            builder.Path = path;
            builder.Query = query;

            return builder.Uri;
        }
    }
}
