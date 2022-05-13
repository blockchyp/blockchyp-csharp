// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Response details for a cryptocurrency transaction.
    /// </summary>
    public interface ICryptocurrencyResponse
    {
        /// <summary>
        /// That the transaction has met the standard criteria for confirmation on the
        /// network. (For example, 6 confirmations for level one bitcoin.)
        /// </summary>
        bool Confirmed { get; set; }

        /// <summary>
        /// The amount submitted to the blockchain.
        /// </summary>
        string CryptoAuthorizedAmount { get; set; }

        /// <summary>
        /// The network level fee assessed for the transaction denominated in
        /// cryptocurrency. This fee goes to channel operators and crypto miners, not
        /// BlockChyp.
        /// </summary>
        string CryptoNetworkFee { get; set; }

        /// <summary>
        /// The three letter cryptocurrency code used for the transactions.
        /// </summary>
        string Cryptocurrency { get; set; }

        /// <summary>
        /// Whether or not the transaction was processed on the level one or level two
        /// network.
        /// </summary>
        string CryptoNetwork { get; set; }

        /// <summary>
        /// The address on the crypto network the transaction was sent to.
        /// </summary>
        string CryptoReceiveAddress { get; set; }

        /// <summary>
        /// Hash or other identifier that identifies the block on the cryptocurrency
        /// network, if available or relevant.
        /// </summary>
        string CryptoBlock { get; set; }

        /// <summary>
        /// Hash or other transaction identifier that identifies the transaction on the
        /// cryptocurrency network, if available or relevant.
        /// </summary>
        string CryptoTransactionId { get; set; }

        /// <summary>
        /// The payment request URI used for the transaction, if available.
        /// </summary>
        string CryptoPaymentRequest { get; set; }

        /// <summary>
        /// Used for additional status information related to crypto transactions.
        /// </summary>
        string CryptoStatus { get; set; }
    }
}
