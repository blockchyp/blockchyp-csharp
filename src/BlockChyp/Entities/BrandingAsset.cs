// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models the priority and display settings for terminal media.
    /// </summary>
    public class BrandingAsset : BaseEntity, ITimeoutRequest, IAbstractAcknowledgement
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
        /// Id used to track a branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The id owner of the tenant who owns the branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// The terminal id if this branding asset is specific to a single terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalId")]
        public string TerminalId { get; set; }

        /// <summary>
        /// The terminal group id if this branding asset is specific to a terminal group.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupId")]
        public string TerminalGroupId { get; set; }

        /// <summary>
        /// The merchant id associated with this branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The organization id associated with this branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// The partner id associated with this branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "partnerId")]
        public string PartnerId { get; set; }

        /// <summary>
        /// The slide show associated with this branding asset, if any. A branding asset can
        /// reference a slide show or media asset, but not both.
        /// </summary>
        [JsonProperty(PropertyName = "slideShowId")]
        public string SlideShowId { get; set; }

        /// <summary>
        /// The media id associated with this branding asset, if any. A branding asset can
        /// reference a slide show or media asset, but not both.
        /// </summary>
        [JsonProperty(PropertyName = "mediaId")]
        public string MediaId { get; set; }

        /// <summary>
        /// Applies standard margins to images displayed on terminals. Usually the best
        /// option for logos.
        /// </summary>
        [JsonProperty(PropertyName = "padded")]
        public bool Padded { get; set; }

        /// <summary>
        /// The start date if this asset should be displayed based on a schedule. Format:
        /// MM/DD/YYYY.
        /// </summary>
        [JsonProperty(PropertyName = "startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// The end date if this asset should be displayed based on a schedule. Format:
        /// MM/DD/YYYY.
        /// </summary>
        [JsonProperty(PropertyName = "endDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// An array of days of the week during which a branding asset should be enabled. Days
        /// of the week are coded as integers starting with Sunday (0) and ending with
        /// Saturday (6).
        /// </summary>
        [JsonProperty(PropertyName = "daysOfWeek")]
        public List<int> DaysOfWeek { get; set; }

        /// <summary>
        /// The start date if this asset should be displayed based on a schedule. Format:
        /// MM/DD/YYYY.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// The end date if this asset should be displayed based on a schedule. Format:
        /// MM/DD/YYYY.
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public string EndTime { get; set; }

        /// <summary>
        /// The ordinal number marking the position of this asset within the branding
        /// stack.
        /// </summary>
        [JsonProperty(PropertyName = "ordinal")]
        public int Ordinal { get; set; }

        /// <summary>
        /// Enables the asset for display.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// If true, the asset will be displayed in the merchant portal, but not on merchant
        /// terminal hardware. Developers will usually want this to always be false.
        /// </summary>
        [JsonProperty(PropertyName = "preview")]
        public bool Preview { get; set; }

        /// <summary>
        /// Id of the user who created this branding asset, if applicable.
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Name of the user who created this branding asset, if applicable.
        /// </summary>
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        /// <summary>
        /// The fully qualified URL of the thumbnail image for this branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail { get; set; }

        /// <summary>
        /// The time and date this asset was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "lastModified")]
        public string LastModified { get; set; }

        /// <summary>
        /// A field for notes related to a branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        /// <summary>
        /// If true, the API credentials used to retrieve the branding asset record can be
        /// used to update it.
        /// </summary>
        [JsonProperty(PropertyName = "editable")]
        public bool Editable { get; set; }

        /// <summary>
        /// The type of branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "assetType")]
        public string AssetType { get; set; }

        /// <summary>
        /// The type of user or tenant that owns this asset.
        /// </summary>
        [JsonProperty(PropertyName = "ownerType")]
        public string OwnerType { get; set; }

        /// <summary>
        /// A recommended caption for displaying the owner. Takes into account multiple
        /// organization types.
        /// </summary>
        [JsonProperty(PropertyName = "ownerTypeCaption")]
        public string OwnerTypeCaption { get; set; }

        /// <summary>
        /// The name of the tenant or entity that owns the branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "ownerName")]
        public string OwnerName { get; set; }

        /// <summary>
        /// The recommended image to be displayed when rendering a preview of this branding
        /// asset.
        /// </summary>
        [JsonProperty(PropertyName = "previewImage")]
        public string PreviewImage { get; set; }

        /// <summary>
        /// A compact narrative string explaining the effective date and time rules for a
        /// branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "narrativeEffectiveDates")]
        public string NarrativeEffectiveDates { get; set; }

        /// <summary>
        /// A compact narrative string explaining the display period for a branding asset.
        /// </summary>
        [JsonProperty(PropertyName = "narrativeDisplayPeriod")]
        public string NarrativeDisplayPeriod { get; set; }
    }
}
