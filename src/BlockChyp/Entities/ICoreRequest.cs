// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Core request fields for a transaction.
    /// </summary>
    public interface ICoreRequest
    {
        /// <summary>
        /// The transaction reference string assigned to the transaction request. If no
        /// transaction ref was assiged on the request, then the gateway will randomly
        /// generate one.
        /// </summary>
        string TransactionRef { get; set; }

        /// <summary>
        /// An identifier from an external point of sale system.
        /// </summary>
        string OrderRef { get; set; }

        /// <summary>
        /// The settlement account for merchants with split settlements.
        /// </summary>
        string DestinationAccount { get; set; }

        /// <summary>
        /// Whether or not to route transaction to the test gateway.
        /// </summary>
        bool Test { get; set; }

        /// <summary>
        /// The request timeout in milliseconds.
        /// </summary>
        int Timeout { get; set; }
    }
}
