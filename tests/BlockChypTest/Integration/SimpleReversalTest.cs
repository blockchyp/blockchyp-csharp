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
    public class SimpleReversalTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public SimpleReversalTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_SimpleReversalTest()
        {
            ShowTestOnTerminal("SimpleReversal");

            AuthorizationRequest setupRequest = new AuthorizationRequest
            {
                Pan = "4111111111111111",
                ExpMonth = "12",
                ExpYear = "2025",
                Amount = "25.55",
                Test = true,
                TransactionRef = Guid.NewGuid().ToString("N"),
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            AuthorizationResponse setupResponse = await blockchyp.ChargeAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);

            AuthorizationRequest request = new AuthorizationRequest
            {
                TransactionRef = setupResponse.TransactionRef,
                Test = true,
            };

            output.WriteLine("Request: {0}", request);

            AuthorizationResponse response = await blockchyp.ReverseAsync(request);

            output.WriteLine("Response: {0}", response);

            Assert.True(response.Success, "response.Success");
            Assert.True(response.Approved, "response.Approved");
        }
    }
}
