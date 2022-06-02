// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System;
using System.Collections.Generic;
using System.IO;
using BlockChyp.Entities;
using Xunit;
using Xunit.Abstractions;

namespace BlockChypTest.Integration
{
    public class TerminalQueuedTransactionTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public TerminalQueuedTransactionTest(ITestOutputHelper output)
        {
            this.output = output;
        }



        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_TerminalQueuedTransactionTest()
        {


            UseProfile("");
            ShowTestOnTerminal("TerminalQueuedTransaction");


            UseProfile("");


            AuthorizationRequest request = new AuthorizationRequest
            {
                TerminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                TransactionRef = Guid.NewGuid().ToString("N"),
                Description = "1060 West Addison",
                Amount = "25.15",
                Test = true,
                Queue = true,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                AuthorizationResponse response = await blockchyp.ChargeAsync(request);
                output.WriteLine("Response: {0}", response);                                                            Assert.True(response.Success, "response.Success");
                                                                                                                                                                                            Assert.False(response.Approved, "response.Approved");
                                                                                                                                                                                                                            Assert.Equal("Queued", response.ResponseDescription);
                                                            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
