// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a slide within a slide show.
    /// </summary>
    public class Slide : BaseEntity
    {
        /// <summary>
        /// The id for the media asset to be used for this slide. Must be an image.
        /// </summary>
        [JsonProperty(PropertyName = "mediaId")]
        public string MediaId { get; set; }

        /// <summary>
        /// Position of the slide within the slide show.
        /// </summary>
        [JsonProperty(PropertyName = "ordinal")]
        public int Ordinal { get; set; }

        /// <summary>
        /// The fully qualified thumbnail url for the slide.
        /// </summary>
        [JsonProperty(PropertyName = "thumbnailUrl")]
        public string ThumbnailUrl { get; set; }
    }
}
