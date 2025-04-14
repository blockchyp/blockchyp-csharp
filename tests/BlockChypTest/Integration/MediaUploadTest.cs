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
    public class MediaUploadTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public MediaUploadTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Upload")]
        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_MediaUploadTest()
        {



            UseProfile("");


            UploadMetadata request = new UploadMetadata
            {
                FileName = "aviato.png",
                FileSize = 18843,
                UploadId = Guid.NewGuid().ToString("N"),
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {

                FileStream inStream = new FileStream("../../../Integration/testdata/aviato.png", FileMode.Open, FileAccess.Read);
                MediaMetadata response = await blockchyp.UploadMediaAsync(request, inStream);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
                Assert.NotEmpty(response.Id);
                Assert.Equal("aviato.png", response.OriginalFile);
                Assert.NotEmpty(response.FileUrl);
                Assert.NotEmpty(response.ThumbnailUrl);
            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
