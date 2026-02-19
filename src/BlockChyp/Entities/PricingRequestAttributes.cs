// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models the attributes for a pricing request.
    /// </summary>
    public class PricingRequestAttributes : BaseEntity
    {
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
        /// The merchant identifier.
        /// </summary>
        [JsonProperty(PropertyName = "merchantIdentifier")]
        public string MerchantIdentifier { get; set; }

        /// <summary>
        /// The transaction amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public float Amount { get; set; }

        /// <summary>
        /// The country code.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// The postal code.
        /// </summary>
        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The state or province.
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// Merchant settings for the pricing request.
        /// </summary>
        [JsonProperty(PropertyName = "merchantSettings")]
        public PricingMerchantSettings MerchantSettings { get; set; }
    }
}
