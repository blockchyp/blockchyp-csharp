// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Request details about a payment method.
    /// </summary>
    public interface IPaymentMethod
    {
        /// <summary>
        /// The payment token to be used for this transaction. This should be used for
        /// recurring transactions.
        /// </summary>
        string Token { get; set; }

        /// <summary>
        /// Track 1 magnetic stripe data.
        /// </summary>
        string Track1 { get; set; }

        /// <summary>
        /// Track 2 magnetic stripe data.
        /// </summary>
        string Track2 { get; set; }

        /// <summary>
        /// The primary account number. We recommend using the terminal or e-commerce
        /// tokenization libraries instead of passing account numbers in directly, as
        /// this would put your application in PCI scope.
        /// </summary>
        string Pan { get; set; }

        /// <summary>
        /// The ACH routing number for ACH transactions.
        /// </summary>
        string RoutingNumber { get; set; }

        /// <summary>
        /// The cardholder name. Only required if the request includes a primary account
        /// number or track data.
        /// </summary>
        string CardholderName { get; set; }

        /// <summary>
        /// The card expiration month for use with PAN based transactions.
        /// </summary>
        string ExpMonth { get; set; }

        /// <summary>
        /// The card expiration year for use with PAN based transactions.
        /// </summary>
        string ExpYear { get; set; }

        /// <summary>
        /// The card CVV for use with PAN based transactions.
        /// </summary>
        string Cvv { get; set; }

        /// <summary>
        /// The cardholder address for use with address verification.
        /// </summary>
        string Address { get; set; }

        /// <summary>
        /// The cardholder postal code for use with address verification.
        /// </summary>
        string PostalCode { get; set; }

        /// <summary>
        /// The cardholder country.
        /// </summary>
        string Country { get; set; }

        /// <summary>
        /// That the payment entry method is a manual keyed transaction. If this is true, no
        /// other payment method will be accepted.
        /// </summary>
        bool ManualEntry { get; set; }

        /// <summary>
        /// The key serial number used for DUKPT encryption.
        /// </summary>
        string Ksn { get; set; }

        /// <summary>
        /// The encrypted pin block.
        /// </summary>
        string PinBlock { get; set; }

        /// <summary>
        /// Designates categories of cards: credit, debit, EBT.
        /// </summary>
        CardType CardType { get; set; }

        /// <summary>
        /// Designates brands of payment methods: Visa, Discover, etc.
        /// </summary>
        string PaymentType { get; set; }
    }
}
