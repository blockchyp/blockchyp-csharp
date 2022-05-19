// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a request to retrieve survey results.
    /// </summary>
    public class SurveyResultsRequest : BaseEntity
    {
        /// <summary>
        /// Id of a single question.
        /// </summary>
        [JsonProperty(PropertyName = "questionId")]
        public string QuestionId { get; set; }

        /// <summary>
        /// An optional start date for filtering response data.
        /// </summary>
        [JsonProperty(PropertyName = "startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// An optional end date for filtering response data.
        /// </summary>
        [JsonProperty(PropertyName = "endDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// An optional timeout override.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }
    }
}
