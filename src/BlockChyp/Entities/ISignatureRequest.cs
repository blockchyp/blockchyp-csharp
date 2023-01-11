// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// A request for customer signature data.
    /// </summary>
    public interface ISignatureRequest
    {
        /// <summary>
        /// A location on the filesystem which a customer signature should be written to.
        /// </summary>
        string SigFile { get; set; }

        /// <summary>
        /// The image format to be used for returning signatures.
        /// </summary>
        SignatureFormat SigFormat { get; set; }

        /// <summary>
        /// The width that the signature image should be scaled to, preserving the aspect
        /// ratio. If not provided, the signature is returned in the terminal's max
        /// resolution.
        /// </summary>
        int SigWidth { get; set; }

        /// <summary>
        /// Whether or not signature prompt should be skipped on the terminal. The terminal
        /// will indicate whether or not a signature is required by the card in the receipt
        /// suggestions response.
        /// </summary>
        bool DisableSignature { get; set; }
    }
}
