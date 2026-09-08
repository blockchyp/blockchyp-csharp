// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a request for terminal service fees.
    /// </summary>
    public class ServiceFeeRequest : BaseEntity, ITimeoutRequest, ITerminalReference
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
        /// The name of the target payment terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// Forces the terminal cloud connection to be reset while a transactions is in
        /// flight. This is a diagnostic settings that can be used only for test
        /// transactions.
        /// </summary>
        [JsonProperty(PropertyName = "resetConnection")]
        public bool ResetConnection { get; set; }

        /// <summary>
        /// The primary account number (PAN) of the card.
        /// </summary>
        [JsonProperty(PropertyName = "pan")]
        public string Pan { get; set; }

        /// <summary>
        /// The transaction amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The terminal DUKPT key for the request.
        /// </summary>
        [JsonProperty(PropertyName = "terminalDukptKey")]
        public string TerminalDukptKey { get; set; }

        /// <summary>
        /// The hex encoded transaction entropy used to derive the DUKPT transaction key.
        /// </summary>
        [JsonProperty(PropertyName = "transactionEntropy")]
        public string TransactionEntropy { get; set; }
    }
}
