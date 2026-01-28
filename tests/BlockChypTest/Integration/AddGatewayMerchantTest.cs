// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
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
    public class AddGatewayMerchantTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public AddGatewayMerchantTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "partner")]
        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_AddGatewayMerchantTest()
        {



            UseProfile("partner");


            AddGatewayMerchantRequest request = new AddGatewayMerchantRequest
            {
                Profile = new MerchantProfile
                {
                    DbaName = "DBA Name",
                    CompanyName = "Corporate Entity Name",
                },
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                MerchantProfileResponse response = await blockchyp.AddGatewayMerchantAsync(request);
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
