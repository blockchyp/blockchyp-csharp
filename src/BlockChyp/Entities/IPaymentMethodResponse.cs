// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Response details about a payment method.
    /// </summary>
    public interface IPaymentMethodResponse
    {
        /// <summary>
        /// The payment token, if the payment was enrolled in the vault.
        /// </summary>
        string Token { get; set; }

        /// <summary>
        /// The entry method for the transaction (CHIP, MSR, KEYED, etc).
        /// </summary>
        string EntryMethod { get; set; }

        /// <summary>
        /// The card brand (VISA, MC, AMEX, etc).
        /// </summary>
        string PaymentType { get; set; }

        /// <summary>
        /// The masked primary account number.
        /// </summary>
        string MaskedPan { get; set; }

        /// <summary>
        /// The BlockChyp public key if the user presented a BlockChyp payment card.
        /// </summary>
        string PublicKey { get; set; }

        /// <summary>
        /// That the transaction did something that would put the system in PCI scope.
        /// </summary>
        bool ScopeAlert { get; set; }

        /// <summary>
        /// The cardholder name.
        /// </summary>
        string CardHolder { get; set; }

        /// <summary>
        /// The card expiration month in MM format.
        /// </summary>
        string ExpMonth { get; set; }

        /// <summary>
        /// The card expiration year in YY format.
        /// </summary>
        string ExpYear { get; set; }

        /// <summary>
        /// Address verification results if address information was submitted.
        /// </summary>
        AvsResponse AvsResponse { get; set; }

        /// <summary>
        /// Suggested receipt fields.
        /// </summary>
        ReceiptSuggestions ReceiptSuggestions { get; set; }

        /// <summary>
        /// Customer data, if any.
        /// </summary>
        Customer Customer { get; set; }
    }
}
