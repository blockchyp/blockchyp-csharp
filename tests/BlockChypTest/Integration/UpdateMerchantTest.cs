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
    public class UpdateMerchantTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public UpdateMerchantTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "partner")]
        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_UpdateMerchantTest()
        {



            UseProfile("partner");


            MerchantProfile request = new MerchantProfile
            {
                Test = true,
                DbaName = "Test Merchant",
                CompanyName = "Test Merchant",
                BillingAddress = new Address
                {
                    Address1 = "1060 West Addison",
                    City = "Chicago",
                    StateOrProvince = "IL",
                    PostalCode = "60613",
                },
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                MerchantProfileResponse response = await blockchyp.UpdateMerchantAsync(request);
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
