// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models the current status of a file upload.
    /// </summary>
    public class UploadStatus : BaseEntity, IAbstractAcknowledgement
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
        /// Id used to track status and progress of an upload while in progress.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The media id assigned to the result.
        /// </summary>
        [JsonProperty(PropertyName = "mediaId")]
        public string MediaId { get; set; }

        /// <summary>
        /// The size of the file to be uploaded in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "fileSize")]
        public long FileSize { get; set; }

        /// <summary>
        /// The amount of the file already uploaded.
        /// </summary>
        [JsonProperty(PropertyName = "uploadedAmount")]
        public long UploadedAmount { get; set; }

        /// <summary>
        /// The current status of a file upload.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Whether or not the upload and associated file processing is complete.
        /// </summary>
        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        /// <summary>
        /// Whether or not the file is processing. This normally applied to video files
        /// undergoing format transcoding.
        /// </summary>
        [JsonProperty(PropertyName = "processing")]
        public bool Processing { get; set; }

        /// <summary>
        /// Current upload progress rounded to the nearest integer.
        /// </summary>
        [JsonProperty(PropertyName = "percentage")]
        public int Percentage { get; set; }

        /// <summary>
        /// The url of a thumbnail for the file, if available.
        /// </summary>
        [JsonProperty(PropertyName = "thumbnailLocation")]
        public string ThumbnailLocation { get; set; }
    }
}
