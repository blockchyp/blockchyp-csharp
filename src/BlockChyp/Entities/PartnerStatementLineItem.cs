// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models line item level data for a partner statement.
    /// </summary>
    public class PartnerStatementLineItem : BaseEntity
    {
        /// <summary>
        /// The line item id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The invoice id for the underlying merchant statement.
        /// </summary>
        [JsonProperty(PropertyName = "invoiceId")]
        public string InvoiceId { get; set; }

        /// <summary>
        /// The total fees charged to the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "totalFees")]
        public float TotalFees { get; set; }

        /// <summary>
        /// The total fees charge formatted as a currency string.
        /// </summary>
        [JsonProperty(PropertyName = "totalFeesFormatted")]
        public string TotalFeesFormatted { get; set; }

        /// <summary>
        /// The total fees charged to the merchant as ratio of volume.
        /// </summary>
        [JsonProperty(PropertyName = "totalFeesOnVolume")]
        public float TotalFeesOnVolume { get; set; }

        /// <summary>
        /// The total fees charged to the merchant as percentage of volume.
        /// </summary>
        [JsonProperty(PropertyName = "totalFeesOnVolumeFormatted")]
        public string TotalFeesOnVolumeFormatted { get; set; }

        /// <summary>
        /// The id of the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The corporate name of the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "merchantName")]
        public string MerchantName { get; set; }

        /// <summary>
        /// The dba name of the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "dbaName")]
        public string DbaName { get; set; }

        /// <summary>
        /// The date the statement was generated.
        /// </summary>
        [JsonProperty(PropertyName = "statementDate")]
        public DateTime? StatementDate { get; set; }

        /// <summary>
        /// Volume in numeric format.
        /// </summary>
        [JsonProperty(PropertyName = "volume")]
        public float Volume { get; set; }

        /// <summary>
        /// The string formatted total volume on the statement.
        /// </summary>
        [JsonProperty(PropertyName = "volumeFormatted")]
        public string VolumeFormatted { get; set; }

        /// <summary>
        /// The total volume on the statement.
        /// </summary>
        [JsonProperty(PropertyName = "transactionCount")]
        public long TransactionCount { get; set; }

        /// <summary>
        /// The total interchange fees incurred this period.
        /// </summary>
        [JsonProperty(PropertyName = "interchange")]
        public float Interchange { get; set; }

        /// <summary>
        /// The currency formatted form of interchange.
        /// </summary>
        [JsonProperty(PropertyName = "interchangeFormatted")]
        public string InterchangeFormatted { get; set; }

        /// <summary>
        /// The total interchange as a ratio on volume incurred this period.
        /// </summary>
        [JsonProperty(PropertyName = "interchangeOnVolume")]
        public float InterchangeOnVolume { get; set; }

        /// <summary>
        /// The total interchange as a percentage of volume.
        /// </summary>
        [JsonProperty(PropertyName = "interchangeOnVolumeFormatted")]
        public string InterchangeOnVolumeFormatted { get; set; }

        /// <summary>
        /// The total card brand assessments fees incurred this period.
        /// </summary>
        [JsonProperty(PropertyName = "assessments")]
        public float Assessments { get; set; }

        /// <summary>
        /// The currency formatted form of card brand assessments.
        /// </summary>
        [JsonProperty(PropertyName = "assessmentsFormatted")]
        public string AssessmentsFormatted { get; set; }

        /// <summary>
        /// The total card brand assessments as a ratio on volume incurred this period.
        /// </summary>
        [JsonProperty(PropertyName = "assessmentsOnVolume")]
        public float AssessmentsOnVolume { get; set; }

        /// <summary>
        /// The total card brand assessments as a percentage of volume.
        /// </summary>
        [JsonProperty(PropertyName = "assessmentsOnVolumeFormatted")]
        public string AssessmentsOnVolumeFormatted { get; set; }

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
        /// The total fees charge to the partner due to buy rates.
        /// </summary>
        [JsonProperty(PropertyName = "buyRate")]
        public float BuyRate { get; set; }

        /// <summary>
        /// The currency formatted form of partner buy rate.
        /// </summary>
        [JsonProperty(PropertyName = "buyRateFormatted")]
        public string BuyRateFormatted { get; set; }

        /// <summary>
        /// Refers to card brand fees shared between BlockChyp and the partner.
        /// </summary>
        [JsonProperty(PropertyName = "hardCosts")]
        public float HardCosts { get; set; }

        /// <summary>
        /// The currency formatted form of hard costs.
        /// </summary>
        [JsonProperty(PropertyName = "hardCostsFormatted")]
        public string HardCostsFormatted { get; set; }
    }
}
