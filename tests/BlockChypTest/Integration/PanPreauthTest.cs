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
    public class PanPreauthTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public PanPreauthTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_PanPreauthTest()
        {
            ShowTestOnTerminal("PanPreauth");

            AuthorizationRequest request = new AuthorizationRequest
            {
                Pan = "4111111111111111",
                Amount = "25.55",
                Test = true,
            };

            output.WriteLine("Request: {0}", request);

            AuthorizationResponse response = await blockchyp.PreauthAsync(request);

            output.WriteLine("Response: {0}", response);

            Assert.True(response.Success, "response.Success");
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
            Assert.Equal("25.55", response.AuthorizedAmount);
            Assert.Equal("KEYED", response.EntryMethod);
        }
    }
}
