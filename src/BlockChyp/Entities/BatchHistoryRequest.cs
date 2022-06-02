// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a batch history request.
    /// </summary>
    public class BatchHistoryRequest : BaseEntity, ITimeoutRequest, ICoreRequest
    {
        /// <summary>
        /// The request timeout in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }

        /// <summary>
        /// Whether or not to route transaction to the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// A user-assigned reference that can be used to recall or reverse transactions.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// Defers the response to the transaction and returns immediately. Callers
        /// should retrive the transaction result using the Transaction Status API.
        /// </summary>
        [JsonProperty(PropertyName = "async")]
        public bool Async { get; set; }

        /// <summary>
        /// Adds the transaction to the queue and returns immediately. Callers should
        /// retrive the transaction result using the Transaction Status API.
        /// </summary>
        [JsonProperty(PropertyName = "queue")]
        public bool Queue { get; set; }

        /// <summary>
        /// Whether or not the request should block until all cards have been removed from
        /// the card reader.
        /// </summary>
        [JsonProperty(PropertyName = "waitForRemovedCard")]
        public bool WaitForRemovedCard { get; set; }

        /// <summary>
        /// Override any in-progress transactions.
        /// </summary>
        [JsonProperty(PropertyName = "force")]
        public bool Force { get; set; }

        /// <summary>
        /// An identifier from an external point of sale system.
        /// </summary>
        [JsonProperty(PropertyName = "orderRef")]
        public string OrderRef { get; set; }

        /// <summary>
        /// The settlement account for merchants with split settlements.
        /// </summary>
        [JsonProperty(PropertyName = "destinationAccount")]
        public string DestinationAccount { get; set; }

        /// <summary>
        /// Optional start date filter for batch history.
        /// </summary>
        [JsonProperty(PropertyName = "startDate")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Optional end date filter for batch history.
        /// </summary>
        [JsonProperty(PropertyName = "endDate")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Max results to be returned by this request. Defaults to the system max of 250.
        /// </summary>
        [JsonProperty(PropertyName = "maxResults")]
        public int MaxResults { get; set; }

        /// <summary>
        /// Starting index for results to be returned.
        /// </summary>
        [JsonProperty(PropertyName = "startIndex")]
        public int StartIndex { get; set; }
    }
}
