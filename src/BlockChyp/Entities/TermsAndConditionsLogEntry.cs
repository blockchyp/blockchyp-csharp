// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a Terms and Conditions log entry.
    /// </summary>
    public class TermsAndConditionsLogEntry : BaseEntity, IAbstractAcknowledgement
    {
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
        /// Internal id for a Terms and Conditions entry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Id of the terminal that captured this terms and conditions entry.
        /// </summary>
        [JsonProperty(PropertyName = "terminalId")]
        public string TerminalId { get; set; }

        /// <summary>
        /// Name of the terminal that captured this terms and conditions entry.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// A flag indicating whether or not the terminal was a test terminal.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// Date and time the terms and conditions acceptance occurred.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Optional transaction ref if the terms and conditions was associated with a
        /// transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// Optional transaction id if only log entries related to a transaction should be
        /// returned.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Alias of the terms and conditions template used for this entry, if any.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public string Alias { get; set; }

        /// <summary>
        /// Title of the document displayed on the terminal at the time of capture.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Full text of the document agreed to at the time of signature capture.
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        /// <summary>
        /// First 32 characters of the full text. Used to support user interfaces that show
        /// summaries.
        /// </summary>
        [JsonProperty(PropertyName = "contentLeader")]
        public string ContentLeader { get; set; }

        /// <summary>
        /// A flag that indicates whether or not a signature has been captured.
        /// </summary>
        [JsonProperty(PropertyName = "hasSignature")]
        public bool HasSignature { get; set; }

        /// <summary>
        /// The image format to be used for returning signatures.
        /// </summary>
        [JsonProperty(PropertyName = "sigFormat")]
        public SignatureFormat SigFormat { get; set; }

        /// <summary>
        /// The base 64 encoded signature image if the format requested.
        /// </summary>
        [JsonProperty(PropertyName = "signature")]
        public string Signature { get; set; }
    }
}
