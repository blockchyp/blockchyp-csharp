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
    public class UpdateMerchantPlatformsTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public UpdateMerchantPlatformsTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "partner")]
        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_UpdateMerchantPlatformsTest()
        {



            UseProfile("partner");

            AddTestMerchantRequest setupRequest = new AddTestMerchantRequest
            {
                DbaName = "Test Merchant",
                CompanyName = "Test Merchant",
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            MerchantProfileResponse setupResponse = await blockchyp.AddTestMerchantAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);


            MerchantPlatform request = new MerchantPlatform
            {
                MerchantId = setupResponse.MerchantId,
                PlatformCode = "SIM",
                Notes = "platform simulator",
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                Acknowledgement response = await blockchyp.UpdateMerchantPlatformsAsync(request);
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
