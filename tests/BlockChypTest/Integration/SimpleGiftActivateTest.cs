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
    public class SimpleGiftActivateTest
    {
        private readonly ITestOutputHelper output;

        public SimpleGiftActivateTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_SimpleGiftActivateTest()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            GiftActivateRequest request = new GiftActivateRequest
            {
                Test = true,
                TerminalName = "Test Terminal",
                Amount = "50.00",
            };

            GiftActivateResponse response = await blockchyp.GiftActivateAsync(request);

            output.WriteLine("Response: {0}", JsonConvert.SerializeObject(response));

            Assert.True(response.Approved);
            Assert.NotEmpty(response.PublicKey);
        }
    }
}
