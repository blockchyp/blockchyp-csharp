// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models merchant settings and configuration.
    /// </summary>
    public class MerchantSettings : BaseEntity
    {
        /// <summary>
        /// The merchant account identifier.
        /// </summary>
        [JsonProperty(PropertyName = "account")]
        public string Account { get; set; }

        /// <summary>
        /// The gateway identifier.
        /// </summary>
        [JsonProperty(PropertyName = "gateway")]
        public string Gateway { get; set; }

        /// <summary>
        /// Whether surcharging is enabled for the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "surchargingEnabled")]
        public bool SurchargingEnabled { get; set; }

        /// <summary>
        /// The custom surcharge percentage, if applicable.
        /// </summary>
        [JsonProperty(PropertyName = "customSurchargePercent")]
        public float CustomSurchargePercent { get; set; }

        /// <summary>
        /// If reduced rate pricing is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "reducedRate")]
        public bool ReducedRate { get; set; }

        /// <summary>
        /// If inverse pricing is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "inversePricingEnabled")]
        public bool InversePricingEnabled { get; set; }

        /// <summary>
        /// The credit discount rate, if applicable.
        /// </summary>
        [JsonProperty(PropertyName = "creditDiscountRate")]
        public float CreditDiscountRate { get; set; }

        /// <summary>
        /// The acquiring solution identifier.
        /// </summary>
        [JsonProperty(PropertyName = "acquiringSolution")]
        public string AcquiringSolution { get; set; }

        /// <summary>
        /// Whether the merchant accepts debit cards.
        /// </summary>
        [JsonProperty(PropertyName = "acceptDebit")]
        public bool AcceptDebit { get; set; }

        /// <summary>
        /// State check settings for the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "stateCheckSettings")]
        public StateCheckSettings StateCheckSettings { get; set; }
    }
}
