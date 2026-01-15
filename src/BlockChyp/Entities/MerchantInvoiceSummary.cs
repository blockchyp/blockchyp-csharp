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
    /// Models basic information about a merchant invoice for use in list or search results.
    /// </summary>
    public class MerchantInvoiceSummary : BaseEntity
    {
        /// <summary>
        /// The id owner of the invoice.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The date the statement was generated.
        /// </summary>
        [JsonProperty(PropertyName = "dateCreated")]
        public DateTime? DateCreated { get; set; }

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
        /// The status of the statement.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Identifies the invoice type.
        /// </summary>
        [JsonProperty(PropertyName = "invoiceType")]
        public string InvoiceType { get; set; }

        /// <summary>
        /// Whether or not the invoice had been paid.
        /// </summary>
        [JsonProperty(PropertyName = "paid")]
        public bool Paid { get; set; }
    }
}
