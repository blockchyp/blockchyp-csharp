// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a request to retrieve or manipulate terminal slide shows.
    /// </summary>
    public class SlideShowRequest : BaseEntity
    {
        /// <summary>
        /// Id used to track a slide show.
        /// </summary>
        [JsonProperty(PropertyName = "slideShowId")]
        public string SlideShowId { get; set; }

        /// <summary>
        /// An optional timeout override.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }
    }
}