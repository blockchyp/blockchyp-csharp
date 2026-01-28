// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Merchant api credential data.
    /// </summary>
    public class MerchantCredentialGenerationResponse : BaseEntity, IAbstractAcknowledgement
    {
        /// <summary>
        /// Whether or not the request succeeded.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// The error, if an error occurred.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        /// <summary>
        /// A narrative description of the transaction result.
        /// </summary>
        [JsonProperty(PropertyName = "responseDescription")]
        public string ResponseDescription { get; set; }

        /// <summary>
        /// The merchant api key.
        /// </summary>
        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// The merchant bearer token.
        /// </summary>
        [JsonProperty(PropertyName = "bearerToken")]
        public string BearerToken { get; set; }

        /// <summary>
        /// The merchant signing key.
        /// </summary>
        [JsonProperty(PropertyName = "signingKey")]
        public string SigningKey { get; set; }

        /// <summary>
        /// The tokenizing key.
        /// </summary>
        [JsonProperty(PropertyName = "tokenizingKey")]
        public string TokenizingKey { get; set; }
    }
}
