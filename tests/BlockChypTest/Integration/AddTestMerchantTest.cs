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
    public class AddTestMerchantTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public AddTestMerchantTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "partner")]
        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_AddTestMerchantTest()
        {



            UseProfile("partner");


            AddTestMerchantRequest request = new AddTestMerchantRequest
            {
                DbaName = "Test Merchant",
                CompanyName = "Test Merchant",
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                MerchantProfileResponse response = await blockchyp.AddTestMerchantAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
                Assert.Equal("Test Merchant", response.DbaName);
                Assert.Equal("Test Merchant", response.CompanyName);
                Assert.True(response.Visa, "response.Visa");
            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
