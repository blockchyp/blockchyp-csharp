// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Core request fields for a transaction.
    /// </summary>
    public interface ICoreRequest
    {
        /// <summary>
        /// A user-assigned reference that can be used to recall or reverse transactions.
        /// </summary>
        string TransactionRef { get; set; }

        /// <summary>
        /// That the transaction reference was autogenerated and should be ignored for the
        /// purposes of duplicate detection.
        /// </summary>
        bool AutogeneratedRef { get; set; }

        /// <summary>
        /// Defers the response to the transaction and returns immediately. Callers
        /// should retrive the transaction result using the Transaction Status API.
        /// </summary>
        bool Async { get; set; }

        /// <summary>
        /// Adds the transaction to the queue and returns immediately. Callers should
        /// retrive the transaction result using the Transaction Status API.
        /// </summary>
        bool Queue { get; set; }

        /// <summary>
        /// Whether or not the request should block until all cards have been removed from
        /// the card reader.
        /// </summary>
        bool WaitForRemovedCard { get; set; }

        /// <summary>
        /// Override any in-progress transactions.
        /// </summary>
        bool Force { get; set; }

        /// <summary>
        /// An identifier from an external point of sale system.
        /// </summary>
        string OrderRef { get; set; }

        /// <summary>
        /// The settlement account for merchants with split settlements.
        /// </summary>
        string DestinationAccount { get; set; }

        /// <summary>
        /// Can include a code used to trigger simulated conditions for the purposes of
        /// testing and certification. Valid for test merchant accounts only.
        /// </summary>
        string TestCase { get; set; }
    }
}
