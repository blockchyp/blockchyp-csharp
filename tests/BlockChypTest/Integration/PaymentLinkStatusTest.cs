// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
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
    public class PaymentLinkStatusTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public PaymentLinkStatusTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_PaymentLinkStatusTest()
        {



            UseProfile("");

            PaymentLinkRequest setupRequest = new PaymentLinkRequest
            {
                Amount = "199.99",
                Description = "Widget",
                Subject = "Widget invoice",
                Transaction = new TransactionDisplayTransaction
                {
                    Subtotal = "195.00",
                    Tax = "4.99",
                    Total = "199.99",
                    Items = new List<TransactionDisplayItem>
                    {
                        new TransactionDisplayItem
                        {
                            Description = "Widget",
                            Price = "195.00",
                            Quantity = 1,
                        }
                    },
                },
                AutoSend = true,
                Customer = new Customer
                {
                    CustomerRef = "Customer reference string",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    CompanyName = "Company Name",
                    EmailAddress = "notifications@blockchypteam.m8r.co",
                    SmsNumber = "(123) 123-1231",
                },
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            PaymentLinkResponse setupResponse = await blockchyp.SendPaymentLinkAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);


            PaymentLinkStatusRequest request = new PaymentLinkStatusRequest
            {
                LinkCode = setupResponse.LinkCode,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                PaymentLinkStatusResponse response = await blockchyp.PaymentLinkStatusAsync(request);
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
