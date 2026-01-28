// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models information about payments against an invoice.
    /// </summary>
    public class InvoicePayment : BaseEntity
    {
        /// <summary>
        /// The line item id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Timestamp the payment was authorized.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// The type of disbursement transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transactionType")]
        public string TransactionType { get; set; }

        /// <summary>
        /// The payment method used to fund the disbursement.
        /// </summary>
        [JsonProperty(PropertyName = "paymentType")]
        public string PaymentType { get; set; }

        /// <summary>
        /// The auth code associated with credit card payment methods.
        /// </summary>
        [JsonProperty(PropertyName = "authCode")]
        public string AuthCode { get; set; }

        /// <summary>
        /// The masked account number into which funds were deposited.
        /// </summary>
        [JsonProperty(PropertyName = "maskedPan")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// That payment is still pending.
        /// </summary>
        [JsonProperty(PropertyName = "pending")]
        public bool Pending { get; set; }

        /// <summary>
        /// That payment is approved.
        /// </summary>
        [JsonProperty(PropertyName = "approved")]
        public bool Approved { get; set; }

        /// <summary>
        /// A response description from the disbursement payment platform, in any.
        /// </summary>
        [JsonProperty(PropertyName = "responseDescription")]
        public string ResponseDescription { get; set; }

        /// <summary>
        /// The amount disbursed in floating point format.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public float Amount { get; set; }

        /// <summary>
        /// The currency formatted form of amount.
        /// </summary>
        [JsonProperty(PropertyName = "amountFormatted")]
        public string AmountFormatted { get; set; }
    }
}
