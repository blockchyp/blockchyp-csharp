// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// The response to a basic API health check. If the security context permits it, the
    /// response may also include the public key of the current merchant.
    /// </summary>
    public class HeartbeatResponse : BaseEntity, IAbstractAcknowledgement
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
        /// The timestamp of the heartbeat.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// The public key of the clockchain. This is blockchain stuff that you don't really
        /// need to worry about. It is a base 58 encoded and compressed eliptic curve public
        /// key. For the production clockchain, this will always be:
        /// '3cuhsckVUd9HzMjbdUSW17aY5kCcm1d6YAphJMUwmtXRj7WLyU'.
        /// </summary>
        [JsonProperty(PropertyName = "clockchain")]
        public string Clockchain { get; set; }

        /// <summary>
        /// The hash of the last tick block.
        /// </summary>
        [JsonProperty(PropertyName = "latestTick")]
        public string LatestTick { get; set; }

        /// <summary>
        /// The public key for the merchant's blockchain.
        /// </summary>
        [JsonProperty(PropertyName = "merchantPk")]
        public string MerchantPublicKey { get; set; }
    }
}
