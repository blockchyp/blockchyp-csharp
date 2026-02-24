// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models settings related to state checks for a merchant.
    /// </summary>
    public class StateCheckSettings : BaseEntity
    {
        /// <summary>
        /// If state checks are enabled for the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// The list of states that are exempt from surcharges.
        /// </summary>
        [JsonProperty(PropertyName = "surchargeExemptStates")]
        public List<string> SurchargeExemptStates { get; set; }
    }
}
