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
    public class SimpleCaptureTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public SimpleCaptureTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_SimpleCaptureTest()
        {
            ShowTestOnTerminal("SimpleCapture");

            AuthorizationRequest setupRequest = new AuthorizationRequest
            {
                Pan = "4111111111111111",
                Amount = "25.55",
                Test = true,
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            AuthorizationResponse setupResponse = await blockchyp.PreauthAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);

            CaptureRequest request = new CaptureRequest
            {
                TransactionId = setupResponse.TransactionId,
                Test = true,
            };

            output.WriteLine("Request: {0}", request);

            CaptureResponse response = await blockchyp.CaptureAsync(request);

            output.WriteLine("Response: {0}", response);

            Assert.True(response.Success, "response.Success");
            Assert.True(response.Approved, "response.Approved");
        }
    }
}
