// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a request to retrieve survey results.
    /// </summary>
    public class MediaMetadata : BaseEntity, IAbstractAcknowledgement
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
        /// Id used to identify the media asset.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The original filename assigned to the media asset.
        /// </summary>
        [JsonProperty(PropertyName = "originalFile")]
        public string OriginalFile { get; set; }

        /// <summary>
        /// The url for the full resolution versio of the media file.
        /// </summary>
        [JsonProperty(PropertyName = "fileUrl")]
        public string FileUrl { get; set; }

        /// <summary>
        /// The url for to the thumbnail of an image.
        /// </summary>
        [JsonProperty(PropertyName = "thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// An identifier used to flag video files.
        /// </summary>
        [JsonProperty(PropertyName = "video")]
        public bool Video { get; set; }
    }
}
