// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a request to retrieve detailed partner statement information.
    /// </summary>
    public class PartnerStatementDetailRequest : BaseEntity, ITimeoutRequest
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
        /// Optional start date filter for batch history.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// That the full merchant statement should be included in the response.
        /// </summary>
        [JsonProperty(PropertyName = "includeMerchantStatement")]
        public bool IncludeMerchantStatement { get; set; }

        /// <summary>
        /// That interchange and all other related cost details should be returned.
        /// </summary>
        [JsonProperty(PropertyName = "includeInterchange")]
        public bool IncludeInterchange { get; set; }
    }
}
