/**
 * Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is governed by a
 * license that can be found in the LICENSE file.
 *
 * This file was generated automatically. Changes to this file will be lost every time the
 * code is regenerated.
 */

using System;
using System.IO;
using BlockChyp.Entities;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace BlockChypTest.Integration
{
    public class NewTransactionDisplayTest
    {
        private readonly ITestOutputHelper output;

        public NewTransactionDisplayTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_NewTransactionDisplayTest()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            TransactionDisplayRequest request = new TransactionDisplayRequest
            {
                Test = true,
                TerminalName = "Test Terminal",
                Transaction = new TransactionDisplayTransaction
                {
                    Subtotal = "60.00",
                    Tax = "5.00",
                    Total = "65.00",
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

            Acknowledgement response = await blockchyp.NewTransactionDisplayAsync(request);

            output.WriteLine("Response: {0}", JsonConvert.SerializeObject(response));

            Assert.True(response.Success);
        }
    }
}
