// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a branding asset response.
    /// </summary>
    public class BrandingAssetResponse : BaseEntity, IAbstractAcknowledgement
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
        /// The id owner of this branding stack.
        /// </summary>
        [JsonProperty(PropertyName = "ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// The type of user or tenant that owns this branding stack.
        /// </summary>
        [JsonProperty(PropertyName = "ownerType")]
        public string OwnerType { get; set; }

        /// <summary>
        /// The name of the entity or tenant that owns this branding stack.
        /// </summary>
        [JsonProperty(PropertyName = "ownerName")]
        public string OwnerName { get; set; }

        /// <summary>
        /// The owner level currently being displayed.
        /// </summary>
        [JsonProperty(PropertyName = "levelName")]
        public string LevelName { get; set; }

        /// <summary>
        /// A narrative description of the current simulate time.
        /// </summary>
        [JsonProperty(PropertyName = "narrativeTime")]
        public string NarrativeTime { get; set; }

        /// <summary>
        /// The asset currently displayed on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "activeAsset")]
        public BrandingAsset ActiveAsset { get; set; }

        /// <summary>
        /// Enumerates all branding assets in a given credential scope.
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<BrandingAsset> Results { get; set; }
    }
}
