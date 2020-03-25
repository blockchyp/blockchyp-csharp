// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a customer token.
    /// </summary>
    public class CustomerToken : BaseEntity
    {
        /// <summary>
        /// BlockChyp assigned customer id.
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        /// <summary>
        /// Masked primary account number.
        /// </summary>
        [JsonProperty(PropertyName = "maskedPan")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// Expiration month.
        /// </summary>
        [JsonProperty(PropertyName = "expiryMonth")]
        public string ExpiryMonth { get; set; }

        /// <summary>
        /// Expiration month.
        /// </summary>
        [JsonProperty(PropertyName = "expiryYear")]
        public string ExpiryYear { get; set; }

        /// <summary>
        /// Payment type.
        /// </summary>
        [JsonProperty(PropertyName = "paymentType")]
        public string PaymentType { get; set; }
    }
}
