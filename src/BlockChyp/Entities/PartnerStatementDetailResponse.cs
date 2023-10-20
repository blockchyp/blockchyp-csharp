// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a response to retrieve detailed partner statement information.
    /// </summary>
    public class PartnerStatementDetailResponse : BaseEntity, IAbstractAcknowledgement
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
        /// Optional start date filter for batch history.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The id of the partner associated with the statement.
        /// </summary>
        [JsonProperty(PropertyName = "partnerId")]
        public string PartnerId { get; set; }

        /// <summary>
        /// The name of the partner associated with the statement.
        /// </summary>
        [JsonProperty(PropertyName = "partnerName")]
        public string PartnerName { get; set; }

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
        /// The string formatted partner commission on the statement.
        /// </summary>
        [JsonProperty(PropertyName = "partnerCommissionFormatted")]
        public string PartnerCommissionFormatted { get; set; }

        /// <summary>
        /// The partner commission earned on the portfolio during the statement period as a
        /// ratio against volume.
        /// </summary>
        [JsonProperty(PropertyName = "partnerCommissionsOnVolume")]
        public float PartnerCommissionsOnVolume { get; set; }

        /// <summary>
        /// The string formatted version of partner commissions as a percentage of volume.
        /// </summary>
        [JsonProperty(PropertyName = "partnerCommissionsOnVolumeFormatted")]
        public string PartnerCommissionsOnVolumeFormatted { get; set; }

        /// <summary>
        /// The status of the statement.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "lineItems")]
        public List<PartnerStatementLineItem> LineItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "adjustments")]
        public List<PartnerStatementAdjustment> Adjustments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "disbursements")]
        public List<PartnerStatementDisbursement> Disbursements { get; set; }
    }
}
