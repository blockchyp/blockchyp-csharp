// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using System;
using System.Collections.Generic;
using System.IO;
using BlockChyp.Entities;
using Xunit;
using Xunit.Abstractions;

namespace BlockChypTest.Integration
{
    public class TerminalTimeoutTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public TerminalTimeoutTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_TerminalTimeoutTest()
        {
            ShowTestOnTerminal("TerminalTimeout");

            AuthorizationRequest request = new AuthorizationRequest
            {
                Timeout = 1,
                TerminalName = "Test Terminal",
                Amount = "25.15",
                Test = true,
            };

            output.WriteLine("Request: {0}", request);

            await Assert.ThrowsAsync<TimeoutException>(() => blockchyp.ChargeAsync(request));
        }
    }
}
