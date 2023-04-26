// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models information needed to process a file upload.
    /// </summary>
    public class UploadMetadata : BaseEntity, ITimeoutRequest
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
        /// Optional id used to track status and progress of an upload while in progress.
        /// </summary>
        [JsonProperty(PropertyName = "uploadId")]
        public string UploadId { get; set; }

        /// <summary>
        /// The size of the file to be uploaded in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "fileSize")]
        public long FileSize { get; set; }

        /// <summary>
        /// The name of file to be uploaded.
        /// </summary>
        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }
    }
}
