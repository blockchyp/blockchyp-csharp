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
    public class SlideShowTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public SlideShowTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_SlideShowTest()
        {



            UseProfile("");

            SlideShow setupRequest = new SlideShow
            {
                Name = "Test Slide Show",
                Delay = 5,
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            SlideShow setupResponse = await blockchyp.UpdateSlideShowAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);


            SlideShowRequest request = new SlideShowRequest
            {
                SlideShowId = setupResponse.Id,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                SlideShow response = await blockchyp.SlideShowAsync(request);
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
