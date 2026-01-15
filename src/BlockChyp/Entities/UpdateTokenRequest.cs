// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Updates a payment token.
    /// </summary>
    public class UpdateTokenRequest : BaseEntity, ITimeoutRequest
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
        /// The token to update.
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        /// <summary>
        /// Bank account holder type (personal or business).
        /// </summary>
        [JsonProperty(PropertyName = "accountHolderType")]
        public string AccountHolderType { get; set; }

        /// <summary>
        /// Bank account type (checking or saving).
        /// </summary>
        [JsonProperty(PropertyName = "accountType")]
        public string AccountType { get; set; }

        /// <summary>
        /// Bank name.
        /// </summary>
        [JsonProperty(PropertyName = "bankName")]
        public string BankName { get; set; }

        /// <summary>
        /// Card holder name.
        /// </summary>
        [JsonProperty(PropertyName = "cardHolderName")]
        public string CardHolderName { get; set; }

        /// <summary>
        /// Expiry month.
        /// </summary>
        [JsonProperty(PropertyName = "expiryMonth")]
        public string ExpiryMonth { get; set; }

        /// <summary>
        /// Expiry year.
        /// </summary>
        [JsonProperty(PropertyName = "expiryYear")]
        public string ExpiryYear { get; set; }

        /// <summary>
        /// Address.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Postal code.
        /// </summary>
        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }
    }
}
