// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Computes the cash discount for a cash discount if enabled.
    /// </summary>
    public class CashDiscountRequest : BaseEntity, ICoreRequest
    {
        /// <summary>
        /// The transaction reference string assigned to the transaction request. If no
        /// transaction ref was assiged on the request, then the gateway will randomly
        /// generate one.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

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
    }
}