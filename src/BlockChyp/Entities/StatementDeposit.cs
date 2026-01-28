// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models information about merchant deposits during a statement period.
    /// </summary>
    public class StatementDeposit : BaseEntity
    {
        /// <summary>
        /// The line item id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The number of transactions in the batch for which funds were deposited.
        /// </summary>
        [JsonProperty(PropertyName = "transactionCount")]
        public long TransactionCount { get; set; }

        /// <summary>
        /// The batch id associated with the deposit.
        /// </summary>
        [JsonProperty(PropertyName = "batchId")]
        public string BatchId { get; set; }

        /// <summary>
        /// The prepaid fees associated with the batch.
        /// </summary>
        [JsonProperty(PropertyName = "feesPaid")]
        public float FeesPaid { get; set; }

        /// <summary>
        /// The currency formatted form of prepaid fees.
        /// </summary>
        [JsonProperty(PropertyName = "feesPaidFormatted")]
        public string FeesPaidFormatted { get; set; }

        /// <summary>
        /// The net deposit released to the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "netDeposit")]
        public float NetDeposit { get; set; }

        /// <summary>
        /// The currency formatted net deposit released to the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "netDepositFormatted")]
        public string NetDepositFormatted { get; set; }

        /// <summary>
        /// The total sales in the batch.
        /// </summary>
        [JsonProperty(PropertyName = "totalSales")]
        public float TotalSales { get; set; }

        /// <summary>
        /// The currency formatted total sales in the batch.
        /// </summary>
        [JsonProperty(PropertyName = "totalSalesFormatted")]
        public string TotalSalesFormatted { get; set; }

        /// <summary>
        /// The total refunds in the batch.
        /// </summary>
        [JsonProperty(PropertyName = "totalRefunds")]
        public float TotalRefunds { get; set; }

        /// <summary>
        /// The currency formatted total refunds in the batch.
        /// </summary>
        [JsonProperty(PropertyName = "totalRefundsFormatted")]
        public string TotalRefundsFormatted { get; set; }
    }
}
