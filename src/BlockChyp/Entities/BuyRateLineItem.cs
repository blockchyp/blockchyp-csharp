// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a single buy rate calculation line item.
    /// </summary>
    public class BuyRateLineItem : BaseEntity
    {
        /// <summary>
        /// Provides a basic description of the line item.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The volume related to this line item.
        /// </summary>
        [JsonProperty(PropertyName = "volume")]
        public float Volume { get; set; }

        /// <summary>
        /// The currency formatted volume related to this line item.
        /// </summary>
        [JsonProperty(PropertyName = "volumeFormatted")]
        public string VolumeFormatted { get; set; }

        /// <summary>
        /// The rate on volume charged for this line item.
        /// </summary>
        [JsonProperty(PropertyName = "volumeRate")]
        public float VolumeRate { get; set; }

        /// <summary>
        /// The string formatted rate on volume charged for this line item.
        /// </summary>
        [JsonProperty(PropertyName = "volumeRateFormatted")]
        public string VolumeRateFormatted { get; set; }

        /// <summary>
        /// The count associated with this line item.
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public long Count { get; set; }

        /// <summary>
        /// The rate per item charged for this line item.
        /// </summary>
        [JsonProperty(PropertyName = "countRate")]
        public float CountRate { get; set; }

        /// <summary>
        /// The string formatted rate per item charged for this line item.
        /// </summary>
        [JsonProperty(PropertyName = "countRateFormatted")]
        public string CountRateFormatted { get; set; }

        /// <summary>
        /// Provides a narrative description of the rate.
        /// </summary>
        [JsonProperty(PropertyName = "rateSummary")]
        public string RateSummary { get; set; }

        /// <summary>
        /// The total amount for the line item.
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public float Total { get; set; }

        /// <summary>
        /// The string formatted total for the line item.
        /// </summary>
        [JsonProperty(PropertyName = "totalFormatted")]
        public string TotalFormatted { get; set; }
    }
}
