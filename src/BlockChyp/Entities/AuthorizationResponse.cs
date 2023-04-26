// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// The response to an authorization request.
    /// </summary>
    public class AuthorizationResponse : BaseEntity, IAbstractAcknowledgement, IApprovalResponse, ICoreResponse, IPaymentAmounts, ICryptocurrencyResponse, IPaymentMethodResponse, ISignatureResponse
    {
        /// <summary>
        /// Whether or not the request succeeded.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// The error, if an error occurred.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        /// <summary>
        /// A narrative description of the transaction result.
        /// </summary>
        [JsonProperty(PropertyName = "responseDescription")]
        public string ResponseDescription { get; set; }

        /// <summary>
        /// That the transaction was approved.
        /// </summary>
        [JsonProperty(PropertyName = "approved")]
        public bool Approved { get; set; }

        /// <summary>
        /// The auth code from the payment network.
        /// </summary>
        [JsonProperty(PropertyName = "authCode")]
        public string AuthCode { get; set; }

        /// <summary>
        /// The code returned by the terminal or the card issuer to indicate the disposition
        /// of the message.
        /// </summary>
        [JsonProperty(PropertyName = "authResponseCode")]
        public string AuthResponseCode { get; set; }

        /// <summary>
        /// The ID assigned to the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// The ID assigned to the batch.
        /// </summary>
        [JsonProperty(PropertyName = "batchId")]
        public string BatchId { get; set; }

        /// <summary>
        /// The transaction reference string assigned to the transaction request. If no
        /// transaction ref was assiged on the request, then the gateway will randomly
        /// generate one.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// The type of transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transactionType")]
        public string TransactionType { get; set; }

        /// <summary>
        /// The timestamp of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// The hash of the last tick block.
        /// </summary>
        [JsonProperty(PropertyName = "tickBlock")]
        public string TickBlock { get; set; }

        /// <summary>
        /// That the transaction was processed on the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// The settlement account for merchants with split settlements.
        /// </summary>
        [JsonProperty(PropertyName = "destinationAccount")]
        public string DestinationAccount { get; set; }

        /// <summary>
        /// The ECC signature of the response. Can be used to ensure that it was signed by the
        /// terminal and detect man-in-the middle attacks.
        /// </summary>
        [JsonProperty(PropertyName = "sig")]
        public string Sig { get; set; }

        /// <summary>
        /// Whether or not the transaction was approved for a partial amount.
        /// </summary>
        [JsonProperty(PropertyName = "partialAuth")]
        public bool PartialAuth { get; set; }

        /// <summary>
        /// Whether or not an alternate currency was used.
        /// </summary>
        [JsonProperty(PropertyName = "altCurrency")]
        public bool AltCurrency { get; set; }

        /// <summary>
        /// Whether or not a request was settled on an FSA card.
        /// </summary>
        [JsonProperty(PropertyName = "fsaAuth")]
        public bool FsaAuth { get; set; }

        /// <summary>
        /// The currency code used for the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The requested amount.
        /// </summary>
        [JsonProperty(PropertyName = "requestedAmount")]
        public string RequestedAmount { get; set; }

        /// <summary>
        /// The authorized amount. May not match the requested amount in the event of a
        /// partial auth.
        /// </summary>
        [JsonProperty(PropertyName = "authorizedAmount")]
        public string AuthorizedAmount { get; set; }

        /// <summary>
        /// The remaining balance on the payment method.
        /// </summary>
        [JsonProperty(PropertyName = "remainingBalance")]
        public string RemainingBalance { get; set; }

        /// <summary>
        /// The tip amount.
        /// </summary>
        [JsonProperty(PropertyName = "tipAmount")]
        public string TipAmount { get; set; }

        /// <summary>
        /// The tax amount.
        /// </summary>
        [JsonProperty(PropertyName = "taxAmount")]
        public string TaxAmount { get; set; }

        /// <summary>
        /// The cash back amount the customer requested during the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "requestedCashBackAmount")]
        public string RequestedCashBackAmount { get; set; }

        /// <summary>
        /// The amount of cash back authorized by the gateway. This amount will be the entire
        /// amount requested, or zero.
        /// </summary>
        [JsonProperty(PropertyName = "authorizedCashBackAmount")]
        public string AuthorizedCashBackAmount { get; set; }

        /// <summary>
        /// That the transaction has met the standard criteria for confirmation on the
        /// network. (For example, 6 confirmations for level one bitcoin.)
        /// </summary>
        [JsonProperty(PropertyName = "confirmed")]
        public bool Confirmed { get; set; }

        /// <summary>
        /// The amount submitted to the blockchain.
        /// </summary>
        [JsonProperty(PropertyName = "cryptoAuthorizedAmount")]
        public string CryptoAuthorizedAmount { get; set; }

        /// <summary>
        /// The network level fee assessed for the transaction denominated in
        /// cryptocurrency. This fee goes to channel operators and crypto miners, not
        /// BlockChyp.
        /// </summary>
        [JsonProperty(PropertyName = "cryptoNetworkFee")]
        public string CryptoNetworkFee { get; set; }

        /// <summary>
        /// The three letter cryptocurrency code used for the transactions.
        /// </summary>
        [JsonProperty(PropertyName = "cryptocurrency")]
        public string Cryptocurrency { get; set; }

        /// <summary>
        /// Whether or not the transaction was processed on the level one or level two
        /// network.
        /// </summary>
        [JsonProperty(PropertyName = "cryptoNetwork")]
        public string CryptoNetwork { get; set; }

        /// <summary>
        /// The address on the crypto network the transaction was sent to.
        /// </summary>
        [JsonProperty(PropertyName = "cryptoReceiveAddress")]
        public string CryptoReceiveAddress { get; set; }

        /// <summary>
        /// Hash or other identifier that identifies the block on the cryptocurrency
        /// network, if available or relevant.
        /// </summary>
        [JsonProperty(PropertyName = "cryptoBlock")]
        public string CryptoBlock { get; set; }

        /// <summary>
        /// Hash or other transaction identifier that identifies the transaction on the
        /// cryptocurrency network, if available or relevant.
        /// </summary>
        [JsonProperty(PropertyName = "cryptoTransactionId")]
        public string CryptoTransactionId { get; set; }

        /// <summary>
        /// The payment request URI used for the transaction, if available.
        /// </summary>
        [JsonProperty(PropertyName = "cryptoPaymentRequest")]
        public string CryptoPaymentRequest { get; set; }

        /// <summary>
        /// Used for additional status information related to crypto transactions.
        /// </summary>
        [JsonProperty(PropertyName = "cryptoStatus")]
        public string CryptoStatus { get; set; }

        /// <summary>
        /// The payment token, if the payment was enrolled in the vault.
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        /// <summary>
        /// The entry method for the transaction (CHIP, MSR, KEYED, etc).
        /// </summary>
        [JsonProperty(PropertyName = "entryMethod")]
        public string EntryMethod { get; set; }

        /// <summary>
        /// The card brand (VISA, MC, AMEX, etc).
        /// </summary>
        [JsonProperty(PropertyName = "paymentType")]
        public string PaymentType { get; set; }

        /// <summary>
        /// The masked primary account number.
        /// </summary>
        [JsonProperty(PropertyName = "maskedPan")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// The BlockChyp public key if the user presented a BlockChyp payment card.
        /// </summary>
        [JsonProperty(PropertyName = "publicKey")]
        public string PublicKey { get; set; }

        /// <summary>
        /// That the transaction did something that would put the system in PCI scope.
        /// </summary>
        [JsonProperty(PropertyName = "ScopeAlert")]
        public bool ScopeAlert { get; set; }

        /// <summary>
        /// The cardholder name.
        /// </summary>
        [JsonProperty(PropertyName = "cardHolder")]
        public string CardHolder { get; set; }

        /// <summary>
        /// The card expiration month in MM format.
        /// </summary>
        [JsonProperty(PropertyName = "expMonth")]
        public string ExpMonth { get; set; }

        /// <summary>
        /// The card expiration year in YY format.
        /// </summary>
        [JsonProperty(PropertyName = "expYear")]
        public string ExpYear { get; set; }

        /// <summary>
        /// Address verification results if address information was submitted.
        /// </summary>
        [JsonProperty(PropertyName = "avsResponse")]
        public AvsResponse AvsResponse { get; set; }

        /// <summary>
        /// Suggested receipt fields.
        /// </summary>
        [JsonProperty(PropertyName = "receiptSuggestions")]
        public ReceiptSuggestions ReceiptSuggestions { get; set; }

        /// <summary>
        /// Customer data, if any. Preserved for reverse compatibility.
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Customer data, if any.
        /// </summary>
        [JsonProperty(PropertyName = "customers")]
        public List<Customer> Customers { get; set; }

        /// <summary>
        /// The hex encoded signature data.
        /// </summary>
        [JsonProperty(PropertyName = "sigFile")]
        public string SigFile { get; set; }

        /// <summary>
        /// Card BIN ranges can be whitelisted so that they are read instead of being
        /// processed directly. This is useful for integration with legacy gift card
        /// systems.
        /// </summary>
        [JsonProperty(PropertyName = "whiteListedCard")]
        public WhiteListedCard WhiteListedCard { get; set; }

        /// <summary>
        /// That the transaction was flagged for store and forward due to network problems.
        /// </summary>
        [JsonProperty(PropertyName = "storeAndForward")]
        public bool StoreAndForward { get; set; }

        /// <summary>
        /// The current status of a transaction.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
