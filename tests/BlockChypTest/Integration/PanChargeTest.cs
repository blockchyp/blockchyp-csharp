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
    public class PanChargeTest
    {
        private readonly ITestOutputHelper output;

        public PanChargeTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_PanChargeTest()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            AuthorizationRequest request = new AuthorizationRequest
            {
                Test = true,
                TerminalName = "Test Terminal",
                Amount = "55.00",
            };

            AuthorizationResponse response = await blockchyp.ChargeAsync(request);

            output.WriteLine("Response: {0}", JsonConvert.SerializeObject(response));

            Assert.True(response.Approved);
            Assert.True(response.Test);
            Assert.Equal(6, response.AuthCode.Count())
            Assert.NotEmpty(response.TransactionId);
            Assert.NotEmpty(response.Timestamp);
            Assert.NotEmpty(response.TickBlock);
            Assert.Equal("Approved", response.ResponseDescription);
            Assert.NotEmpty(response.PaymentType);
            Assert.NotEmpty(response.MaskedPan);
            Assert.NotEmpty(response.EntryMethod);
            Assert.Equal("25.55", response.AuthorizedAmount);
            Assert.Equal("KEYED", response.EntryMethod);
        }
    }
}
