// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Customer signature data.
    /// </summary>
    public interface ISignatureResponse
    {
        /// <summary>
        /// The hex encoded signature data.
        /// </summary>
        string SigFile { get; set; }
    }
}
