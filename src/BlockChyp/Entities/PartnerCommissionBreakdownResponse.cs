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
    /// Models detailed information about how partner commissions were calculated for a
    /// statement.
    /// </summary>
    public class PartnerCommissionBreakdownResponse : BaseEntity, IAbstractAcknowledgement
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
        /// The invoice (statement id) for which the commissions were calculated.
        /// </summary>
        [JsonProperty(PropertyName = "invoiceId")]
        public string InvoiceId { get; set; }

        /// <summary>
        /// The partner name.
        /// </summary>
        [JsonProperty(PropertyName = "partnerName")]
        public string PartnerName { get; set; }

        /// <summary>
        /// The partner statement id.
        /// </summary>
        [JsonProperty(PropertyName = "partnerStatementId")]
        public string PartnerStatementId { get; set; }

        /// <summary>
        /// The partner statement date.
        /// </summary>
        [JsonProperty(PropertyName = "partnerStatementDate")]
        public DateTime? PartnerStatementDate { get; set; }

        /// <summary>
        /// The merchant id.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The merchant's corporate name.
        /// </summary>
        [JsonProperty(PropertyName = "merchantCompanyName")]
        public string MerchantCompanyName { get; set; }

        /// <summary>
        /// The merchant's dba name.
        /// </summary>
        [JsonProperty(PropertyName = "merchantDbaName")]
        public string MerchantDbaName { get; set; }

        /// <summary>
        /// The grand total.
        /// </summary>
        [JsonProperty(PropertyName = "grandTotal")]
        public float GrandTotal { get; set; }

        /// <summary>
        /// The currency formatted grand total.
        /// </summary>
        [JsonProperty(PropertyName = "grandTotalFormatted")]
        public string GrandTotalFormatted { get; set; }

        /// <summary>
        /// The total fees.
        /// </summary>
        [JsonProperty(PropertyName = "totalFees")]
        public float TotalFees { get; set; }

        /// <summary>
        /// The currency formatted total fees.
        /// </summary>
        [JsonProperty(PropertyName = "totalFeesFormatted")]
        public string TotalFeesFormatted { get; set; }

        /// <summary>
        /// The total due the partner for this merchant statement.
        /// </summary>
        [JsonProperty(PropertyName = "totalDue")]
        public float TotalDue { get; set; }

        /// <summary>
        /// The currency formatted total due the partner for this merchant statement.
        /// </summary>
        [JsonProperty(PropertyName = "totalDueFormatted")]
        public string TotalDueFormatted { get; set; }

        /// <summary>
        /// The total volume during the statement period.
        /// </summary>
        [JsonProperty(PropertyName = "totalVolume")]
        public float TotalVolume { get; set; }

        /// <summary>
        /// The currency formatted total volume during the statement period.
        /// </summary>
        [JsonProperty(PropertyName = "totalVolumeFormatted")]
        public string TotalVolumeFormatted { get; set; }

        /// <summary>
        /// The total number of transactions processed during the statement period.
        /// </summary>
        [JsonProperty(PropertyName = "totalTransactions")]
        public long TotalTransactions { get; set; }

        /// <summary>
        /// The residual earned by the partner.
        /// </summary>
        [JsonProperty(PropertyName = "partnerResidual")]
        public float PartnerResidual { get; set; }

        /// <summary>
        /// The currency formatted residual earned by the partner.
        /// </summary>
        [JsonProperty(PropertyName = "partnerResidualFormatted")]
        public string PartnerResidualFormatted { get; set; }

        /// <summary>
        /// The total interchange charged during the statement period.
        /// </summary>
        [JsonProperty(PropertyName = "interchange")]
        public float Interchange { get; set; }

        /// <summary>
        /// The currency formatted total interchange charged during the statement
        /// period.
        /// </summary>
        [JsonProperty(PropertyName = "interchangeFormatted")]
        public string InterchangeFormatted { get; set; }

        /// <summary>
        /// The total assessments charged during the statement period.
        /// </summary>
        [JsonProperty(PropertyName = "assessments")]
        public float Assessments { get; set; }

        /// <summary>
        /// The currency formatted assessments charged during the statement period.
        /// </summary>
        [JsonProperty(PropertyName = "assessmentsFormatted")]
        public string AssessmentsFormatted { get; set; }

        /// <summary>
        /// The total of passthrough costs.
        /// </summary>
        [JsonProperty(PropertyName = "totalPassthrough")]
        public float TotalPassthrough { get; set; }

        /// <summary>
        /// The currency formatted total of passthrough costs.
        /// </summary>
        [JsonProperty(PropertyName = "totalPassthroughFormatted")]
        public string TotalPassthroughFormatted { get; set; }

        /// <summary>
        /// The total of non passthrough costs.
        /// </summary>
        [JsonProperty(PropertyName = "totalNonPassthrough")]
        public float TotalNonPassthrough { get; set; }

        /// <summary>
        /// The currency formatted total of non passthrough costs.
        /// </summary>
        [JsonProperty(PropertyName = "totalNonPassthroughFormatted")]
        public string TotalNonPassthroughFormatted { get; set; }

        /// <summary>
        /// The total of all card brand fees.
        /// </summary>
        [JsonProperty(PropertyName = "totalCardBrandFees")]
        public float TotalCardBrandFees { get; set; }

        /// <summary>
        /// The currency formatted total of all card brand fees.
        /// </summary>
        [JsonProperty(PropertyName = "totalCardBrandFeesFormatted")]
        public string TotalCardBrandFeesFormatted { get; set; }

        /// <summary>
        /// The total buy rate.
        /// </summary>
        [JsonProperty(PropertyName = "totalBuyRate")]
        public float TotalBuyRate { get; set; }

        /// <summary>
        /// The currency formatted total buy rate.
        /// </summary>
        [JsonProperty(PropertyName = "totalBuyRateFormatted")]
        public string TotalBuyRateFormatted { get; set; }

        /// <summary>
        /// The total buy rate before passthrough costs.
        /// </summary>
        [JsonProperty(PropertyName = "buyRateBeforePassthrough")]
        public float BuyRateBeforePassthrough { get; set; }

        /// <summary>
        /// The currency formatted total buy rate before passthrough costs.
        /// </summary>
        [JsonProperty(PropertyName = "buyRateBeforePassthroughFormatted")]
        public string BuyRateBeforePassthroughFormatted { get; set; }

        /// <summary>
        /// The net markup split between BlockChyp and the partner.
        /// </summary>
        [JsonProperty(PropertyName = "netMarkup")]
        public float NetMarkup { get; set; }

        /// <summary>
        /// The currency formatted net markup split between BlockChyp and the partner.
        /// </summary>
        [JsonProperty(PropertyName = "netMarkupFormatted")]
        public string NetMarkupFormatted { get; set; }

        /// <summary>
        /// The partner's total share of non passthrough hard costs.
        /// </summary>
        [JsonProperty(PropertyName = "partnerNonPassthroughShare")]
        public float PartnerNonPassthroughShare { get; set; }

        /// <summary>
        /// The currency formatted partner's total share of non passthrough hard costs.
        /// </summary>
        [JsonProperty(PropertyName = "partnerNonPassthroughShareFormatted")]
        public string PartnerNonPassthroughShareFormatted { get; set; }

        /// <summary>
        /// The total of chargeback fees assessed during the statement period.
        /// </summary>
        [JsonProperty(PropertyName = "chargebackFees")]
        public float ChargebackFees { get; set; }

        /// <summary>
        /// The currency formatted total of chargeback fees assessed during the statement
        /// period.
        /// </summary>
        [JsonProperty(PropertyName = "chargebackFeesFormatted")]
        public string ChargebackFeesFormatted { get; set; }

        /// <summary>
        /// The total number of chargebacks during the period.
        /// </summary>
        [JsonProperty(PropertyName = "chargebackCount")]
        public long ChargebackCount { get; set; }

        /// <summary>
        /// The partner's share of markup.
        /// </summary>
        [JsonProperty(PropertyName = "partnerPercentage")]
        public float PartnerPercentage { get; set; }

        /// <summary>
        /// The currency formatted partner's share of markup.
        /// </summary>
        [JsonProperty(PropertyName = "partnerPercentageFormatted")]
        public string PartnerPercentageFormatted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "buyRateLineItems")]
        public List<BuyRateLineItem> BuyRateLineItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "revenueDetails")]
        public List<AggregateBillingLineItem> RevenueDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "cardBrandCostDetails")]
        public List<AggregateBillingLineItem> CardBrandCostDetails { get; set; }
    }
}
