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
    public class SimpleGiftActivateTest : IntegrationTest
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
            ShowTestOnTerminal("SimpleGiftActivate");

            GiftActivateRequest request = new GiftActivateRequest
            {
                Test = true,
                TerminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                Amount = "50.00",
            };

            output.WriteLine("Request: {0}", request);

            GiftActivateResponse response = await blockchyp.GiftActivateAsync(request);

            output.WriteLine("Response: {0}", response);

            Assert.True(response.Success, "response.Success");
            Assert.True(response.Approved, "response.Approved");
            Assert.NotEmpty(response.PublicKey);
        }
    }
}
