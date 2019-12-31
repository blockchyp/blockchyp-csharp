/**
 * Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is governed by a
 * license that can be found in the LICENSE file.
 *
 * This file was generated automatically. Changes to this file will be lost every time the
 * code is regenerated.
 */


using System.Collections.Generic;

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// The response to a close batch request.
    /// </summary>
    public class CloseBatchResponse
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
        /// The ID assigned to the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// The ID assigned to the batch.
        /// </summary>
        [JsonProperty(PropertyName = "batchId")]
        public string BatchId { get; set; }

        /// <summary>
        /// The transaction reference string assigned to the transaction request. If no
        /// transaction ref was assiged on the request, then the gateway will randomly
        /// generate one.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// The type of transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transactionType")]
        public string TransactionType { get; set; }

        /// <summary>
        /// The timestamp of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// The hash of the last tick block.
        /// </summary>
        [JsonProperty(PropertyName = "tickBlock")]
        public string TickBlock { get; set; }

        /// <summary>
        /// That the transaction was processed on the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// The ECC signature of the response. Can be used to ensure that it was signed by the
        /// terminal and detect man-in-the middle attacks.
        /// </summary>
        [JsonProperty(PropertyName = "sig")]
        public string Sig { get; set; }

        /// <summary>
        /// The currency code of amounts indicated.
        /// </summary>
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The total captured amount for this batch. Should be the expected deposit
        /// amount.
        /// </summary>
        [JsonProperty(PropertyName = "capturedTotal")]
        public string CapturedTotal { get; set; }

        /// <summary>
        /// The total amount of preauths opened during the batch that weren't captured.
        /// </summary>
        [JsonProperty(PropertyName = "openPreauths")]
        public string OpenPreauths { get; set; }

        /// <summary>
        /// The captured totals by card brand.
        /// </summary>
        [JsonProperty(PropertyName = "cardBrands")]
        public Dictionary<string, string> CardBrands { get; set; }
    }
}
