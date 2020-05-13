// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models transaction volume for a single terminal.
    /// </summary>
    public class TerminalVolume : BaseEntity
    {
        /// <summary>
        /// The terminal name assigned during activation.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// The manufacturer's serial number.
        /// </summary>
        [JsonProperty(PropertyName = "serialNumber")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// The terminal type.
        /// </summary>
        [JsonProperty(PropertyName = "terminalType")]
        public string TerminalType { get; set; }

        /// <summary>
        /// The captured amount.
        /// </summary>
        [JsonProperty(PropertyName = "capturedAmount")]
        public string CapturedAmount { get; set; }

        /// <summary>
        /// The number of transactions run on this terminal.
        /// </summary>
        [JsonProperty(PropertyName = "transactionCount")]
        public int TransactionCount { get; set; }
    }
}
