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
    public class UpdateTransactionDisplayTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public UpdateTransactionDisplayTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_UpdateTransactionDisplayTest()
        {
            ShowTestOnTerminal("UpdateTransactionDisplay");

            TransactionDisplayRequest request = new TransactionDisplayRequest
            {
                Test = true,
                TerminalName = "Test Terminal",
                Transaction = new TransactionDisplayTransaction
                {
                    Subtotal = "35.00",
                    Tax = "5.00",
                    Total = "70.00",
                    Items = new List<TransactionDisplayItem>
                    {
                        new TransactionDisplayItem
                        {
                            Description = "Leki Trekking Poles",
                            Price = "35.00",
                            Quantity = 2,
                            Extended = "70.00",
                            Discounts = new List<TransactionDisplayDiscount>
                            {
                                new TransactionDisplayDiscount
                                {
                                    Description = "memberDiscount",
                                    Amount = "10.00",
                                }
                            },
                        }
                    },
                },
            };

            output.WriteLine("Request: {0}", request);

            Acknowledgement response = await blockchyp.UpdateTransactionDisplayAsync(request);

            output.WriteLine("Response: {0}", response);

            Assert.True(response.Success, "response.Success");
        }
    }
}
