// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Request details about tender amounts.
    /// </summary>
    public interface IRequestAmount
    {
        /// <summary>
        /// The transaction currency code.
        /// </summary>
        string CurrencyCode { get; set; }

        /// <summary>
        /// The requested amount.
        /// </summary>
        string Amount { get; set; }

        /// <summary>
        /// That the request is tax exempt. Only required for tax exempt level 2 processing.
        /// </summary>
        bool TaxExempt { get; set; }

        /// <summary>
        /// A flag to add a surcharge to the transaction to cover credit card fees, if
        /// permitted.
        /// </summary>
        bool Surcharge { get; set; }

        /// <summary>
        /// A flag that applies a discount to negate the surcharge for debit transactions or
        /// other surcharge ineligible payment methods.
        /// </summary>
        bool CashDiscount { get; set; }
    }
}
