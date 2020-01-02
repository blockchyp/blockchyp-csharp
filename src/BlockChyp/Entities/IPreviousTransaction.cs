// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// A reference to a previous transaction.
    /// </summary>
    public interface IPreviousTransaction
    {
        /// <summary>
        /// The ID of the previous transaction being referenced.
        /// </summary>
        string TransactionId { get; set; }
    }
}
