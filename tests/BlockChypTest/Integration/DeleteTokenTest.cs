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
    public class DeleteTokenTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public DeleteTokenTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_DeleteTokenTest()
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


            DeleteTokenRequest request = new DeleteTokenRequest
            {
                Token = setupResponse.Token,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                DeleteTokenResponse response = await blockchyp.DeleteTokenAsync(request);
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
