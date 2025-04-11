// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a Terms and Conditions history request.
    /// </summary>
    public class TermsAndConditionsLogResponse : BaseEntity, IAbstractAcknowledgement
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
        /// Optional transaction id if only log entries related to a transaction should be
        /// returned.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Max to be returned in a single page. Defaults to the system max of 250.
        /// </summary>
        [JsonProperty(PropertyName = "maxResults")]
        public int MaxResults { get; set; }

        /// <summary>
        /// Starting index for paged results. Defaults to zero.
        /// </summary>
        [JsonProperty(PropertyName = "startIndex")]
        public int StartIndex { get; set; }

        /// <summary>
        /// Total number of results accessible through paging.
        /// </summary>
        [JsonProperty(PropertyName = "resultCount")]
        public int ResultCount { get; set; }

        /// <summary>
        /// The full result set responsive to the original request, subject to pagination
        /// limits.
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<TermsAndConditionsLogEntry> Results { get; set; }
    }
}
