// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
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
    public class ListQueuedTransactionsTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public ListQueuedTransactionsTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_ListQueuedTransactionsTest()
        {


            UseProfile("");
            ShowTestOnTerminal("ListQueuedTransactions");


            UseProfile("");

            AuthorizationRequest setupRequest = new AuthorizationRequest
            {
                TerminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                TransactionRef = Guid.NewGuid().ToString("N"),
                Description = "1060 West Addison",
                Amount = "25.15",
                Test = true,
                Queue = true,
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            AuthorizationResponse setupResponse = await blockchyp.ChargeAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);


            ListQueuedTransactionsRequest request = new ListQueuedTransactionsRequest
            {
                TerminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                ListQueuedTransactionsResponse response = await blockchyp.ListQueuedTransactionsAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
                            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
