// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a request to generate merchant api credentials.
    /// </summary>
    public class MerchantCredentialGenerationRequest : BaseEntity, ITimeoutRequest
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
        /// The merchant id.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// Protects the credentials from deletion.
        /// </summary>
        [JsonProperty(PropertyName = "deleteProtected")]
        public bool DeleteProtected { get; set; }

        /// <summary>
        /// An optional array of role codes that will be assigned to the credentials.
        /// </summary>
        [JsonProperty(PropertyName = "roles")]
        public List<string> Roles { get; set; }

        /// <summary>
        /// Free form description of the purpose or intent behind the credentials.
        /// </summary>
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }
    }
}
