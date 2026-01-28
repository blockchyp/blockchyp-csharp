// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// An item level discount for transaction display. Discounts never combine.
    /// </summary>
    public class TransactionDisplayDiscount : BaseEntity
    {
        /// <summary>
        /// The discount description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The amount of the discount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }
    }
}
