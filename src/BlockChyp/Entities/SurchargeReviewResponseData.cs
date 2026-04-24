// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models the data included in a surcharge review response.
    /// </summary>
    public class SurchargeReviewResponseData : BaseEntity
    {
        /// <summary>
        /// The type of the response.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The attributes of the response.
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public SurchargeAttributeResponseData Attributes { get; set; }
    }
}
