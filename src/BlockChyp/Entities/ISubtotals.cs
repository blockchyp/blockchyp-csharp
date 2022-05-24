// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Request subtotals.
    /// </summary>
    public interface ISubtotals
    {
        /// <summary>
        /// The tip amount.
        /// </summary>
        string TipAmount { get; set; }

        /// <summary>
        /// The tax amount.
        /// </summary>
        string TaxAmount { get; set; }

        /// <summary>
        /// The amount of the transaction that should be charged to an FSA card. This amount
        /// may be less than the transaction total, in which case only this amount will be
        /// charged if an FSA card is presented. If the FSA amount is paid on an FSA card, then
        /// the FSA amount authorized will be indicated on the response.
        /// </summary>
        string FsaEligibleAmount { get; set; }

        /// <summary>
        /// The amount of the transaction that should be charged to an HSA card.
        /// </summary>
        string HsaEligibleAmount { get; set; }

        /// <summary>
        /// The amount of the transaction that should be charged to an EBT card.
        /// </summary>
        string EbtEligibleAmount { get; set; }
    }
}
