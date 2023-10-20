// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class PartnerStatementAdjustment : BaseEntity
    {
        /// <summary>
        /// The adjustment id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The date and time the disbursement was posted to the account.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// A description of the adjustment.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The amount in floating point format.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public float Amount { get; set; }

        /// <summary>
        /// The currency formatted form of amount.
        /// </summary>
        [JsonProperty(PropertyName = "amountFormatted")]
        public string AmountFormatted { get; set; }
    }
}
