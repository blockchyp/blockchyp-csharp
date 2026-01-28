// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a request to retrieve or manipulate survey questions.
    /// </summary>
    public class SurveyDataPoint : BaseEntity
    {
        /// <summary>
        /// A unique identifier for a specific answer type.
        /// </summary>
        [JsonProperty(PropertyName = "answerKey")]
        public string AnswerKey { get; set; }

        /// <summary>
        /// A narrative description of the answer.
        /// </summary>
        [JsonProperty(PropertyName = "answerDescription")]
        public string AnswerDescription { get; set; }

        /// <summary>
        /// The number of responses.
        /// </summary>
        [JsonProperty(PropertyName = "responseCount")]
        public int ResponseCount { get; set; }

        /// <summary>
        /// Response rate as a percentage of total transactions.
        /// </summary>
        [JsonProperty(PropertyName = "responsePercentage")]
        public float ResponsePercentage { get; set; }

        /// <summary>
        /// The average transaction amount for a given answer.
        /// </summary>
        [JsonProperty(PropertyName = "averageTransaction")]
        public float AverageTransaction { get; set; }
    }
}
