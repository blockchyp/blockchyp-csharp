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
    public class MerchantInvoicesTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public MerchantInvoicesTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_MerchantInvoicesTest()
        {



            UseProfile("");


            MerchantInvoiceListRequest request = new MerchantInvoiceListRequest
            {
                Test = true,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                MerchantInvoiceListResponse response = await blockchyp.MerchantInvoicesAsync(request);
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
