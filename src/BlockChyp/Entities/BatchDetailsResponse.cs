// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a response for details about a single batch.
    /// </summary>
    public class BatchDetailsResponse : BaseEntity, IAbstractAcknowledgement
    {
        /// <summary>
        /// Whether or not the request succeeded.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// The error, if an error occurred.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        /// <summary>
        /// A narrative description of the transaction result.
        /// </summary>
        [JsonProperty(PropertyName = "responseDescription")]
        public string ResponseDescription { get; set; }

        /// <summary>
        /// That the response came from the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// Batch identifier.
        /// </summary>
        [JsonProperty(PropertyName = "batchId")]
        public string BatchId { get; set; }

        /// <summary>
        /// The new captured amount.
        /// </summary>
        [JsonProperty(PropertyName = "capturedAmount")]
        public string CapturedAmount { get; set; }

        /// <summary>
        /// Preauths from this batch still open.
        /// </summary>
        [JsonProperty(PropertyName = "openPreauths")]
        public string OpenPreauths { get; set; }

        /// <summary>
        /// The total volume from this batch.
        /// </summary>
        [JsonProperty(PropertyName = "totalVolume")]
        public string TotalVolume { get; set; }

        /// <summary>
        /// The total number of transactions in this batch.
        /// </summary>
        [JsonProperty(PropertyName = "transactionCount")]
        public int TransactionCount { get; set; }

        /// <summary>
        /// The total volume of gift cards sold.
        /// </summary>
        [JsonProperty(PropertyName = "giftCardsSold")]
        public string GiftCardsSold { get; set; }

        /// <summary>
        /// The total volume of gift cards transactions.
        /// </summary>
        [JsonProperty(PropertyName = "giftCardVolume")]
        public string GiftCardVolume { get; set; }

        /// <summary>
        /// The expected volume for this batch, usually captured volume less gift card
        /// volume.
        /// </summary>
        [JsonProperty(PropertyName = "expectedDeposit")]
        public string ExpectedDeposit { get; set; }

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

        /// <summary>
        /// Merchant's batch history in descending order.
        /// </summary>
        [JsonProperty(PropertyName = "volumeByTerminal")]
        public List<TerminalVolume> VolumeByTerminal { get; set; }
    }
}
