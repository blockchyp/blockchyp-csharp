// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a single invoice or merchant statement line item.
    /// </summary>
    public class InvoiceLineItem : BaseEntity
    {
        /// <summary>
        /// The line item id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of line item.
        /// </summary>
        [JsonProperty(PropertyName = "lineType")]
        public string LineType { get; set; }

        /// <summary>
        /// The product id for standard invoices.
        /// </summary>
        [JsonProperty(PropertyName = "productId")]
        public string ProductId { get; set; }

        /// <summary>
        /// The quantity associated with the line item.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// The description associated with the line item.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// An alternate explanation.
        /// </summary>
        [JsonProperty(PropertyName = "explanation")]
        public string Explanation { get; set; }

        /// <summary>
        /// The transaction count associated with any transaction based fees.
        /// </summary>
        [JsonProperty(PropertyName = "transactionCount")]
        public long TransactionCount { get; set; }

        /// <summary>
        /// The transaction volume associated with any fees.
        /// </summary>
        [JsonProperty(PropertyName = "volume")]
        public float Volume { get; set; }

        /// <summary>
        /// The string formatted volume.
        /// </summary>
        [JsonProperty(PropertyName = "volumeFormatted")]
        public string VolumeFormatted { get; set; }

        /// <summary>
        /// The per transaction fee.
        /// </summary>
        [JsonProperty(PropertyName = "perTransactionFee")]
        public float PerTransactionFee { get; set; }

        /// <summary>
        /// The string formatted per transaction fee.
        /// </summary>
        [JsonProperty(PropertyName = "perTransactionFeeFormatted")]
        public string PerTransactionFeeFormatted { get; set; }

        /// <summary>
        /// The percentage (as floating point ratio) fee assessed on volume.
        /// </summary>
        [JsonProperty(PropertyName = "transactionPercentage")]
        public float TransactionPercentage { get; set; }

        /// <summary>
        /// The string formatted transaction fee percentage.
        /// </summary>
        [JsonProperty(PropertyName = "transactionPercentageFormatted")]
        public string TransactionPercentageFormatted { get; set; }

        /// <summary>
        /// The quantity price associated.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public float Price { get; set; }

        /// <summary>
        /// The string formatted price associated with a conventional line item.
        /// </summary>
        [JsonProperty(PropertyName = "priceFormatted")]
        public string PriceFormatted { get; set; }

        /// <summary>
        /// The extended price .
        /// </summary>
        [JsonProperty(PropertyName = "priceExtended")]
        public float PriceExtended { get; set; }

        /// <summary>
        /// The string formatted extended price.
        /// </summary>
        [JsonProperty(PropertyName = "priceExtendedFormatted")]
        public string PriceExtendedFormatted { get; set; }

        /// <summary>
        /// The list of nested line items, if any.
        /// </summary>
        [JsonProperty(PropertyName = "lineItems")]
        public List<InvoiceLineItem> LineItems { get; set; }
    }
}
