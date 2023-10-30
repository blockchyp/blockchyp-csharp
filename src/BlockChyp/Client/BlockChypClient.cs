// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

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

        /// <summary>The default URL for the BlockChyp dashboard.</summary>
        public const string DefaultDashboardEndpoint = "https://dashboard.blockchyp.com";

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
            : this(DefaultGatewayEndpoint, DefaultGatewayTestEndpoint, DefaultDashboardEndpoint, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChypClient"/> class.
        /// </summary>
        /// <param name="credentials">API credentials used to make requests.</param>
        public BlockChypClient(ApiCredentials credentials)
            : this(DefaultGatewayEndpoint, DefaultGatewayTestEndpoint, DefaultDashboardEndpoint, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChypClient"/> class.
        /// </summary>
        /// <param name="gateway">A URL for the BlockChyp gateway.</param>
        public BlockChypClient(string gateway)
            : this(gateway, DefaultGatewayTestEndpoint, DefaultDashboardEndpoint, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChypClient"/> class.
        /// </summary>
        /// <param name="gateway">A URL for the BlockChyp gateway.</param>
        /// <param name="credentials">API credentials used to make requests.</param>
        public BlockChypClient(string gateway, ApiCredentials credentials)
            : this(gateway, DefaultGatewayTestEndpoint, DefaultDashboardEndpoint, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChypClient"/> class.
        /// </summary>
        /// <param name="gateway">A URL for the BlockChyp gateway.</param>
        /// <param name="testGateway">A URL for the BlockChyp test gateway.</param>
        /// <param name="dashboardGateway">A URL for the BlockChyp dashboard gateway.</param>
        /// <param name="credentials">API credentials used to make requests.</param>
        public BlockChypClient(string gateway, string testGateway, string dashboardGateway, ApiCredentials credentials)
        {
            GatewayEndpoint = gateway;
            GatewayTestEndpoint = testGateway;
            DashboardEndpoint = dashboardGateway;
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

        /// <summary>Gets or sets the dashboard base URL.</summary>
        /// <value>The base URL for the BlockChyp dashboard.</value>
        public string DashboardEndpoint { get; set; }

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
        public TimeSpan GatewayRequestTimeout { get; set; } = TimeSpan.FromSeconds(20);

        /// <summary>
        /// Gets or sets the HTTP timeout used for requests to terminals.
        /// </summary>
        /// <value>The HTTP timeout used for requests to terminals.</value>
        public TimeSpan TerminalRequestTimeout { get; set; } = TimeSpan.FromSeconds(120);

        /// <summary>
        /// Tests connectivity with a payment terminal.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<PingResponse> PingAsync(PingRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            PingResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<PingResponse>(HttpMethod.Post, "/api/test", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<PingResponse>(HttpMethod.Post, "/api/terminal-test", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="PingAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public PingResponse Ping(PingRequest request)
        {
            return PingAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Executes a standard direct preauth and capture.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<AuthorizationResponse> ChargeAsync(AuthorizationRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            AuthorizationResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/charge", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/charge", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="ChargeAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public AuthorizationResponse Charge(AuthorizationRequest request)
        {
            return ChargeAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Executes a preauthorization intended to be captured later.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<AuthorizationResponse> PreauthAsync(AuthorizationRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            AuthorizationResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/preauth", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/preauth", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="PreauthAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public AuthorizationResponse Preauth(AuthorizationRequest request)
        {
            return PreauthAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Executes a refund.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<AuthorizationResponse> RefundAsync(RefundRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            AuthorizationResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/refund", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/refund", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="RefundAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public AuthorizationResponse Refund(RefundRequest request)
        {
            return RefundAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Adds a new payment method to the token vault.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<EnrollResponse> EnrollAsync(EnrollRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            EnrollResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<EnrollResponse>(HttpMethod.Post, "/api/enroll", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<EnrollResponse>(HttpMethod.Post, "/api/enroll", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="EnrollAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public EnrollResponse Enroll(EnrollRequest request)
        {
            return EnrollAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Activates or recharges a gift card.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<GiftActivateResponse> GiftActivateAsync(GiftActivateRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            GiftActivateResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<GiftActivateResponse>(HttpMethod.Post, "/api/gift-activate", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<GiftActivateResponse>(HttpMethod.Post, "/api/gift-activate", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="GiftActivateAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public GiftActivateResponse GiftActivate(GiftActivateRequest request)
        {
            return GiftActivateAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Checks the remaining balance on a payment method.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<BalanceResponse> BalanceAsync(BalanceRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            BalanceResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<BalanceResponse>(HttpMethod.Post, "/api/balance", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<BalanceResponse>(HttpMethod.Post, "/api/balance", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="BalanceAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public BalanceResponse Balance(BalanceRequest request)
        {
            return BalanceAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Clears the line item display and any in progress transaction.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> ClearAsync(ClearTerminalRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            Acknowledgement response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/clear", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/terminal-clear", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="ClearAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement Clear(ClearTerminalRequest request)
        {
            return ClearAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns the current status of a terminal.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TerminalStatusResponse> TerminalStatusAsync(TerminalStatusRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            TerminalStatusResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<TerminalStatusResponse>(HttpMethod.Post, "/api/terminal-status", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<TerminalStatusResponse>(HttpMethod.Post, "/api/terminal-status", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="TerminalStatusAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TerminalStatusResponse TerminalStatus(TerminalStatusRequest request)
        {
            return TerminalStatusAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Prompts the user to accept terms and conditions.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TermsAndConditionsResponse> TermsAndConditionsAsync(TermsAndConditionsRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            TermsAndConditionsResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<TermsAndConditionsResponse>(HttpMethod.Post, "/api/tc", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<TermsAndConditionsResponse>(HttpMethod.Post, "/api/terminal-tc", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="TermsAndConditionsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TermsAndConditionsResponse TermsAndConditions(TermsAndConditionsRequest request)
        {
            return TermsAndConditionsAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Captures and returns a signature.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<CaptureSignatureResponse> CaptureSignatureAsync(CaptureSignatureRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            CaptureSignatureResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<CaptureSignatureResponse>(HttpMethod.Post, "/api/capture-signature", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<CaptureSignatureResponse>(HttpMethod.Post, "/api/capture-signature", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="CaptureSignatureAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public CaptureSignatureResponse CaptureSignature(CaptureSignatureRequest request)
        {
            return CaptureSignatureAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Displays a new transaction on the terminal.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> NewTransactionDisplayAsync(TransactionDisplayRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            Acknowledgement response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/txdisplay", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/terminal-txdisplay", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
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
        /// Appends items to an existing transaction display. Subtotal, Tax, and Total are
        /// overwritten by the request. Items with the same description are combined into
        /// groups.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> UpdateTransactionDisplayAsync(TransactionDisplayRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            Acknowledgement response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<Acknowledgement>(HttpMethod.Put, "/api/txdisplay", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<Acknowledgement>(HttpMethod.Put, "/api/terminal-txdisplay", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
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
        /// Displays a short message on the terminal.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> MessageAsync(MessageRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            Acknowledgement response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/message", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/message", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
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
        /// Asks the consumer a yes/no question.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<BooleanPromptResponse> BooleanPromptAsync(BooleanPromptRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            BooleanPromptResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<BooleanPromptResponse>(HttpMethod.Post, "/api/boolean-prompt", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<BooleanPromptResponse>(HttpMethod.Post, "/api/boolean-prompt", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
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
        /// Asks the consumer a text based question.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TextPromptResponse> TextPromptAsync(TextPromptRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            TextPromptResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<TextPromptResponse>(HttpMethod.Post, "/api/text-prompt", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<TextPromptResponse>(HttpMethod.Post, "/api/text-prompt", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
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
        /// Returns a list of queued transactions on a terminal.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<ListQueuedTransactionsResponse> ListQueuedTransactionsAsync(ListQueuedTransactionsRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            ListQueuedTransactionsResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<ListQueuedTransactionsResponse>(HttpMethod.Post, "/api/queue/list", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<ListQueuedTransactionsResponse>(HttpMethod.Post, "/api/queue/list", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="ListQueuedTransactionsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public ListQueuedTransactionsResponse ListQueuedTransactions(ListQueuedTransactionsRequest request)
        {
            return ListQueuedTransactionsAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes a queued transaction from the terminal.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<DeleteQueuedTransactionResponse> DeleteQueuedTransactionAsync(DeleteQueuedTransactionRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            DeleteQueuedTransactionResponse response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<DeleteQueuedTransactionResponse>(HttpMethod.Post, "/api/queue/delete", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<DeleteQueuedTransactionResponse>(HttpMethod.Post, "/api/queue/delete", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="DeleteQueuedTransactionAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public DeleteQueuedTransactionResponse DeleteQueuedTransaction(DeleteQueuedTransactionRequest request)
        {
            return DeleteQueuedTransactionAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Reboot a payment terminal.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> RebootAsync(PingRequest request)
        {
            ISignatureRequest signatureRequest = request as ISignatureRequest;
            if (signatureRequest != null)
            {
                PopulateSignatureOptions(signatureRequest);
            }

            Acknowledgement response;
            if (await IsTerminalRouted(request.TerminalName).ConfigureAwait(false))
            {
                response = await TerminalRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/reboot", request.TerminalName, request)
                    .ConfigureAwait(false);
            }
            else
            {
                response = await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/terminal-reboot", request, null, request.Test, relay: true)
                    .ConfigureAwait(false);
            }

            ISignatureResponse signatureResponse = response as ISignatureResponse;
            if (signatureRequest != null && signatureResponse != null)
            {
                DumpSignatureFile(signatureRequest, signatureResponse);
            }

            return response;
        }

        /// <summary>
        /// Synchronous form of <see cref="RebootAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement Reboot(PingRequest request)
        {
            return RebootAsync(request)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Adds a test merchant account.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<GetMerchantsResponse> GetMerchantsAsync(GetMerchantsRequest request)
        {
            return await DashboardRequestAsync<GetMerchantsResponse>(HttpMethod.Post, "/api/get-merchants", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="GetMerchantsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public GetMerchantsResponse GetMerchants(GetMerchantsRequest request)
        {
            return DashboardRequest<GetMerchantsResponse>(HttpMethod.Post, "/api/get-merchants", request, null);
        }

        /// <summary>
        /// Adds or updates a merchant account. Can be used to create or update test
        /// merchants. Only gateway partners may create new live merchants.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<MerchantProfileResponse> UpdateMerchantAsync(MerchantProfile request)
        {
            return await DashboardRequestAsync<MerchantProfileResponse>(HttpMethod.Post, "/api/update-merchant", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="UpdateMerchantAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public MerchantProfileResponse UpdateMerchant(MerchantProfile request)
        {
            return DashboardRequest<MerchantProfileResponse>(HttpMethod.Post, "/api/update-merchant", request, null);
        }

        /// <summary>
        /// List all active users and pending invites for a merchant account.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<MerchantUsersResponse> MerchantUsersAsync(MerchantProfileRequest request)
        {
            return await DashboardRequestAsync<MerchantUsersResponse>(HttpMethod.Post, "/api/merchant-users", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="MerchantUsersAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public MerchantUsersResponse MerchantUsers(MerchantProfileRequest request)
        {
            return DashboardRequest<MerchantUsersResponse>(HttpMethod.Post, "/api/merchant-users", request, null);
        }

        /// <summary>
        /// Invites a user to join a merchant account.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> InviteMerchantUserAsync(InviteMerchantUserRequest request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/invite-merchant-user", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="InviteMerchantUserAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement InviteMerchantUser(InviteMerchantUserRequest request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Post, "/api/invite-merchant-user", request, null);
        }

        /// <summary>
        /// Adds a test merchant account.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<MerchantProfileResponse> AddTestMerchantAsync(AddTestMerchantRequest request)
        {
            return await DashboardRequestAsync<MerchantProfileResponse>(HttpMethod.Post, "/api/add-test-merchant", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="AddTestMerchantAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public MerchantProfileResponse AddTestMerchant(AddTestMerchantRequest request)
        {
            return DashboardRequest<MerchantProfileResponse>(HttpMethod.Post, "/api/add-test-merchant", request, null);
        }

        /// <summary>
        /// Deletes a test merchant account. Supports partner scoped API credentials
        /// only. Live merchant accounts cannot be deleted.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> DeleteTestMerchantAsync(MerchantProfileRequest request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Delete, "/api/test-merchant/" + request.MerchantId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="DeleteTestMerchantAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement DeleteTestMerchant(MerchantProfileRequest request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Delete, "/api/test-merchant/" + request.MerchantId, request, null);
        }

        /// <summary>
        /// List all merchant platforms configured for a gateway merchant.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<MerchantPlatformsResponse> MerchantPlatformsAsync(MerchantProfileRequest request)
        {
            return await DashboardRequestAsync<MerchantPlatformsResponse>(HttpMethod.Get, "/api/plugin-configs/" + request.MerchantId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="MerchantPlatformsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public MerchantPlatformsResponse MerchantPlatforms(MerchantProfileRequest request)
        {
            return DashboardRequest<MerchantPlatformsResponse>(HttpMethod.Get, "/api/plugin-configs/" + request.MerchantId, request, null);
        }

        /// <summary>
        /// List all merchant platforms configured for a gateway merchant.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> UpdateMerchantPlatformsAsync(MerchantPlatform request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/plugin-configs", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="UpdateMerchantPlatformsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement UpdateMerchantPlatforms(MerchantPlatform request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Post, "/api/plugin-configs", request, null);
        }

        /// <summary>
        /// Deletes a boarding platform configuration.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> DeleteMerchantPlatformsAsync(MerchantPlatformRequest request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Delete, "/api/plugin-config/" + request.PlatformId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="DeleteMerchantPlatformsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement DeleteMerchantPlatforms(MerchantPlatformRequest request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Delete, "/api/plugin-config/" + request.PlatformId, request, null);
        }

        /// <summary>
        /// Returns all terminals associated with the merchant account.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TerminalProfileResponse> TerminalsAsync(TerminalProfileRequest request)
        {
            return await DashboardRequestAsync<TerminalProfileResponse>(HttpMethod.Get, "/api/terminals", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TerminalsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TerminalProfileResponse Terminals(TerminalProfileRequest request)
        {
            return DashboardRequest<TerminalProfileResponse>(HttpMethod.Get, "/api/terminals", request, null);
        }

        /// <summary>
        /// Deactivates a terminal.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> DeactivateTerminalAsync(TerminalDeactivationRequest request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Delete, "/api/terminal/" + request.TerminalId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="DeactivateTerminalAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement DeactivateTerminal(TerminalDeactivationRequest request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Delete, "/api/terminal/" + request.TerminalId, request, null);
        }

        /// <summary>
        /// Activates a terminal.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> ActivateTerminalAsync(TerminalActivationRequest request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/terminal-activate", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="ActivateTerminalAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement ActivateTerminal(TerminalActivationRequest request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Post, "/api/terminal-activate", request, null);
        }

        /// <summary>
        /// Returns a list of terms and conditions templates associated with a merchant
        /// account.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TermsAndConditionsTemplateResponse> TcTemplatesAsync(TermsAndConditionsTemplateRequest request)
        {
            return await DashboardRequestAsync<TermsAndConditionsTemplateResponse>(HttpMethod.Get, "/api/tc-templates", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TcTemplatesAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TermsAndConditionsTemplateResponse TcTemplates(TermsAndConditionsTemplateRequest request)
        {
            return DashboardRequest<TermsAndConditionsTemplateResponse>(HttpMethod.Get, "/api/tc-templates", request, null);
        }

        /// <summary>
        /// Returns a single terms and conditions template.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TermsAndConditionsTemplate> TcTemplateAsync(TermsAndConditionsTemplateRequest request)
        {
            return await DashboardRequestAsync<TermsAndConditionsTemplate>(HttpMethod.Get, "/api/tc-templates/" + request.TemplateId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TcTemplateAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TermsAndConditionsTemplate TcTemplate(TermsAndConditionsTemplateRequest request)
        {
            return DashboardRequest<TermsAndConditionsTemplate>(HttpMethod.Get, "/api/tc-templates/" + request.TemplateId, request, null);
        }

        /// <summary>
        /// Updates or creates a terms and conditions template.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TermsAndConditionsTemplate> TcUpdateTemplateAsync(TermsAndConditionsTemplate request)
        {
            return await DashboardRequestAsync<TermsAndConditionsTemplate>(HttpMethod.Post, "/api/tc-templates", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TcUpdateTemplateAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TermsAndConditionsTemplate TcUpdateTemplate(TermsAndConditionsTemplate request)
        {
            return DashboardRequest<TermsAndConditionsTemplate>(HttpMethod.Post, "/api/tc-templates", request, null);
        }

        /// <summary>
        /// Deletes a single terms and conditions template.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> TcDeleteTemplateAsync(TermsAndConditionsTemplateRequest request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Delete, "/api/tc-templates/" + request.TemplateId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TcDeleteTemplateAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement TcDeleteTemplate(TermsAndConditionsTemplateRequest request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Delete, "/api/tc-templates/" + request.TemplateId, request, null);
        }

        /// <summary>
        /// Returns up to 250 entries from the Terms and Conditions log.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TermsAndConditionsLogResponse> TcLogAsync(TermsAndConditionsLogRequest request)
        {
            return await DashboardRequestAsync<TermsAndConditionsLogResponse>(HttpMethod.Post, "/api/tc-log", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TcLogAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TermsAndConditionsLogResponse TcLog(TermsAndConditionsLogRequest request)
        {
            return DashboardRequest<TermsAndConditionsLogResponse>(HttpMethod.Post, "/api/tc-log", request, null);
        }

        /// <summary>
        /// Returns a single detailed Terms and Conditions entry.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TermsAndConditionsLogEntry> TcEntryAsync(TermsAndConditionsLogRequest request)
        {
            return await DashboardRequestAsync<TermsAndConditionsLogEntry>(HttpMethod.Get, "/api/tc-entry/" + request.LogEntryId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TcEntryAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TermsAndConditionsLogEntry TcEntry(TermsAndConditionsLogRequest request)
        {
            return DashboardRequest<TermsAndConditionsLogEntry>(HttpMethod.Get, "/api/tc-entry/" + request.LogEntryId, request, null);
        }

        /// <summary>
        /// Returns all survey questions for a given merchant.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<SurveyQuestionResponse> SurveyQuestionsAsync(SurveyQuestionRequest request)
        {
            return await DashboardRequestAsync<SurveyQuestionResponse>(HttpMethod.Get, "/api/survey-questions", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="SurveyQuestionsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public SurveyQuestionResponse SurveyQuestions(SurveyQuestionRequest request)
        {
            return DashboardRequest<SurveyQuestionResponse>(HttpMethod.Get, "/api/survey-questions", request, null);
        }

        /// <summary>
        /// Returns a single survey question with response data.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<SurveyQuestion> SurveyQuestionAsync(SurveyQuestionRequest request)
        {
            return await DashboardRequestAsync<SurveyQuestion>(HttpMethod.Get, "/api/survey-questions/" + request.QuestionId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="SurveyQuestionAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public SurveyQuestion SurveyQuestion(SurveyQuestionRequest request)
        {
            return DashboardRequest<SurveyQuestion>(HttpMethod.Get, "/api/survey-questions/" + request.QuestionId, request, null);
        }

        /// <summary>
        /// Updates or creates a survey question.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<SurveyQuestion> UpdateSurveyQuestionAsync(SurveyQuestion request)
        {
            return await DashboardRequestAsync<SurveyQuestion>(HttpMethod.Post, "/api/survey-questions", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="UpdateSurveyQuestionAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public SurveyQuestion UpdateSurveyQuestion(SurveyQuestion request)
        {
            return DashboardRequest<SurveyQuestion>(HttpMethod.Post, "/api/survey-questions", request, null);
        }

        /// <summary>
        /// Deletes a survey question.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> DeleteSurveyQuestionAsync(SurveyQuestionRequest request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Delete, "/api/survey-questions/" + request.QuestionId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="DeleteSurveyQuestionAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement DeleteSurveyQuestion(SurveyQuestionRequest request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Delete, "/api/survey-questions/" + request.QuestionId, request, null);
        }

        /// <summary>
        /// Returns results for a single survey question.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<SurveyQuestion> SurveyResultsAsync(SurveyResultsRequest request)
        {
            return await DashboardRequestAsync<SurveyQuestion>(HttpMethod.Post, "/api/survey-results", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="SurveyResultsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public SurveyQuestion SurveyResults(SurveyResultsRequest request)
        {
            return DashboardRequest<SurveyQuestion>(HttpMethod.Post, "/api/survey-results", request, null);
        }

        /// <summary>
        /// Returns the media library for a given partner, merchant, or organization.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<MediaLibraryResponse> MediaAsync(MediaRequest request)
        {
            return await DashboardRequestAsync<MediaLibraryResponse>(HttpMethod.Get, "/api/media", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="MediaAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public MediaLibraryResponse Media(MediaRequest request)
        {
            return DashboardRequest<MediaLibraryResponse>(HttpMethod.Get, "/api/media", request, null);
        }

        /// <summary>
        /// Uploads a media asset to the media library.
        /// </summary>
        /// <param name="request">The request details.</param>
        /// <param name="inStream">The raw stream providing access to the upload file binary.</param>
        public async Task<MediaMetadata> UploadMediaAsync(UploadMetadata request, Stream inStream)
        {
            return await UploadRequestAsync<MediaMetadata>("/api/upload-media", request, inStream)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="UploadMediaAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        /// <param name="inStream">The raw stream providing access to the upload file binary.</param>
        public MediaMetadata UploadMedia(UploadMetadata request, Stream inStream)
        {
            return UploadRequest<MediaMetadata>("/api/upload-media", request, inStream);
        }

        /// <summary>
        /// Retrieves the current status of a file upload.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<UploadStatus> UploadStatusAsync(UploadStatusRequest request)
        {
            return await DashboardRequestAsync<UploadStatus>(HttpMethod.Get, "/api/media-upload/" + request.UploadId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="UploadStatusAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public UploadStatus UploadStatus(UploadStatusRequest request)
        {
            return DashboardRequest<UploadStatus>(HttpMethod.Get, "/api/media-upload/" + request.UploadId, request, null);
        }

        /// <summary>
        /// Returns the media details for a single media asset.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<MediaMetadata> MediaAssetAsync(MediaRequest request)
        {
            return await DashboardRequestAsync<MediaMetadata>(HttpMethod.Get, "/api/media/" + request.MediaId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="MediaAssetAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public MediaMetadata MediaAsset(MediaRequest request)
        {
            return DashboardRequest<MediaMetadata>(HttpMethod.Get, "/api/media/" + request.MediaId, request, null);
        }

        /// <summary>
        /// Deletes a media asset.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> DeleteMediaAssetAsync(MediaRequest request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Delete, "/api/media/" + request.MediaId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="DeleteMediaAssetAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement DeleteMediaAsset(MediaRequest request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Delete, "/api/media/" + request.MediaId, request, null);
        }

        /// <summary>
        /// Returns a collection of slide shows.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<SlideShowResponse> SlideShowsAsync(SlideShowRequest request)
        {
            return await DashboardRequestAsync<SlideShowResponse>(HttpMethod.Get, "/api/slide-shows", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="SlideShowsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public SlideShowResponse SlideShows(SlideShowRequest request)
        {
            return DashboardRequest<SlideShowResponse>(HttpMethod.Get, "/api/slide-shows", request, null);
        }

        /// <summary>
        /// Returns a single slide show with slides.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<SlideShow> SlideShowAsync(SlideShowRequest request)
        {
            return await DashboardRequestAsync<SlideShow>(HttpMethod.Get, "/api/slide-shows/" + request.SlideShowId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="SlideShowAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public SlideShow SlideShow(SlideShowRequest request)
        {
            return DashboardRequest<SlideShow>(HttpMethod.Get, "/api/slide-shows/" + request.SlideShowId, request, null);
        }

        /// <summary>
        /// Updates or creates a slide show.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<SlideShow> UpdateSlideShowAsync(SlideShow request)
        {
            return await DashboardRequestAsync<SlideShow>(HttpMethod.Post, "/api/slide-shows", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="UpdateSlideShowAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public SlideShow UpdateSlideShow(SlideShow request)
        {
            return DashboardRequest<SlideShow>(HttpMethod.Post, "/api/slide-shows", request, null);
        }

        /// <summary>
        /// Deletes a single slide show.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> DeleteSlideShowAsync(SlideShowRequest request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Delete, "/api/slide-shows/" + request.SlideShowId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="DeleteSlideShowAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement DeleteSlideShow(SlideShowRequest request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Delete, "/api/slide-shows/" + request.SlideShowId, request, null);
        }

        /// <summary>
        /// Returns the terminal branding stack for a given set of API credentials.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<BrandingAssetResponse> TerminalBrandingAsync(BrandingAssetRequest request)
        {
            return await DashboardRequestAsync<BrandingAssetResponse>(HttpMethod.Get, "/api/terminal-branding", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TerminalBrandingAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public BrandingAssetResponse TerminalBranding(BrandingAssetRequest request)
        {
            return DashboardRequest<BrandingAssetResponse>(HttpMethod.Get, "/api/terminal-branding", request, null);
        }

        /// <summary>
        /// Updates a branding asset.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<BrandingAsset> UpdateBrandingAssetAsync(BrandingAsset request)
        {
            return await DashboardRequestAsync<BrandingAsset>(HttpMethod.Post, "/api/terminal-branding", request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="UpdateBrandingAssetAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public BrandingAsset UpdateBrandingAsset(BrandingAsset request)
        {
            return DashboardRequest<BrandingAsset>(HttpMethod.Post, "/api/terminal-branding", request, null);
        }

        /// <summary>
        /// Deletes a branding asset.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> DeleteBrandingAssetAsync(BrandingAssetRequest request)
        {
            return await DashboardRequestAsync<Acknowledgement>(HttpMethod.Delete, "/api/terminal-branding/" + request.AssetId, request, null)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="DeleteBrandingAssetAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement DeleteBrandingAsset(BrandingAssetRequest request)
        {
            return DashboardRequest<Acknowledgement>(HttpMethod.Delete, "/api/terminal-branding/" + request.AssetId, request, null);
        }

        /// <summary>
        /// Returns routing and location data for a payment terminal.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<LocateResponse> LocateAsync(LocateRequest request)
        {
            return await GatewayRequestAsync<LocateResponse>(HttpMethod.Post, "/api/terminal-locate", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="LocateAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public LocateResponse Locate(LocateRequest request)
        {
            return GatewayRequest<LocateResponse>(HttpMethod.Post, "/api/terminal-locate", request, null, request.Test);
        }

        /// <summary>
        /// Captures a preauthorization.
        /// </summary>
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

        /// <summary>
        /// Discards a previous transaction.
        /// </summary>
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
        /// Executes a manual time out reversal.
        ///
        /// We love time out reversals. Don't be afraid to use them whenever a request to a
        /// BlockChyp terminal times out. You have up to two minutes to reverse any
        /// transaction. The only caveat is that you must assign transactionRef values
        /// when you build the original request. Otherwise, we have no real way of knowing
        /// which transaction you're trying to reverse because we may not have assigned it
        /// an id yet. And if we did assign it an id, you wouldn't know what it is because your
        /// request to the terminal timed out before you got a response.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<AuthorizationResponse> ReverseAsync(AuthorizationRequest request)
        {
            return await GatewayRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/reverse", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="ReverseAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public AuthorizationResponse Reverse(AuthorizationRequest request)
        {
            return GatewayRequest<AuthorizationResponse>(HttpMethod.Post, "/api/reverse", request, null, request.Test);
        }

        /// <summary>
        /// Closes the current credit card batch.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<CloseBatchResponse> CloseBatchAsync(CloseBatchRequest request)
        {
            return await GatewayRequestAsync<CloseBatchResponse>(HttpMethod.Post, "/api/close-batch", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="CloseBatchAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public CloseBatchResponse CloseBatch(CloseBatchRequest request)
        {
            return GatewayRequest<CloseBatchResponse>(HttpMethod.Post, "/api/close-batch", request, null, request.Test);
        }

        /// <summary>
        /// Creates and send a payment link to a customer.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<PaymentLinkResponse> SendPaymentLinkAsync(PaymentLinkRequest request)
        {
            return await GatewayRequestAsync<PaymentLinkResponse>(HttpMethod.Post, "/api/send-payment-link", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="SendPaymentLinkAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public PaymentLinkResponse SendPaymentLink(PaymentLinkRequest request)
        {
            return GatewayRequest<PaymentLinkResponse>(HttpMethod.Post, "/api/send-payment-link", request, null, request.Test);
        }

        /// <summary>
        /// Resends payment link.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<ResendPaymentLinkResponse> ResendPaymentLinkAsync(ResendPaymentLinkRequest request)
        {
            return await GatewayRequestAsync<ResendPaymentLinkResponse>(HttpMethod.Post, "/api/resend-payment-link", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="ResendPaymentLinkAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public ResendPaymentLinkResponse ResendPaymentLink(ResendPaymentLinkRequest request)
        {
            return GatewayRequest<ResendPaymentLinkResponse>(HttpMethod.Post, "/api/resend-payment-link", request, null, request.Test);
        }

        /// <summary>
        /// Cancels a payment link.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<CancelPaymentLinkResponse> CancelPaymentLinkAsync(CancelPaymentLinkRequest request)
        {
            return await GatewayRequestAsync<CancelPaymentLinkResponse>(HttpMethod.Post, "/api/cancel-payment-link", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="CancelPaymentLinkAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public CancelPaymentLinkResponse CancelPaymentLink(CancelPaymentLinkRequest request)
        {
            return GatewayRequest<CancelPaymentLinkResponse>(HttpMethod.Post, "/api/cancel-payment-link", request, null, request.Test);
        }

        /// <summary>
        /// Retrieves the status of a payment link.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<PaymentLinkStatusResponse> PaymentLinkStatusAsync(PaymentLinkStatusRequest request)
        {
            return await GatewayRequestAsync<PaymentLinkStatusResponse>(HttpMethod.Post, "/api/payment-link-status", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="PaymentLinkStatusAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public PaymentLinkStatusResponse PaymentLinkStatus(PaymentLinkStatusRequest request)
        {
            return GatewayRequest<PaymentLinkStatusResponse>(HttpMethod.Post, "/api/payment-link-status", request, null, request.Test);
        }

        /// <summary>
        /// Retrieves the current status of a transaction.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<AuthorizationResponse> TransactionStatusAsync(TransactionStatusRequest request)
        {
            return await GatewayRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/tx-status", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TransactionStatusAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public AuthorizationResponse TransactionStatus(TransactionStatusRequest request)
        {
            return GatewayRequest<AuthorizationResponse>(HttpMethod.Post, "/api/tx-status", request, null, request.Test);
        }

        /// <summary>
        /// Updates or creates a customer record.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<CustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            return await GatewayRequestAsync<CustomerResponse>(HttpMethod.Post, "/api/update-customer", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="UpdateCustomerAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public CustomerResponse UpdateCustomer(UpdateCustomerRequest request)
        {
            return GatewayRequest<CustomerResponse>(HttpMethod.Post, "/api/update-customer", request, null, request.Test);
        }

        /// <summary>
        /// Retrieves a customer by id.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<CustomerResponse> CustomerAsync(CustomerRequest request)
        {
            return await GatewayRequestAsync<CustomerResponse>(HttpMethod.Post, "/api/customer", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="CustomerAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public CustomerResponse Customer(CustomerRequest request)
        {
            return GatewayRequest<CustomerResponse>(HttpMethod.Post, "/api/customer", request, null, request.Test);
        }

        /// <summary>
        /// Searches the customer database.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<CustomerSearchResponse> CustomerSearchAsync(CustomerSearchRequest request)
        {
            return await GatewayRequestAsync<CustomerSearchResponse>(HttpMethod.Post, "/api/customer-search", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="CustomerSearchAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public CustomerSearchResponse CustomerSearch(CustomerSearchRequest request)
        {
            return GatewayRequest<CustomerSearchResponse>(HttpMethod.Post, "/api/customer-search", request, null, request.Test);
        }

        /// <summary>
        /// Calculates the discount for actual cash transactions.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<CashDiscountResponse> CashDiscountAsync(CashDiscountRequest request)
        {
            return await GatewayRequestAsync<CashDiscountResponse>(HttpMethod.Post, "/api/cash-discount", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="CashDiscountAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public CashDiscountResponse CashDiscount(CashDiscountRequest request)
        {
            return GatewayRequest<CashDiscountResponse>(HttpMethod.Post, "/api/cash-discount", request, null, request.Test);
        }

        /// <summary>
        /// Returns the batch history for a merchant.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<BatchHistoryResponse> BatchHistoryAsync(BatchHistoryRequest request)
        {
            return await GatewayRequestAsync<BatchHistoryResponse>(HttpMethod.Post, "/api/batch-history", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="BatchHistoryAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public BatchHistoryResponse BatchHistory(BatchHistoryRequest request)
        {
            return GatewayRequest<BatchHistoryResponse>(HttpMethod.Post, "/api/batch-history", request, null, request.Test);
        }

        /// <summary>
        /// Returns the batch details for a single batch.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<BatchDetailsResponse> BatchDetailsAsync(BatchDetailsRequest request)
        {
            return await GatewayRequestAsync<BatchDetailsResponse>(HttpMethod.Post, "/api/batch-details", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="BatchDetailsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public BatchDetailsResponse BatchDetails(BatchDetailsRequest request)
        {
            return GatewayRequest<BatchDetailsResponse>(HttpMethod.Post, "/api/batch-details", request, null, request.Test);
        }

        /// <summary>
        /// Returns the transaction history for a merchant.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TransactionHistoryResponse> TransactionHistoryAsync(TransactionHistoryRequest request)
        {
            return await GatewayRequestAsync<TransactionHistoryResponse>(HttpMethod.Post, "/api/tx-history", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TransactionHistoryAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TransactionHistoryResponse TransactionHistory(TransactionHistoryRequest request)
        {
            return GatewayRequest<TransactionHistoryResponse>(HttpMethod.Post, "/api/tx-history", request, null, request.Test);
        }

        /// <summary>
        /// Returns pricing policy for a merchant.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<PricingPolicyResponse> PricingPolicyAsync(PricingPolicyRequest request)
        {
            return await GatewayRequestAsync<PricingPolicyResponse>(HttpMethod.Post, "/api/read-pricing-policy", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="PricingPolicyAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public PricingPolicyResponse PricingPolicy(PricingPolicyRequest request)
        {
            return GatewayRequest<PricingPolicyResponse>(HttpMethod.Post, "/api/read-pricing-policy", request, null, request.Test);
        }

        /// <summary>
        /// Returns a list of partner statements.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<PartnerStatementListResponse> PartnerStatementsAsync(PartnerStatementListRequest request)
        {
            return await GatewayRequestAsync<PartnerStatementListResponse>(HttpMethod.Post, "/api/partner-statement-list", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="PartnerStatementsAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public PartnerStatementListResponse PartnerStatements(PartnerStatementListRequest request)
        {
            return GatewayRequest<PartnerStatementListResponse>(HttpMethod.Post, "/api/partner-statement-list", request, null, request.Test);
        }

        /// <summary>
        /// Returns detail for a single partner statement.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<PartnerStatementDetailResponse> PartnerStatementDetailAsync(PartnerStatementDetailRequest request)
        {
            return await GatewayRequestAsync<PartnerStatementDetailResponse>(HttpMethod.Post, "/api/partner-statement-detail", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="PartnerStatementDetailAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public PartnerStatementDetailResponse PartnerStatementDetail(PartnerStatementDetailRequest request)
        {
            return GatewayRequest<PartnerStatementDetailResponse>(HttpMethod.Post, "/api/partner-statement-detail", request, null, request.Test);
        }

        /// <summary>
        /// Returns a list of merchant invoices.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<MerchantInvoiceListResponse> MerchantInvoicesAsync(MerchantInvoiceListRequest request)
        {
            return await GatewayRequestAsync<MerchantInvoiceListResponse>(HttpMethod.Post, "/api/merchant-invoice-list", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="MerchantInvoicesAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public MerchantInvoiceListResponse MerchantInvoices(MerchantInvoiceListRequest request)
        {
            return GatewayRequest<MerchantInvoiceListResponse>(HttpMethod.Post, "/api/merchant-invoice-list", request, null, request.Test);
        }

        /// <summary>
        /// Returns detail for a single merchant-invoice statement.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<MerchantInvoiceDetailResponse> MerchantInvoiceDetailAsync(MerchantInvoiceDetailRequest request)
        {
            return await GatewayRequestAsync<MerchantInvoiceDetailResponse>(HttpMethod.Post, "/api/merchant-invoice-detail", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="MerchantInvoiceDetailAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public MerchantInvoiceDetailResponse MerchantInvoiceDetail(MerchantInvoiceDetailRequest request)
        {
            return GatewayRequest<MerchantInvoiceDetailResponse>(HttpMethod.Post, "/api/merchant-invoice-detail", request, null, request.Test);
        }

        /// <summary>
        /// Returns low level details for how partner commissions were calculated for a
        /// specific merchant statement.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<PartnerCommissionBreakdownResponse> PartnerCommissionBreakdownAsync(PartnerCommissionBreakdownRequest request)
        {
            return await GatewayRequestAsync<PartnerCommissionBreakdownResponse>(HttpMethod.Post, "/api/partner-commission-breakdown", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="PartnerCommissionBreakdownAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public PartnerCommissionBreakdownResponse PartnerCommissionBreakdown(PartnerCommissionBreakdownRequest request)
        {
            return GatewayRequest<PartnerCommissionBreakdownResponse>(HttpMethod.Post, "/api/partner-commission-breakdown", request, null, request.Test);
        }

        /// <summary>
        /// Returns profile information for a merchant.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<MerchantProfileResponse> MerchantProfileAsync(MerchantProfileRequest request)
        {
            return await GatewayRequestAsync<MerchantProfileResponse>(HttpMethod.Post, "/api/public-merchant-profile", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="MerchantProfileAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public MerchantProfileResponse MerchantProfile(MerchantProfileRequest request)
        {
            return GatewayRequest<MerchantProfileResponse>(HttpMethod.Post, "/api/public-merchant-profile", request, null, request.Test);
        }

        /// <summary>
        /// Deletes a customer record.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<DeleteCustomerResponse> DeleteCustomerAsync(DeleteCustomerRequest request)
        {
            return await GatewayRequestAsync<DeleteCustomerResponse>(HttpMethod.Delete, "/api/customer/" + request.CustomerId, request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="DeleteCustomerAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public DeleteCustomerResponse DeleteCustomer(DeleteCustomerRequest request)
        {
            return GatewayRequest<DeleteCustomerResponse>(HttpMethod.Delete, "/api/customer/" + request.CustomerId, request, null, request.Test);
        }

        /// <summary>
        /// Retrieves payment token metadata.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<TokenMetadataResponse> TokenMetadataAsync(TokenMetadataRequest request)
        {
            return await GatewayRequestAsync<TokenMetadataResponse>(HttpMethod.Get, "/api/token/" + request.Token, request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="TokenMetadataAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public TokenMetadataResponse TokenMetadata(TokenMetadataRequest request)
        {
            return GatewayRequest<TokenMetadataResponse>(HttpMethod.Get, "/api/token/" + request.Token, request, null, request.Test);
        }

        /// <summary>
        /// Links a token to a customer record.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> LinkTokenAsync(LinkTokenRequest request)
        {
            return await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/link-token", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="LinkTokenAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement LinkToken(LinkTokenRequest request)
        {
            return GatewayRequest<Acknowledgement>(HttpMethod.Post, "/api/link-token", request, null, request.Test);
        }

        /// <summary>
        /// Removes a link between a customer and a token.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<Acknowledgement> UnlinkTokenAsync(UnlinkTokenRequest request)
        {
            return await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/unlink-token", request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="UnlinkTokenAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public Acknowledgement UnlinkToken(UnlinkTokenRequest request)
        {
            return GatewayRequest<Acknowledgement>(HttpMethod.Post, "/api/unlink-token", request, null, request.Test);
        }

        /// <summary>
        /// Deletes a payment token.
        /// </summary>
        /// <param name="request">The request details.</param>
        public async Task<DeleteTokenResponse> DeleteTokenAsync(DeleteTokenRequest request)
        {
            return await GatewayRequestAsync<DeleteTokenResponse>(HttpMethod.Delete, "/api/token/" + request.Token, request, null, request.Test)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous form of <see cref="DeleteTokenAsync"/>.
        /// </summary>
        /// <param name="request">The request details.</param>
        public DeleteTokenResponse DeleteToken(DeleteTokenRequest request)
        {
            return GatewayRequest<DeleteTokenResponse>(HttpMethod.Delete, "/api/token/" + request.Token, request, null, request.Test);
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

            var timeout = GetTimeout(body, TerminalRequestTimeout);
            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeout);

            try
            {
                using (var response = await TerminalClient.SendAsync(httpRequest, cts.Token).ConfigureAwait(false))
                {
                    string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return ProcessResponse<T>(response.StatusCode, responseBody);
                }
            }
            catch (OperationCanceledException e)
            {
                throw new TimeoutException("Terminal request timed out", e);
            }
            catch (HttpRequestException)
            {
                // Try renegotiating the route in case this failure was due to DHCP renegotiation.
                // If the route has not changed, the request will not be retried, preventing
                // infinite recursion.
                if (await RefreshTerminalRoute(route).ConfigureAwait(false))
                {
                    return await TerminalRequestAsync<T>(method, path, name, body);
                }

                throw;
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
        /// <param name="relay">Whether or not the request will be relayed to a terminal.</param>
        /// <typeparam name="T">The expected response entity.</typeparam>
        /// <exception cref="TimeoutException">if HTTP request time exceeds <c>GatewayRequestTimeout</c>.</exception>
        public async Task<T> GatewayRequestAsync<T>(HttpMethod method, string path, object body, string query, bool test, bool relay = false)
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

            var timeout = GetTimeout(body, relay ? TerminalRequestTimeout : GatewayRequestTimeout);
            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeout);

            try
            {
                using (var response = await GatewayClient.SendAsync(request, cts.Token).ConfigureAwait(false))
                {
                        string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        return ProcessResponse<T>(response.StatusCode, responseBody);
                }
            }
            catch (OperationCanceledException e)
            {
                throw new TimeoutException("Gateway request timed out", e);
            }
        }

        /// <summary>
        /// Sends a request to the dashboard and returns its response
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="path">The relative path of the request.</param>
        /// <param name="body">The request body.</param>
        /// <param name="query">A URL query string to send with the request.</param>
        /// <typeparam name="T">The expected response entity.</typeparam>
        /// <exception cref="TimeoutException">if HTTP request time exceeds <c>GatewayRequestTimeout</c>.</exception>
        public async Task<T> DashboardRequestAsync<T>(HttpMethod method, string path, object body, string query)
        {
            var requestUrl = ToFullyQualifiedDashboardPath(path, query);
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

            var timeout = GetTimeout(body, GatewayRequestTimeout);
            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeout);

            try
            {
                using (var response = await GatewayClient.SendAsync(request, cts.Token).ConfigureAwait(false))
                {
                        string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        return ProcessResponse<T>(response.StatusCode, responseBody);
                }
            }
            catch (OperationCanceledException e)
            {
                throw new TimeoutException("Dashboard request timed out", e);
            }
        }

        /// <summary>
        /// Sends an upload request to the dashboard and blocks until it responds.
        /// </summary>
        /// <param name="path">The relative path of the request.</param>
        /// <param name="upload">Metadata about the file upload.</param>
        /// <param name="inStream">The raw input stream providing access to the file contents.</param>
        /// <typeparam name="T">The expected response entity.</typeparam>
        public T UploadRequest<T>(string path, UploadMetadata upload, Stream inStream)
        {
            return UploadRequestAsync<T>(path, upload, inStream)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends a request to the dashboard and returns its response
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="path">The relative path of the request.</param>
        /// <param name="upload">Metadata about the file upload.</param>
        /// <param name="inStream">The raw input stream providing access to the file contents.</param>
        /// <typeparam name="T">The expected response entity.</typeparam>
        /// <exception cref="TimeoutException">if HTTP request time exceeds <c>GatewayRequestTimeout</c>.</exception>
        public async Task<T> UploadRequestAsync<T>(string path, UploadMetadata upload, Stream inStream)
        {
            var requestUrl = ToFullyQualifiedDashboardPath(path, string.Empty);
            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            request.Content = new StreamContent(inStream);

            if (Credentials != null)
            {
                var headers = Crypto.GenerateAuthHeaders(Credentials);
                foreach (KeyValuePair<string, string> header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            if (upload.FileSize > 0)
            {
                request.Headers.Add("X-File-Size", upload.FileSize.ToString());
            }

            if (upload.FileName != string.Empty)
            {
                request.Headers.Add("X-Upload-File-Name", upload.FileName);
            }

            if (upload.UploadId != string.Empty)
            {
                request.Headers.Add("X-Upload-ID", upload.UploadId);
            }

            var timeout = GetTimeout(upload, GatewayRequestTimeout);
            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeout);

            try
            {
                using (var response = await GatewayClient.SendAsync(request, cts.Token).ConfigureAwait(false))
                {
                        string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        return ProcessResponse<T>(response.StatusCode, responseBody);
                }
            }
            catch (OperationCanceledException e)
            {
                throw new TimeoutException("Upload request timed out", e);
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
        /// <param name="relay">Whether or not the request will be relayed to a terminal.</param>
        /// <typeparam name="T">The expected response entity.</typeparam>
        public T GatewayRequest<T>(HttpMethod method, string path, object body, string query, bool test, bool relay = false)
        {
            return GatewayRequestAsync<T>(method, path, body, query, test, relay)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends a request to the dashboard and blocks until it response.
        /// </summary>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="path">The relative path of the request.</param>
        /// <param name="body">The request body.</param>
        /// <param name="query">A URL query string to send with the request.</param>
        /// <typeparam name="T">The expected response entity.</typeparam>
        public T DashboardRequest<T>(HttpMethod method, string path, object body, string query)
        {
            return DashboardRequestAsync<T>(method, path, body, query)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private static T ProcessResponse<T>(HttpStatusCode statusCode, string body)
        {
            if (statusCode != HttpStatusCode.OK)
            {
                try
                {
                    var core = JsonConvert.DeserializeObject<Acknowledgement>(body);

                    string msg;
                    if (!string.IsNullOrEmpty(core.ResponseDescription))
                    {
                        msg = core.ResponseDescription;
                    }
                    else if (!string.IsNullOrEmpty(core.Error))
                    {
                        msg = core.Error;
                    }
                    else
                    {
                        msg = $"HTTP {statusCode}: \"{body}\"";
                    }

                    throw new BlockChypException(
                        msg,
                        statusCode,
                        body);
                }
                catch (JsonException e)
                {
                        throw new BlockChypException(
                            $"HTTP {statusCode}: \"{body}\"",
                            e,
                            statusCode,
                            body);
                }
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(body);
            }
            catch (JsonException e)
            {
                throw new BlockChypException(
                    $"Invalid response: \"{body}\"",
                    e,
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

        private static void PopulateSignatureOptions(ISignatureRequest request)
        {
            if (string.IsNullOrEmpty(request.SigFile) || request.SigFormat != SignatureFormat.None)
            {
                return;
            }

            string[] elements = request.SigFile.Split('.');

            request.SigFormat = (SignatureFormat)Enum
                .Parse(typeof(SignatureFormat), elements[elements.Length - 1], true);
        }

        private static void DumpSignatureFile(ISignatureRequest request, ISignatureResponse response)
        {
            if (string.IsNullOrEmpty(response.SigFile) || string.IsNullOrEmpty(request.SigFile))
            {
                return;
            }

            var rawSignature = Crypto.FromHex(response.SigFile);

            File.WriteAllBytes(request.SigFile, rawSignature);
        }

        private static TimeSpan GetTimeout(object body, TimeSpan defaultTimeout)
        {
            var coreRequest = body as ITimeoutRequest;
            if (coreRequest != null && coreRequest.Timeout > 0)
            {
                return TimeSpan.FromSeconds(coreRequest.Timeout);
            }

            return defaultTimeout;
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

            try
            {
                var route = await GetTerminalRouteFromGateway(name)
                    .ConfigureAwait(false);

                if (route != null)
                {
                    RouteCache.Put(route, Credentials);
                }

                return route;
            }
            catch
            {
                // Try to re-use expired route if one exists. This is for
                // situations where the network has gone down, but requests
                // can still be fulfilled by store & forward.
                cachedRoute = RouteCache.Get(name, Credentials, true);
                if (cachedRoute != null)
                {
                    return cachedRoute;
                }

                throw;
            }
        }

        private async Task<bool> RefreshTerminalRoute(TerminalRouteResponse route)
        {
            try
            {
                var newRoute = await GetTerminalRouteFromGateway(route.TerminalName)
                    .ConfigureAwait(false);

                if (newRoute != null)
                {
                    RouteCache.Put(newRoute, Credentials);

                    return route.IpAddress != newRoute.IpAddress;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private async Task<TerminalRouteResponse> GetTerminalRouteFromGateway(string name)
        {
            var route = await GatewayRequestAsync<TerminalRouteResponse>(
                HttpMethod.Get, $"/api/terminal-route", null, $"terminal={name}", false)
                    .ConfigureAwait(false);

            if (route != null && route.Success)
            {
                route.Timestamp = DateTime.UtcNow;

                return route;
            }

            return null;
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
            var prefix = test ? GatewayTestEndpoint : GatewayEndpoint;

            var builder = new UriBuilder(prefix);
            builder.Path = path;
            builder.Query = query;

            return builder.Uri;
        }

        private Uri ToFullyQualifiedDashboardPath(string path, string query)
        {
            var prefix = DashboardEndpoint;

            var builder = new UriBuilder(prefix);
            builder.Path = path;
            builder.Query = query;

            return builder.Uri;
        }
    }
}
