// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Creates a payment link.
    /// </summary>
    public class PaymentLinkResponse : BaseEntity, IAbstractAcknowledgement
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
        /// The payment link code.
        /// </summary>
        [JsonProperty(PropertyName = "linkCode")]
        public string LinkCode { get; set; }

        /// <summary>
        /// The url for the payment link.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The url for a QR Code associated with this link.
        /// </summary>
        [JsonProperty(PropertyName = "qrcodeUrl")]
        public string QrcodeUrl { get; set; }

        /// <summary>
        /// The hex encoded binary for the QR Code, if requested. Encoded in PNG format.
        /// </summary>
        [JsonProperty(PropertyName = "qrcodeBinary")]
        public string QrcodeBinary { get; set; }

        /// <summary>
        /// The customer id created or used for the payment.
        /// </summary>
        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }
    }
}
