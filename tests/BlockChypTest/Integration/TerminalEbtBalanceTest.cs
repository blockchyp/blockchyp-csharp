/**
 * Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is governed by a
 * license that can be found in the LICENSE file.
 *
 * This file was generated automatically. Changes to this file will be lost every time the
 * code is regenerated.
 */

using System;
using System.IO;
using BlockChyp.Entities;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace BlockChypTest.Integration
{
    public class TerminalEbtBalanceTest
    {
        private readonly ITestOutputHelper output;

        public TerminalEbtBalanceTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_TerminalEbtBalanceTest()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            BalanceRequest request = new BalanceRequest
            {
                Test = true,
                TerminalName = "Test Terminal",
                CardType = CardType.EBT,
            };

            BalanceResponse response = await blockchyp.BalanceAsync(request);

            output.WriteLine("Response: {0}", JsonConvert.SerializeObject(response));

            Assert.True(response.Success);
            Assert.NotEmpty(response.RemainingBalance);
        }
    }
}
