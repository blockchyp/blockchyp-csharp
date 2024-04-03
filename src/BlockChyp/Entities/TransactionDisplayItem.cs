// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// An item category in a transaction display. Groups combine if their descriptions
    /// match. Calculated subtotal amounts are rounded to two decimal places of precision.
    /// Quantity is a floating point number that is not rounded at all.
    /// </summary>
    public class TransactionDisplayItem : BaseEntity
    {
        /// <summary>
        /// A unique value identifying the item. This is not required, but recommended
        /// since it is required to update or delete line items.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// A description of the line item.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The price of the line item.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        /// <summary>
        /// The quantity of the line item.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public float Quantity { get; set; }

        /// <summary>
        /// An item category in a transaction display. Groups combine if their
        /// descriptions match. Calculated subtotal amounts are rounded to two decimal
        /// places of precision. Quantity is a floating point number that is not rounded at
        /// all.
        /// </summary>
        [JsonProperty(PropertyName = "extended")]
        public string Extended { get; set; }

        /// <summary>
        /// An alphanumeric code for units of measurement as used in international trade.
        /// </summary>
        [JsonProperty(PropertyName = "unitCode")]
        public string UnitCode { get; set; }

        /// <summary>
        /// An international description code of the item.
        /// </summary>
        [JsonProperty(PropertyName = "commodityCode")]
        public string CommodityCode { get; set; }

        /// <summary>
        /// A merchant-defined description code of the item.
        /// </summary>
        [JsonProperty(PropertyName = "productCode")]
        public string ProductCode { get; set; }

        /// <summary>
        /// Are displayed under their corresponding item.
        /// </summary>
        [JsonProperty(PropertyName = "discounts")]
        public List<TransactionDisplayDiscount> Discounts { get; set; }
    }
}
