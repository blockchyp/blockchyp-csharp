// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a Terms and Conditions history request.
    /// </summary>
    public class TermsAndConditionsLogRequest : BaseEntity
    {
        /// <summary>
        /// The identifier of the log entry to be returned for single result requests.
        /// </summary>
        [JsonProperty(PropertyName = "logEntryId")]
        public string LogEntryId { get; set; }

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
        /// An optional timeout override.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }
    }
}
