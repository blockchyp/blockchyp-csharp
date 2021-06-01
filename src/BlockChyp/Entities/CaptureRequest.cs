// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// The information needed to capture a preauth.
    /// </summary>
    public class CaptureRequest : BaseEntity, ICoreRequest, IPreviousTransaction, IRequestAmount, ISubtotals
    {
        /// <summary>
        /// A user-assigned reference that can be used to recall or reverse transactions.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// Defers the response to the transaction and returns immediately. Callers
        /// should retrive the transaction result using the Transaction Status API.
        /// </summary>
        [JsonProperty(PropertyName = "async")]
        public bool Async { get; set; }

        /// <summary>
        /// Adds the transaction to the queue and returns immediately. Callers should
        /// retrive the transaction result using the Transaction Status API.
        /// </summary>
        [JsonProperty(PropertyName = "queue")]
        public bool Queue { get; set; }

        /// <summary>
        /// Whether or not the request should block until all cards have been removed from
        /// the card reader.
        /// </summary>
        [JsonProperty(PropertyName = "waitForRemovedCard")]
        public bool WaitForRemovedCard { get; set; }

        /// <summary>
        /// Override any in-progress transactions.
        /// </summary>
        [JsonProperty(PropertyName = "force")]
        public bool Force { get; set; }

        /// <summary>
        /// An identifier from an external point of sale system.
        /// </summary>
        [JsonProperty(PropertyName = "orderRef")]
        public string OrderRef { get; set; }

        /// <summary>
        /// The settlement account for merchants with split settlements.
        /// </summary>
        [JsonProperty(PropertyName = "destinationAccount")]
        public string DestinationAccount { get; set; }

        /// <summary>
        /// Whether or not to route transaction to the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// The request timeout in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }

        /// <summary>
        /// The ID of the previous transaction being referenced.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// The transaction currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The requested amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// That the request is tax exempt. Only required for tax exempt level 2 processing.
        /// </summary>
        [JsonProperty(PropertyName = "taxExempt")]
        public bool TaxExempt { get; set; }

        /// <summary>
        /// A flag to add a surcharge to the transaction to cover credit card fees, if
        /// permitted.
        /// </summary>
        [JsonProperty(PropertyName = "surcharge")]
        public bool Surcharge { get; set; }

        /// <summary>
        /// A flag that applies a discount to negate the surcharge for debit transactions or
        /// other surcharge ineligible payment methods.
        /// </summary>
        [JsonProperty(PropertyName = "cashDiscount")]
        public bool CashDiscount { get; set; }

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
        /// The amount of cash back requested.
        /// </summary>
        [JsonProperty(PropertyName = "cashBackAmount")]
        public string CashBackAmount { get; set; }

        /// <summary>
        /// The amount of the transaction that should be charged to an FSA card. This amount
        /// may be less than the transaction total, in which case only this amount will be
        /// charged if an FSA card is presented. If the FSA amount is paid on an FSA card, then
        /// the FSA amount authorized will be indicated on the response.
        /// </summary>
        [JsonProperty(PropertyName = "fsaEligibleAmount")]
        public string FsaEligibleAmount { get; set; }

        /// <summary>
        /// The amount of the transaction that should be charged to an HSA card.
        /// </summary>
        [JsonProperty(PropertyName = "hsaEligibleAmount")]
        public string HsaEligibleAmount { get; set; }

        /// <summary>
        /// The amount of the transaction that should be charged to an EBT card.
        /// </summary>
        [JsonProperty(PropertyName = "ebtEligibleAmount")]
        public string EbtEligibleAmount { get; set; }
    }
}
