// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class TerminalActivationRequest : BaseEntity
    {
        /// <summary>
        /// The optional merchant id.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The terminal activation code displayed on the terminal
        /// </summary>
        [JsonProperty(PropertyName = "activationCode")]
        public string ActivationCode { get; set; }

        /// <summary>
        /// The name to be assigned to the terminal. Must be unique for the merchant account.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// That the terminal should be activated in cloud relay mode.
        /// </summary>
        [JsonProperty(PropertyName = "cloudRelay")]
        public bool CloudRelay { get; set; }

        /// <summary>
        /// The optional timeout override for a terminal profile request.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }
    }
}
