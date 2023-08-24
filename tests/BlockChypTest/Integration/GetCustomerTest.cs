// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
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
    public class GetCustomerTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public GetCustomerTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_GetCustomerTest()
        {



            UseProfile("");

            UpdateCustomerRequest setupRequest = new UpdateCustomerRequest
            {
                Customer = new Customer
                {
                    FirstName = "Test",
                    LastName = "Customer",
                    CompanyName = "Test Company",
                    EmailAddress = "support@blockchyp.com",
                    SmsNumber = "(123) 123-1234",
                },
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            CustomerResponse setupResponse = await blockchyp.UpdateCustomerAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);


            CustomerRequest request = new CustomerRequest
            {
                CustomerId = setupResponse.Customer.Id,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                CustomerResponse response = await blockchyp.CustomerAsync(request);
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
