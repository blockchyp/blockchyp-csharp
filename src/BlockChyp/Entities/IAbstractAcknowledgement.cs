// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Fields which should be returned with standard requests.
    /// </summary>
    public interface IAbstractAcknowledgement
    {
        /// <summary>
        /// Whether or not the request succeeded.
        /// </summary>
        bool Success { get; set; }

        /// <summary>
        /// The error, if an error occurred.
        /// </summary>
        string Error { get; set; }

        /// <summary>
        /// A narrative description of the transaction result.
        /// </summary>
        string ResponseDescription { get; set; }
    }
}
