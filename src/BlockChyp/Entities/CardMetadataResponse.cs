// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// The response to a card metadata request.
    /// </summary>
    public class CardMetadataResponse : BaseEntity, IAbstractAcknowledgement, IPaymentMethodResponse
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
        /// The card brand (VISA, MC, AMEX, DEBIT, etc).
        /// </summary>
        [JsonProperty(PropertyName = "paymentType")]
        public string PaymentType { get; set; }

        /// <summary>
        /// Provides network level detail on how a transaction was routed, especially for
        /// debit transactions.
        /// </summary>
        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        /// <summary>
        /// Identifies the card association based on bin number. Used primarily used to
        /// indicate the major logo on a card, even when debit transactions are routed on a
        /// different network.
        /// </summary>
        [JsonProperty(PropertyName = "logo")]
        public string Logo { get; set; }

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
        /// Details about a payment card derived from its BIN/IIN.
        /// </summary>
        [JsonProperty(PropertyName = "cardMetadata")]
        public CardMetadata CardMetadata { get; set; }
    }
}
