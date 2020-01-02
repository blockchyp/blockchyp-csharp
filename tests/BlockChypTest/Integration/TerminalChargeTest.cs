// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using System;
using System.Collections.Generic;
using System.IO;
using BlockChyp.Entities;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace BlockChypTest.Integration
{
    public class TerminalChargeTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public TerminalChargeTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_TerminalChargeTest()
        {
            ShowTestOnTerminal("TerminalCharge");

            AuthorizationRequest request = new AuthorizationRequest
            {
                TerminalName = "Test Terminal",
                Amount = "25.15",
                Test = true,
            };

            output.WriteLine("Request: {0}", JsonConvert.SerializeObject(request));

            AuthorizationResponse response = await blockchyp.ChargeAsync(request);

            output.WriteLine("Response: {0}", JsonConvert.SerializeObject(response));

            Assert.True(response.Approved, "response.Approved");
            Assert.True(response.Test, "response.Test");
            Assert.Equal(6, response.AuthCode.Length);
            Assert.NotEmpty(response.TransactionId);
            Assert.NotEmpty(response.Timestamp);
            Assert.NotEmpty(response.TickBlock);
            Assert.Equal("Approved", response.ResponseDescription);
            Assert.NotEmpty(response.PaymentType);
            Assert.NotEmpty(response.MaskedPan);
            Assert.NotEmpty(response.EntryMethod);
            Assert.Equal("25.15", response.AuthorizedAmount);
        }
    }
}
