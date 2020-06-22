// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using System;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models high level information about a single batch.
    /// </summary>
    public class BatchSummary : BaseEntity
    {
        /// <summary>
        /// Batch identifier.
        /// </summary>
        [JsonProperty(PropertyName = "batchId")]
        public string BatchId { get; set; }

        /// <summary>
        /// Entry method for the batch, if any.
        /// </summary>
        [JsonProperty(PropertyName = "entryMethod")]
        public string EntryMethod { get; set; }

        /// <summary>
        /// Merchant deposit account into which proceeds should be deposited.
        /// </summary>
        [JsonProperty(PropertyName = "destinationAccountId")]
        public string DestinationAccountId { get; set; }

        /// <summary>
        /// The new captured amount.
        /// </summary>
        [JsonProperty(PropertyName = "capturedAmount")]
        public string CapturedAmount { get; set; }

        /// <summary>
        /// The amount of preauths opened during the batch that have not been captured.
        /// </summary>
        [JsonProperty(PropertyName = "openPreauths")]
        public string OpenPreauths { get; set; }

        /// <summary>
        /// The currency the batch was settled in.
        /// </summary>
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Flag indicating whether or not the batch is open.
        /// </summary>
        [JsonProperty(PropertyName = "open")]
        public bool Open { get; set; }

        /// <summary>
        /// Date and time of the first transaction for this batch.
        /// </summary>
        [JsonProperty(PropertyName = "openDate")]
        public DateTime? OpenDate { get; set; }

        /// <summary>
        /// Date and time the batch was closed.
        /// </summary>
        [JsonProperty(PropertyName = "closeDate")]
        public DateTime? CloseDate { get; set; }
    }
}
