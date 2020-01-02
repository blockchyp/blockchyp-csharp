// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

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
    }
}
