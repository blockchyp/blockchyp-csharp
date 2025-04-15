// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
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
    public class PartialRefundTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public PartialRefundTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_PartialRefundTest()
        {


            UseProfile("");
            ShowTestOnTerminal("PartialRefund");


            UseProfile("");

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


            RefundRequest request = new RefundRequest
            {
                TransactionId = setupResponse.TransactionId,
                Amount = "5.00",
                Test = true,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                AuthorizationResponse response = await blockchyp.RefundAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
                Assert.True(response.Approved, "response.Approved");
            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
