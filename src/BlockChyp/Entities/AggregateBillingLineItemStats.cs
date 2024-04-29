// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models statistics for low level aggregation line items.
    /// </summary>
    public class AggregateBillingLineItemStats : BaseEntity
    {
        /// <summary>
        /// The min value in the set.
        /// </summary>
        [JsonProperty(PropertyName = "min")]
        public string Min { get; set; }

        /// <summary>
        /// The avg value in the set.
        /// </summary>
        [JsonProperty(PropertyName = "avg")]
        public string Avg { get; set; }

        /// <summary>
        /// The max value in the set.
        /// </summary>
        [JsonProperty(PropertyName = "max")]
        public string Max { get; set; }
    }
}
