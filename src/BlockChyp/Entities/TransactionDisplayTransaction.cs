// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// The items to display on a terminal.
    /// </summary>
    public class TransactionDisplayTransaction : BaseEntity
    {
        /// <summary>
        /// The subtotal to display.
        /// </summary>
        [JsonProperty(PropertyName = "subtotal")]
        public string Subtotal { get; set; }

        /// <summary>
        /// The tax to display.
        /// </summary>
        [JsonProperty(PropertyName = "tax")]
        public string Tax { get; set; }

        /// <summary>
        /// The total to display.
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }

        /// <summary>
        /// An item to display. Can be overwritten or appended, based on the request type.
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public List<TransactionDisplayItem> Items { get; set; }
    }
}
