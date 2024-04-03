// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// A reference to a terminal name.
    /// </summary>
    public interface ITerminalReference
    {
        /// <summary>
        /// The name of the target payment terminal.
        /// </summary>
        string TerminalName { get; set; }

        /// <summary>
        /// Forces the terminal cloud connection to be reset while a transactions is in
        /// flight. This is a diagnostic settings that can be used only for test
        /// transactions.
        /// </summary>
        bool ResetConnection { get; set; }
    }
}
