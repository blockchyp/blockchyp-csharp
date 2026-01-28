// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a request for merchant information.
    /// </summary>
    public class GetMerchantsRequest : BaseEntity, ITimeoutRequest
    {
        /// <summary>
        /// The request timeout in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }

        /// <summary>
        /// Whether or not to return test or live merchants.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// Max to be returned in a single page. Defaults to the system max of 250.
        /// </summary>
        [JsonProperty(PropertyName = "maxResults")]
        public int MaxResults { get; set; }

        /// <summary>
        /// Starting index for paged results. Defaults to zero.
        /// </summary>
        [JsonProperty(PropertyName = "startIndex")]
        public int StartIndex { get; set; }
    }
}
