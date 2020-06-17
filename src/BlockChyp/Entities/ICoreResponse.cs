// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Core response fields for a transaction.
    /// </summary>
    public interface ICoreResponse
    {
        /// <summary>
        /// The ID assigned to the transaction.
        /// </summary>
        string TransactionId { get; set; }

        /// <summary>
        /// The ID assigned to the batch.
        /// </summary>
        string BatchId { get; set; }

        /// <summary>
        /// The transaction reference string assigned to the transaction request. If no
        /// transaction ref was assiged on the request, then the gateway will randomly
        /// generate one.
        /// </summary>
        string TransactionRef { get; set; }

        /// <summary>
        /// The type of transaction.
        /// </summary>
        string TransactionType { get; set; }

        /// <summary>
        /// The timestamp of the transaction.
        /// </summary>
        string Timestamp { get; set; }

        /// <summary>
        /// The hash of the last tick block.
        /// </summary>
        string TickBlock { get; set; }

        /// <summary>
        /// That the transaction was processed on the test gateway.
        /// </summary>
        bool Test { get; set; }

        /// <summary>
        /// The settlement account for merchants with split settlements.
        /// </summary>
        string DestinationAccount { get; set; }

        /// <summary>
        /// The ECC signature of the response. Can be used to ensure that it was signed by the
        /// terminal and detect man-in-the middle attacks.
        /// </summary>
        string Sig { get; set; }
    }
}
