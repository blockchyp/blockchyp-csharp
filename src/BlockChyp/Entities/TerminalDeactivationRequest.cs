// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a terminal deactivation request.
    /// </summary>
    public class TerminalDeactivationRequest : BaseEntity, ITimeoutRequest
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
        /// The terminal name assigned to the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// The id assigned by BlockChyp to the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalId")]
        public string TerminalId { get; set; }
    }
}
