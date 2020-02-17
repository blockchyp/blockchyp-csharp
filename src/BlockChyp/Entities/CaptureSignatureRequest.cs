// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// A request for customer signature data.
    /// </summary>
    public class CaptureSignatureRequest : BaseEntity, ICoreRequest, ISignatureRequest, ITerminalReference
    {
        /// <summary>
        /// The transaction reference string assigned to the transaction request. If no
        /// transaction ref was assiged on the request, then the gateway will randomly
        /// generate one.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// An identifier from an external point of sale system.
        /// </summary>
        [JsonProperty(PropertyName = "orderRef")]
        public string OrderRef { get; set; }

        /// <summary>
        /// The settlement account for merchants with split settlements.
        /// </summary>
        [JsonProperty(PropertyName = "destinationAccount")]
        public string DestinationAccount { get; set; }

        /// <summary>
        /// Whether or not to route transaction to the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// The request timeout in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }

        /// <summary>
        /// A location on the filesystem which a customer signature should be written to.
        /// </summary>
        [JsonProperty(PropertyName = "sigFile")]
        public string SigFile { get; set; }

        /// <summary>
        /// The image format to be used for returning signatures.
        /// </summary>
        [JsonProperty(PropertyName = "sigFormat")]
        public SignatureFormat SigFormat { get; set; }

        /// <summary>
        /// The width that the signature image should be scaled to, preserving the aspect
        /// ratio. If not provided, the signature is returned in the terminal's max
        /// resolution.
        /// </summary>
        [JsonProperty(PropertyName = "sigWidth")]
        public int SigWidth { get; set; }

        /// <summary>
        /// The name of the target payment terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }
    }
}
