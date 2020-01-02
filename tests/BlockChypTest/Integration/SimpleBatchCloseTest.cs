// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using System;
using System.Collections.Generic;
using System.IO;
using BlockChyp.Entities;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace BlockChypTest.Integration
{
    public class SimpleBatchCloseTest
    {
        private readonly ITestOutputHelper output;

        public SimpleBatchCloseTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_SimpleBatchCloseTest()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            CloseBatchRequest request = new CloseBatchRequest
            {
                Test = true,
            };

            CloseBatchResponse response = await blockchyp.CloseBatchAsync(request);

            output.WriteLine("Response: {0}", JsonConvert.SerializeObject(response));

            Assert.True(response.Success);
            Assert.NotEmpty(response.CapturedTotal);
            Assert.NotEmpty(response.OpenPreauths);
        }
    }
}
