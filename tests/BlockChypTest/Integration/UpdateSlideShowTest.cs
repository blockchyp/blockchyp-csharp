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
    public class UpdateSlideShowTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public UpdateSlideShowTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_UpdateSlideShowTest()
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


            SlideShow request = new SlideShow
            {
                Name = "Test Slide Show",
                Delay = 5,
                Slides = new List<Slide>
                {
                    new Slide
                    {
                        MediaId = setupResponse.Id,
                    }
                },
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                SlideShow response = await blockchyp.UpdateSlideShowAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
                Assert.Equal("Test Slide Show", response.Name);
            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
