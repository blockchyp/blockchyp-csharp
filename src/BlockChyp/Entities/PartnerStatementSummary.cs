// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a basic information about partner statements for use in list or search
    /// results.
    /// </summary>
    public class PartnerStatementSummary : BaseEntity
    {
        /// <summary>
        /// The id owner of the pricing policy.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The date the statement was generated.
        /// </summary>
        [JsonProperty(PropertyName = "statementDate")]
        public DateTime? StatementDate { get; set; }

        /// <summary>
        /// Total volume in numeric format.
        /// </summary>
        [JsonProperty(PropertyName = "totalVolume")]
        public float TotalVolume { get; set; }

        /// <summary>
        /// The string formatted total volume on the statement.
        /// </summary>
        [JsonProperty(PropertyName = "totalVolumeFormatted")]
        public string TotalVolumeFormatted { get; set; }

        /// <summary>
        /// The total volume on the statement.
        /// </summary>
        [JsonProperty(PropertyName = "transactionCount")]
        public long TransactionCount { get; set; }

        /// <summary>
        /// The commission earned on the portfolio during the statement period.
        /// </summary>
        [JsonProperty(PropertyName = "partnerCommission")]
        public float PartnerCommission { get; set; }

        /// <summary>
        /// The string formatted total volume on the statement.
        /// </summary>
        [JsonProperty(PropertyName = "partnerCommissionFormatted")]
        public string PartnerCommissionFormatted { get; set; }

        /// <summary>
        /// The status of the statement.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
