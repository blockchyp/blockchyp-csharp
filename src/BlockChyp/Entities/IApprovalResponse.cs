// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Response fields for an approved transaction.
    /// </summary>
    public interface IApprovalResponse
    {
        /// <summary>
        /// That the transaction was approved.
        /// </summary>
        bool Approved { get; set; }

        /// <summary>
        /// The auth code from the payment network.
        /// </summary>
        string AuthCode { get; set; }

        /// <summary>
        /// The code returned by the terminal or the card issuer to indicate the disposition
        /// of the message.
        /// </summary>
        string AuthResponseCode { get; set; }
    }
}
