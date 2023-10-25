// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class AggregateBillingLineItem : BaseEntity
    {
        /// <summary>
        /// The line item identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Provides a basic description of the line item.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// That a line item has nested information.
        /// </summary>
        [JsonProperty(PropertyName = "expandable")]
        public bool Expandable { get; set; }

        /// <summary>
        /// The total is a negative number.
        /// </summary>
        [JsonProperty(PropertyName = "negative")]
        public bool Negative { get; set; }

        /// <summary>
        /// The total for the line item.
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public float Total { get; set; }

        /// <summary>
        /// The currency formatted total for the line item.
        /// </summary>
        [JsonProperty(PropertyName = "totalFormatted")]
        public string TotalFormatted { get; set; }

        /// <summary>
        /// The range of count based fees charged for the given line item.
        /// </summary>
        [JsonProperty(PropertyName = "perTranFeeRange")]
        public AggregateBillingLineItemStats PerTranFeeRange { get; set; }

        /// <summary>
        /// The range of percentage based fees charged for the given line item.
        /// </summary>
        [JsonProperty(PropertyName = "transactionPercentageRange")]
        public AggregateBillingLineItemStats TransactionPercentageRange { get; set; }

        /// <summary>
        /// Encapsulated drill down or detail lines.
        /// </summary>
        [JsonProperty(PropertyName = "detailLines")]
        public List<AggregateBillingLineItem> DetailLines { get; set; }
    }
}
