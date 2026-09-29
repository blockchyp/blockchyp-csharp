// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a surcharge review request.
    /// </summary>
    public class SurchargeReviewRequest : BaseEntity, ITimeoutRequest
    {
        /// <summary>
        /// The request timeout in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }

        /// <summary>
        /// Whether or not to route transaction to the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// The card number for the pricing request.
        /// </summary>
        [JsonProperty(PropertyName = "cardNumber")]
        public string CardNumber { get; set; }

        /// <summary>
        /// The payment token.
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        /// <summary>
        /// The transaction amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The surcharge rate.
        /// </summary>
        [JsonProperty(PropertyName = "surchargeRate")]
        public string SurchargeRate { get; set; }

        /// <summary>
        /// The debit transaction fee.
        /// </summary>
        [JsonProperty(PropertyName = "debitTransFee")]
        public string DebitTransFee { get; set; }

        /// <summary>
        /// The debit discount rate.
        /// </summary>
        [JsonProperty(PropertyName = "debitDiscountRate")]
        public string DebitDiscountRate { get; set; }

        /// <summary>
        /// The surcharge policy.
        /// </summary>
        [JsonProperty(PropertyName = "surchargePolicy")]
        public string SurchargePolicy { get; set; }

        /// <summary>
        /// The list of excluded merchant states.
        /// </summary>
        [JsonProperty(PropertyName = "excludedMerchantStates")]
        public List<string> ExcludedMerchantStates { get; set; }

        /// <summary>
        /// The zip code.
        /// </summary>
        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }

        /// <summary>
        /// The state or province.
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// If foreign cards are exempt.
        /// </summary>
        [JsonProperty(PropertyName = "exemptForeignCards")]
        public bool ExemptForeignCards { get; set; }

        /// <summary>
        /// The surcharging mode.
        /// </summary>
        [JsonProperty(PropertyName = "surchargingMode")]
        public string SurchargingMode { get; set; }

        /// <summary>
        /// The pricing plan.
        /// </summary>
        [JsonProperty(PropertyName = "pricingPlan")]
        public string PricingPlan { get; set; }

        /// <summary>
        /// The Stax merchant UUID for cross-system tracing.
        /// </summary>
        [JsonProperty(PropertyName = "staxMerchantId")]
        public string StaxMerchantId { get; set; }

        /// <summary>
        /// The Stax transaction UUID for cross-system tracing.
        /// </summary>
        [JsonProperty(PropertyName = "staxTransactionId")]
        public string StaxTransactionId { get; set; }
    }
}
