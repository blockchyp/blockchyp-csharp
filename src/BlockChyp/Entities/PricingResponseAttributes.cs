// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models pricing response data for new handler for pricing api responses.
    /// </summary>
    public class PricingResponseAttributes : BaseEntity
    {
        /// <summary>
        /// The surcharge percentage.
        /// </summary>
        [JsonProperty(PropertyName = "surchargePercent")]
        public float SurchargePercent { get; set; }

        /// <summary>
        /// The surcharge amount.
        /// </summary>
        [JsonProperty(PropertyName = "surchargeAmount")]
        public float SurchargeAmount { get; set; }

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
        [JsonProperty(PropertyName = "countryIssued")]
        public string CountryIssued { get; set; }

        /// <summary>
        /// The unique identifier for the pricing response.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
    }
}
