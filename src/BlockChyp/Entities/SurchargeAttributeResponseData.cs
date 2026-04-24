// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models the surcharge attributes included in a surcharge review response.
    /// </summary>
    public class SurchargeAttributeResponseData : BaseEntity
    {
        /// <summary>
        /// The total amount including surcharge.
        /// </summary>
        [JsonProperty(PropertyName = "totalWithSurchargeAmount")]
        public string TotalWithSurchargeAmount { get; set; }

        /// <summary>
        /// If the surcharge review was successful.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// The type of the response.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The surcharge percentage.
        /// </summary>
        [JsonProperty(PropertyName = "surchargePercent")]
        public string SurchargePercent { get; set; }

        /// <summary>
        /// The surcharge amount.
        /// </summary>
        [JsonProperty(PropertyName = "surchargeAmount")]
        public string SurchargeAmount { get; set; }

        /// <summary>
        /// If the transaction is exempt from surcharges.
        /// </summary>
        [JsonProperty(PropertyName = "surchargeExempt")]
        public bool SurchargeExempt { get; set; }

        /// <summary>
        /// The type of card.
        /// </summary>
        [JsonProperty(PropertyName = "cardType")]
        public string CardType { get; set; }

        /// <summary>
        /// The card token.
        /// </summary>
        [JsonProperty(PropertyName = "cardToken")]
        public string CardToken { get; set; }

        /// <summary>
        /// The card brand.
        /// </summary>
        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }

        /// <summary>
        /// The bank identification number.
        /// </summary>
        [JsonProperty(PropertyName = "bin")]
        public string Bin { get; set; }

        /// <summary>
        /// The commercial card indicator.
        /// </summary>
        [JsonProperty(PropertyName = "commercialIndicator")]
        public string CommercialIndicator { get; set; }

        /// <summary>
        /// If the card is commercial.
        /// </summary>
        [JsonProperty(PropertyName = "isCommercial")]
        public bool IsCommercial { get; set; }

        /// <summary>
        /// If the card is Durbin-regulated (US debit).
        /// </summary>
        [JsonProperty(PropertyName = "isRegulated")]
        public bool IsRegulated { get; set; }

        /// <summary>
        /// The reason for the exemption.
        /// </summary>
        [JsonProperty(PropertyName = "exemptionReason")]
        public string ExemptionReason { get; set; }

        /// <summary>
        /// The debit fee amount.
        /// </summary>
        [JsonProperty(PropertyName = "debitFeeAmount")]
        public string DebitFeeAmount { get; set; }

        /// <summary>
        /// The disclosure statement.
        /// </summary>
        [JsonProperty(PropertyName = "disclosure")]
        public string Disclosure { get; set; }

        /// <summary>
        /// The debit card category.
        /// </summary>
        [JsonProperty(PropertyName = "debitCategory")]
        public string DebitCategory { get; set; }

        /// <summary>
        /// The country where the card was issued.
        /// </summary>
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Only included if state was sent in request OR derived from ZIP code.
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// The unique identifier for the pricing response.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// The expiration date of the card.
        /// </summary>
        [JsonProperty(PropertyName = "expirationDate")]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// When surcharging is enabled AND state is 'CO' (Colorado-specific statutory
        /// language).
        /// </summary>
        [JsonProperty(PropertyName = "disclosureAdditional")]
        public string DisclosureAdditional { get; set; }

        /// <summary>
        /// The cardholder information.
        /// </summary>
        [JsonProperty(PropertyName = "cardholderInfo")]
        public string CardholderInfo { get; set; }
    }
}
