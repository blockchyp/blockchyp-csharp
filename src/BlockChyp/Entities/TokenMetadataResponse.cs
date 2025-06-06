// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a payment token metadata response.
    /// </summary>
    public class TokenMetadataResponse : BaseEntity, IAbstractAcknowledgement
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
        /// The token metadata for a given query.
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public CustomerToken Token { get; set; }

        /// <summary>
        /// Details about a payment card derived from its BIN/IIN.
        /// </summary>
        [JsonProperty(PropertyName = "cardMetadata")]
        public CardMetadata CardMetadata { get; set; }
    }
}
