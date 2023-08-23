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
    /// Models the status of a payment link.
    /// </summary>
    public class PaymentLinkStatusResponse : BaseEntity, IAbstractAcknowledgement
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
        /// The code used to retrieve the payment link.
        /// </summary>
        [JsonProperty(PropertyName = "linkCode")]
        public string LinkCode { get; set; }

        /// <summary>
        /// The BlockChyp merchant id associated with a payment link.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The customer id associated with a payment link.
        /// </summary>
        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// The user's internal reference for any transaction that may occur.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// The user's internal reference for an order.
        /// </summary>
        [JsonProperty(PropertyName = "orderRef")]
        public string OrderRef { get; set; }

        /// <summary>
        /// That the order is tax exempt.
        /// </summary>
        [JsonProperty(PropertyName = "taxExempt")]
        public bool TaxExempt { get; set; }

        /// <summary>
        /// That the amount to collect via the payment link.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The sales tax to be collected via the payment link.
        /// </summary>
        [JsonProperty(PropertyName = "taxAmount")]
        public string TaxAmount { get; set; }

        /// <summary>
        /// Subject for email notifications.
        /// </summary>
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Id of the most recent transaction associated with the link.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Description associated with the payment link.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Date and time the link will expire.
        /// </summary>
        [JsonProperty(PropertyName = "expiration")]
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// Date and time the link was created.
        /// </summary>
        [JsonProperty(PropertyName = "dateCreated")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Line item level data if provided.
        /// </summary>
        [JsonProperty(PropertyName = "transactionDetails")]
        public TransactionDisplayTransaction TransactionDetails { get; set; }

        /// <summary>
        /// The current status of the payment link.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Alias for any terms and conditions language associated with the link.
        /// </summary>
        [JsonProperty(PropertyName = "tcAlias")]
        public string TcAlias { get; set; }

        /// <summary>
        /// Name of any terms and conditions agreements associated with the payment link.
        /// </summary>
        [JsonProperty(PropertyName = "tcName")]
        public string TcName { get; set; }

        /// <summary>
        /// Full text of any terms and conditions language associated with the agreement.
        /// </summary>
        [JsonProperty(PropertyName = "tcContent")]
        public string TcContent { get; set; }

        /// <summary>
        /// That the link is intended for internal use by the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "cashierFacing")]
        public bool CashierFacing { get; set; }

        /// <summary>
        /// That the payment method should be enrolled in the token vault.
        /// </summary>
        [JsonProperty(PropertyName = "enroll")]
        public bool Enroll { get; set; }

        /// <summary>
        /// That the link should only be used for enrollment in the token vault without any
        /// underlying payment transaction.
        /// </summary>
        [JsonProperty(PropertyName = "enrollOnly")]
        public bool EnrollOnly { get; set; }

        /// <summary>
        /// Returns details about the last transaction status.
        /// </summary>
        [JsonProperty(PropertyName = "lastTransaction")]
        public AuthorizationResponse LastTransaction { get; set; }

        /// <summary>
        /// Returns a list of transactions associated with the link, including any
        /// declines.
        /// </summary>
        [JsonProperty(PropertyName = "transactionHistory")]
        public List<AuthorizationResponse> TransactionHistory { get; set; }
    }
}
