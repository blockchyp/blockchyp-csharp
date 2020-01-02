// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

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
    }
}
