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
    public class UpdateTokenTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public UpdateTokenTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_UpdateTokenTest()
        {



            UseProfile("");

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


            UpdateTokenRequest request = new UpdateTokenRequest
            {
                Token = setupResponse.Token,
                ExpiryMonth = "12",
                ExpiryYear = "2040",
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                UpdateTokenResponse response = await blockchyp.UpdateTokenAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
