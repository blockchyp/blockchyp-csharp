// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
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
    public class DeleteMediaAssetTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public DeleteMediaAssetTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_DeleteMediaAssetTest()
        {
            ShowTestOnTerminal("DeleteMediaAsset");

            UploadMetadata setupRequest = new UploadMetadata
            {
                FileName = "aviato.png",
                FileSize = 18843,
                UploadId = Guid.NewGuid().ToString("N"),
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            MediaMetadata setupResponse = await blockchyp.UploadMediaAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);

            MediaRequest request = new MediaRequest
            {
                MediaId = ,
            };

            output.WriteLine("Request: {0}", request);

            Acknowledgement response = await blockchyp.DeleteMediaAssetAsync(request);

            output.WriteLine("Response: {0}", response);

            Assert.True(response.Success, "response.Success");
        }
    }
}
