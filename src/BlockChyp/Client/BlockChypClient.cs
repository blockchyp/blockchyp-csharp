// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

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
                response = await GatewayRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/charge", request, null, request.Test)
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
                response = await GatewayRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/preauth", request, null, request.Test)
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
                response = await GatewayRequestAsync<PingResponse>(HttpMethod.Post, "/api/terminal-test", request, null, request.Test)
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
                response = await GatewayRequestAsync<BalanceResponse>(HttpMethod.Post, "/api/balance", request, null, request.Test)
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
                response = await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/terminal-clear", request, null, request.Test)
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
                response = await GatewayRequestAsync<TermsAndConditionsResponse>(HttpMethod.Post, "/api/terminal-tc", request, null, request.Test)
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
        /// Appends items to an existing transaction display Subtotal, Tax, and Total are
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
                response = await GatewayRequestAsync<Acknowledgement>(HttpMethod.Put, "/api/terminal-txdisplay", request, null, request.Test)
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
                response = await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/terminal-txdisplay", request, null, request.Test)
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
        /// Asks the consumer text based question.
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
                response = await GatewayRequestAsync<TextPromptResponse>(HttpMethod.Post, "/api/text-prompt", request, null, request.Test)
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
                response = await GatewayRequestAsync<BooleanPromptResponse>(HttpMethod.Post, "/api/boolean-prompt", request, null, request.Test)
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
                response = await GatewayRequestAsync<Acknowledgement>(HttpMethod.Post, "/api/message", request, null, request.Test)
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
                response = await GatewayRequestAsync<AuthorizationResponse>(HttpMethod.Post, "/api/refund", request, null, request.Test)
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
                response = await GatewayRequestAsync<EnrollResponse>(HttpMethod.Post, "/api/enroll", request, null, request.Test)
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
                response = await GatewayRequestAsync<GiftActivateResponse>(HttpMethod.Post, "/api/gift-activate", request, null, request.Test)
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
        /// Discards a previous preauth transaction.
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
                    var core = JsonConvert.DeserializeObject<IAbstractAcknowledgement>(body);

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
    }
}
