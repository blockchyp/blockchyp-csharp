// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Essential information about a payment card derived from its BIN/IIN.
    /// </summary>
    public class CardMetadata : BaseEntity
    {
        /// <summary>
        /// The brand or network of the card (e.g., Visa, Mastercard, Amex).
        /// </summary>
        [JsonProperty(PropertyName = "cardBrand")]
        public string CardBrand { get; set; }

        /// <summary>
        /// The name of the financial institution that issued the card.
        /// </summary>
        [JsonProperty(PropertyName = "issuerName")]
        public string IssuerName { get; set; }

        /// <summary>
        /// Whether the card supports Level 3 processing for detailed transaction data.
        /// </summary>
        [JsonProperty(PropertyName = "l3")]
        public bool L3 { get; set; }

        /// <summary>
        /// Whether the card supports Level 2 processing for additional transaction data.
        /// </summary>
        [JsonProperty(PropertyName = "l2")]
        public bool L2 { get; set; }

        /// <summary>
        /// The general category or type of the card product.
        /// </summary>
        [JsonProperty(PropertyName = "productType")]
        public string ProductType { get; set; }

        /// <summary>
        /// The specific name or designation of the card product.
        /// </summary>
        [JsonProperty(PropertyName = "productName")]
        public string ProductName { get; set; }

        /// <summary>
        /// Whether the card is an Electronic Benefit Transfer (EBT) card.
        /// </summary>
        [JsonProperty(PropertyName = "ebt")]
        public bool Ebt { get; set; }

        /// <summary>
        /// Whether the card is a debit card.
        /// </summary>
        [JsonProperty(PropertyName = "debit")]
        public bool Debit { get; set; }

        /// <summary>
        /// Whether the card is a healthcare-specific payment card.
        /// </summary>
        [JsonProperty(PropertyName = "healthcare")]
        public bool Healthcare { get; set; }

        /// <summary>
        /// Whether the card is a prepaid card.
        /// </summary>
        [JsonProperty(PropertyName = "prepaid")]
        public bool Prepaid { get; set; }

        /// <summary>
        /// The geographical region associated with the card's issuer.
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        /// <summary>
        /// The country associated with the card's issuer.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }
}
