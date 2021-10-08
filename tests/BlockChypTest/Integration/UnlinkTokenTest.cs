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
    public class UnlinkTokenTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public UnlinkTokenTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_UnlinkTokenTest()
        {
            ShowTestOnTerminal("UnlinkToken");

            EnrollRequest setupRequest = new EnrollRequest
            {
                Pan = "4111111111111111",
                Test = true,
                Customer = new Customer
                {
                    CustomerRef = "TESTCUSTOMER",
                    FirstName = "Test",
                    LastName = "Customer",
                },
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            EnrollResponse setupResponse = await blockchyp.EnrollAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);

            UnlinkTokenRequest request = new UnlinkTokenRequest
            {
                Token = setupResponse.Token,
                CustomerId = setupResponse.Customer.Id,
            };

            output.WriteLine("Request: {0}", request);

            Acknowledgement response = await blockchyp.UnlinkTokenAsync(request);

            output.WriteLine("Response: {0}", response);

            Assert.True(response.Success, "response.Success");
        }
    }
}
