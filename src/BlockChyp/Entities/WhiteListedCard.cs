/**
 * Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is governed by a
 * license that can be found in the LICENSE file.
 *
 * This file was generated automatically. Changes to this file will be lost every time the
 * code is regenerated.
 */



using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Shows details about a white listed card.
    /// </summary>
    public class WhiteListedCard
    {
        /// <summary>
        /// The card BIN.
        /// </summary>
        [JsonProperty(PropertyName = "bin")]
        public string Bin { get; set; }

        /// <summary>
        /// The track 1 data from the card.
        /// </summary>
        [JsonProperty(PropertyName = "track1")]
        public string Track1 { get; set; }

        /// <summary>
        /// The track 2 data from the card.
        /// </summary>
        [JsonProperty(PropertyName = "track2")]
        public string Track2 { get; set; }

        /// <summary>
        /// The card primary account number.
        /// </summary>
        [JsonProperty(PropertyName = "pan")]
        public string Pan { get; set; }
    }
}
