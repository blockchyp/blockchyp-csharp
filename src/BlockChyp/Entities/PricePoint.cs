// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a single set of pricing values for a pricing policy.
    /// </summary>
    public class PricePoint : BaseEntity
    {
        /// <summary>
        /// The string representation of a per transaction minimum.
        /// </summary>
        [JsonProperty(PropertyName = "buyRate")]
        public string BuyRate { get; set; }

        /// <summary>
        /// The string representation of the current fee per transaction.
        /// </summary>
        [JsonProperty(PropertyName = "current")]
        public string Current { get; set; }

        /// <summary>
        /// The string representation of a per transaction gouge limit.
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public string Limit { get; set; }
    }
}
