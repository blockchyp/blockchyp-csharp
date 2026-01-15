// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
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
    public class GatewayTimeoutTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public GatewayTimeoutTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_GatewayTimeoutTest()
        {


            UseProfile("");
            ShowTestOnTerminal("GatewayTimeout");


            UseProfile("");


            AuthorizationRequest request = new AuthorizationRequest
            {
                Timeout = 1,
                Pan = "5555555555554444",
                ExpMonth = "12",
                ExpYear = "2025",
                Amount = "25.55",
                Test = true,
                TransactionRef = Guid.NewGuid().ToString("N"),
            };

            output.WriteLine("Request: {0}", request);

            await Assert.ThrowsAsync<TimeoutException>(() => blockchyp.ChargeAsync(request));
        }
    }
}
