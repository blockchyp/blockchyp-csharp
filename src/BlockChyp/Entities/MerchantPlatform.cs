// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Details about a merchant board platform configuration.
    /// </summary>
    public class MerchantPlatform : BaseEntity, ITimeoutRequest
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
        /// Primary identifier for a given platform configuration.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// That a platform configuration is disabled.
        /// </summary>
        [JsonProperty(PropertyName = "disabled")]
        public bool Disabled { get; set; }

        /// <summary>
        /// BlockChyp's code for the boarding platform.
        /// </summary>
        [JsonProperty(PropertyName = "platformCode")]
        public string PlatformCode { get; set; }

        /// <summary>
        /// The platform's priority in a multi platform setup.
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int Priority { get; set; }

        /// <summary>
        /// An optional field specifying the merchant's card brand registration record.
        /// </summary>
        [JsonProperty(PropertyName = "registrationId")]
        public string RegistrationId { get; set; }

        /// <summary>
        /// The merchant's primary identifier.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The merchant id assigned by the acquiring bank.
        /// </summary>
        [JsonProperty(PropertyName = "acquirerMid")]
        public string AcquirerMid { get; set; }

        /// <summary>
        /// Free form notes description the purpose or intent behind the platform
        /// configuration.
        /// </summary>
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        /// <summary>
        /// The optional entry method code if a platform should only be used for specific
        /// entry methods. Leave blank for 'all'.
        /// </summary>
        [JsonProperty(PropertyName = "entryMethod")]
        public string EntryMethod { get; set; }

        /// <summary>
        /// The date the platform configuration was first created.
        /// </summary>
        [JsonProperty(PropertyName = "dateCreated")]
        public string DateCreated { get; set; }

        /// <summary>
        /// The date the platform configuration was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "lastChange")]
        public string LastChange { get; set; }

        /// <summary>
        /// A map of configuration values specific to the boarding platform. These are not
        /// published. Contact your BlockChyp rep for supported values.
        /// </summary>
        [JsonProperty(PropertyName = "configMap")]
        public Dictionary<string, string> ConfigMap { get; set; }
    }
}
