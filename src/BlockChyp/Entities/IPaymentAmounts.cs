// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Response details about tender amounts.
    /// </summary>
    public interface IPaymentAmounts
    {
        /// <summary>
        /// Whether or not the transaction was approved for a partial amount.
        /// </summary>
        bool PartialAuth { get; set; }

        /// <summary>
        /// Whether or not an alternate currency was used.
        /// </summary>
        bool AltCurrency { get; set; }

        /// <summary>
        /// Whether or not a request was settled on an FSA card.
        /// </summary>
        bool FsaAuth { get; set; }

        /// <summary>
        /// The currency code used for the transaction.
        /// </summary>
        string CurrencyCode { get; set; }

        /// <summary>
        /// The requested amount.
        /// </summary>
        string RequestedAmount { get; set; }

        /// <summary>
        /// The authorized amount. May not match the requested amount in the event of a
        /// partial auth.
        /// </summary>
        string AuthorizedAmount { get; set; }

        /// <summary>
        /// The remaining balance on the payment method.
        /// </summary>
        string RemainingBalance { get; set; }

        /// <summary>
        /// The tip amount.
        /// </summary>
        string TipAmount { get; set; }

        /// <summary>
        /// The tax amount.
        /// </summary>
        string TaxAmount { get; set; }

        /// <summary>
        /// The cash back amount the customer requested during the transaction.
        /// </summary>
        string RequestedCashBackAmount { get; set; }

        /// <summary>
        /// The amount of cash back authorized by the gateway. This amount will be the entire
        /// amount requested, or zero.
        /// </summary>
        string AuthorizedCashBackAmount { get; set; }
    }
}
