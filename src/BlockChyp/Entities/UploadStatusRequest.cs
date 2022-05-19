// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Used to request the status of a file upload.
    /// </summary>
    public class UploadStatusRequest : BaseEntity
    {
        /// <summary>
        /// Id used to track status and progress of an upload while in progress.
        /// </summary>
        [JsonProperty(PropertyName = "uploadId")]
        public string UploadId { get; set; }

        /// <summary>
        /// An optional timeout override.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }
    }
}
