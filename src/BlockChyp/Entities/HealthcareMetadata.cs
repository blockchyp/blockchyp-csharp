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
    /// Fields for HSA/FSA transactions.
    /// </summary>
    public class HealthcareMetadata : BaseEntity
    {
        /// <summary>
        /// A list of healthcare categories in the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "types")]
        public List<HealthcareGroup> Types { get; set; }

        /// <summary>
        /// That the purchased items were verified against an Inventory Information
        /// Approval System (IIAS).
        /// </summary>
        [JsonProperty(PropertyName = "iiasVerified")]
        public bool IiasVerified { get; set; }

        /// <summary>
        /// That the transaction is exempt from IIAS verification.
        /// </summary>
        [JsonProperty(PropertyName = "iiasExempt")]
        public bool IiasExempt { get; set; }
    }
}
