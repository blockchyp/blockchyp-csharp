// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// The response to a balance request.
    /// </summary>
    public class BalanceResponse : BaseEntity, IAbstractAcknowledgement, ICoreResponse, IPaymentMethodResponse
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
        /// The ECC signature of the response. Can be used to ensure that it was signed by the
        /// terminal and detect man-in-the middle attacks.
        /// </summary>
        [JsonProperty(PropertyName = "sig")]
        public string Sig { get; set; }

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
        /// Remaining balance on the payment method.
        /// </summary>
        [JsonProperty(PropertyName = "remainingBalance")]
        public string RemainingBalance { get; set; }
    }
}
