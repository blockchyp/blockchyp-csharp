// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
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
    }
}
