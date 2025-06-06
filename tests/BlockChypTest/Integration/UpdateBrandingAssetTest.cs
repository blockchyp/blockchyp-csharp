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
    public class UpdateBrandingAssetTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public UpdateBrandingAssetTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_UpdateBrandingAssetTest()
        {



            UseProfile("");

            UploadMetadata setupRequest = new UploadMetadata
            {
                FileName = "aviato.png",
                FileSize = 18843,
                UploadId = Guid.NewGuid().ToString("N"),
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            FileStream inStream = new FileStream("../../../Integration/testdata/aviato.png", FileMode.Open, FileAccess.Read);
            MediaMetadata setupResponse = await blockchyp.UploadMediaAsync(setupRequest, inStream);

            output.WriteLine("Setup Response: {0}", setupResponse);


            BrandingAsset request = new BrandingAsset
            {
                MediaId = setupResponse.Id,
                Padded = true,
                Ordinal = 10,
                StartDate = "01/06/2021",
                StartTime = "14:00",
                EndDate = "11/05/2024",
                EndTime = "16:00",
                Notes = "Test Branding Asset",
                Preview = false,
                Enabled = true,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                BrandingAsset response = await blockchyp.UpdateBrandingAssetAsync(request);
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
