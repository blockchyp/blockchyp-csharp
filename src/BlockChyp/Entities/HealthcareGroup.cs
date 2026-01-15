// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// A group of fields for a specific type of healthcare.
    /// </summary>
    public class HealthcareGroup : BaseEntity
    {
        /// <summary>
        /// The type of healthcare cost.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public HealthcareType Type { get; set; }

        /// <summary>
        /// The amount of this type.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The provider ID used for Mastercard and Discover IIAS requests.
        /// </summary>
        [JsonProperty(PropertyName = "providerId")]
        public string ProviderId { get; set; }

        /// <summary>
        /// The service type code used for Mastercard and Discover IIAS requests.
        /// </summary>
        [JsonProperty(PropertyName = "serviceTypeCode")]
        public string ServiceTypeCode { get; set; }

        /// <summary>
        /// Thr payer ID/carrier ID used for Mastercard and Discover IIAS requests.
        /// </summary>
        [JsonProperty(PropertyName = "payerOrCarrierId")]
        public string PayerOrCarrierId { get; set; }

        /// <summary>
        /// The approval or reject reason code used for Mastercard and Discover IIAS
        /// requests.
        /// </summary>
        [JsonProperty(PropertyName = "approvalRejectReasonCode")]
        public string ApprovalRejectReasonCode { get; set; }
    }
}
