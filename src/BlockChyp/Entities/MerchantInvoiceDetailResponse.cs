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
    /// 
    /// </summary>
    public class MerchantInvoiceDetailResponse : BaseEntity, IAbstractAcknowledgement
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
        /// The id of the merchant associated with the statement.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The corporate name of the merchant associated with the statement.
        /// </summary>
        [JsonProperty(PropertyName = "corporateName")]
        public string CorporateName { get; set; }

        /// <summary>
        /// The dba name of the merchant associated with the statement.
        /// </summary>
        [JsonProperty(PropertyName = "dbaName")]
        public string DbaName { get; set; }

        /// <summary>
        /// The date the statement was generated.
        /// </summary>
        [JsonProperty(PropertyName = "dateCreated")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// The current status of the invoice.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The type of invoice (statement or invoice).
        /// </summary>
        [JsonProperty(PropertyName = "invoiceType")]
        public string InvoiceType { get; set; }

        /// <summary>
        /// The type of pricing used for the invoice (typically flat rate or or interchange
        /// plus).
        /// </summary>
        [JsonProperty(PropertyName = "pricingType")]
        public string PricingType { get; set; }

        /// <summary>
        /// Whether or not the invoice has been paid.
        /// </summary>
        [JsonProperty(PropertyName = "paid")]
        public bool Paid { get; set; }

        /// <summary>
        /// The grand total.
        /// </summary>
        [JsonProperty(PropertyName = "grandTotal")]
        public float GrandTotal { get; set; }

        /// <summary>
        /// The string formatted grand total.
        /// </summary>
        [JsonProperty(PropertyName = "grandTotalFormatted")]
        public string GrandTotalFormatted { get; set; }

        /// <summary>
        /// The subtotal before shipping and tax.
        /// </summary>
        [JsonProperty(PropertyName = "subtotal")]
        public float Subtotal { get; set; }

        /// <summary>
        /// The string formatted subtotal before shipping and tax.
        /// </summary>
        [JsonProperty(PropertyName = "subotalFormatted")]
        public string SubotalFormatted { get; set; }

        /// <summary>
        /// The total sales tax.
        /// </summary>
        [JsonProperty(PropertyName = "taxTotal")]
        public float TaxTotal { get; set; }

        /// <summary>
        /// The string formatted total sales tax.
        /// </summary>
        [JsonProperty(PropertyName = "taxTotalFormatted")]
        public string TaxTotalFormatted { get; set; }

        /// <summary>
        /// The total cost of shipping.
        /// </summary>
        [JsonProperty(PropertyName = "shippingCost")]
        public float ShippingCost { get; set; }

        /// <summary>
        /// The string formatted total cost of shipping.
        /// </summary>
        [JsonProperty(PropertyName = "shippingCostFormatted")]
        public string ShippingCostFormatted { get; set; }

        /// <summary>
        /// The total unpaid balance on the invoice.
        /// </summary>
        [JsonProperty(PropertyName = "balanceDue")]
        public float BalanceDue { get; set; }

        /// <summary>
        /// The string formatted unpaid balance on the invoice.
        /// </summary>
        [JsonProperty(PropertyName = "balanceDueFormatted")]
        public string BalanceDueFormatted { get; set; }

        /// <summary>
        /// The shipping or physical address associated with the invoice.
        /// </summary>
        [JsonProperty(PropertyName = "shippingAddress")]
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// The billing or mailing address associated with the invoice.
        /// </summary>
        [JsonProperty(PropertyName = "billingAddress")]
        public Address BillingAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "lineItems")]
        public List<InvoiceLineItem> LineItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "payments")]
        public List<InvoicePayment> Payments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "deposits")]
        public List<StatementDeposit> Deposits { get; set; }
    }
}
