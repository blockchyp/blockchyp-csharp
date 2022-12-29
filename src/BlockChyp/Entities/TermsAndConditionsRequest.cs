// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// The fields needed for custom Terms and Conditions prompts.
    /// </summary>
    public class TermsAndConditionsRequest : BaseEntity, ITimeoutRequest, ICoreRequest, IPreviousTransaction, ISignatureRequest, ITerminalReference
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
        /// A user-assigned reference that can be used to recall or reverse transactions.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// Defers the response to the transaction and returns immediately. Callers
        /// should retrive the transaction result using the Transaction Status API.
        /// </summary>
        [JsonProperty(PropertyName = "async")]
        public bool Async { get; set; }

        /// <summary>
        /// Adds the transaction to the queue and returns immediately. Callers should
        /// retrive the transaction result using the Transaction Status API.
        /// </summary>
        [JsonProperty(PropertyName = "queue")]
        public bool Queue { get; set; }

        /// <summary>
        /// Whether or not the request should block until all cards have been removed from
        /// the card reader.
        /// </summary>
        [JsonProperty(PropertyName = "waitForRemovedCard")]
        public bool WaitForRemovedCard { get; set; }

        /// <summary>
        /// Override any in-progress transactions.
        /// </summary>
        [JsonProperty(PropertyName = "force")]
        public bool Force { get; set; }

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
        /// The ID of the previous transaction being referenced.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

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
        /// Whether or not signature prompt should be skipped on the terminal. The terminal
        /// will indicate whether or not a signature is required by the card in the receipt
        /// suggestions response.
        /// </summary>
        [JsonProperty(PropertyName = "disableSignature")]
        public bool DisableSignature { get; set; }

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
        /// An alias for a Terms and Conditions template configured in the BlockChyp
        /// dashboard.
        /// </summary>
        [JsonProperty(PropertyName = "tcAlias")]
        public string TcAlias { get; set; }

        /// <summary>
        /// The name of the Terms and Conditions the user is accepting.
        /// </summary>
        [JsonProperty(PropertyName = "tcName")]
        public string TcName { get; set; }

        /// <summary>
        /// The content of the terms and conditions that will be presented to the user.
        /// </summary>
        [JsonProperty(PropertyName = "tcContent")]
        public string TcContent { get; set; }

        /// <summary>
        /// A hash of the terms and conditions content that can be used for caching.
        /// </summary>
        [JsonProperty(PropertyName = "contentHash")]
        public string ContentHash { get; set; }

        /// <summary>
        /// That a signature should be requested.
        /// </summary>
        [JsonProperty(PropertyName = "sigRequired")]
        public bool SigRequired { get; set; }
    }
}
