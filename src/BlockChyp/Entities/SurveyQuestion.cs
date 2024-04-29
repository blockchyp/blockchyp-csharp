// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a survey question.
    /// </summary>
    public class SurveyQuestion : BaseEntity, ITimeoutRequest, IAbstractAcknowledgement
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
        /// Internal id for a survey question.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Ordinal number indicating the position of the survey question in the post
        /// transaction sequence.
        /// </summary>
        [JsonProperty(PropertyName = "ordinal")]
        public int Ordinal { get; set; }

        /// <summary>
        /// Determines whether or not the question will be presented post transaction.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// The full text of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "questionText")]
        public string QuestionText { get; set; }

        /// <summary>
        /// The type of question. Valid values are 'yes_no' and 'scaled'.
        /// </summary>
        [JsonProperty(PropertyName = "questionType")]
        public string QuestionType { get; set; }

        /// <summary>
        /// The total number of transactions processed during the query period if results
        /// are requested.
        /// </summary>
        [JsonProperty(PropertyName = "transactionCount")]
        public int TransactionCount { get; set; }

        /// <summary>
        /// The total number of responses during the query period if results are requested.
        /// </summary>
        [JsonProperty(PropertyName = "responseCount")]
        public int ResponseCount { get; set; }

        /// <summary>
        /// The response rate, expressed as a ratio, if results are requested.
        /// </summary>
        [JsonProperty(PropertyName = "responseRate")]
        public float ResponseRate { get; set; }

        /// <summary>
        /// The set of response data points.
        /// </summary>
        [JsonProperty(PropertyName = "responses")]
        public List<SurveyDataPoint> Responses { get; set; }
    }
}
