// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a low level request with a timeout and test flag.
    /// </summary>
    public interface ITimeoutRequest
    {
        /// <summary>
        /// The request timeout in seconds.
        /// </summary>
        int Timeout { get; set; }

        /// <summary>
        /// Whether or not to route transaction to the test gateway.
        /// </summary>
        bool Test { get; set; }
    }
}
