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
    public class CancelPaymentLinkTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public CancelPaymentLinkTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_CancelPaymentLinkTest()
        {
            ShowTestOnTerminal("CancelPaymentLink");

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
                    EmailAddress = "support@blockchyp.com",
                    SmsNumber = "(123) 123-1231",
                },
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            PaymentLinkResponse setupResponse = await blockchyp.SendPaymentLinkAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);

            CancelPaymentLinkRequest request = new CancelPaymentLinkRequest
            {
                LinkCode = setupResponse.LinkCode,
            };

            output.WriteLine("Request: {0}", request);

            CancelPaymentLinkResponse response = await blockchyp.CancelPaymentLinkAsync(request);

            output.WriteLine("Response: {0}", response);

            Assert.True(response.Success, "response.Success");
        }
    }
}
