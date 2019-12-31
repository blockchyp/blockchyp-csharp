/**
 * Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is governed by a
 * license that can be found in the LICENSE file.
 *
 * This file was generated automatically. Changes to this file will be lost every time the
 * code is regenerated.
 */

using System;
using System.IO;
using BlockChyp.Entities;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace BlockChypTest.Integration
{
    public class SimpleCaptureTest
    {
        private readonly ITestOutputHelper output;

        public SimpleCaptureTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_SimpleCaptureTest()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            CaptureRequest request = new CaptureRequest
            {
                Test = true,
                TransactionId = "<PREAUTH TRANSACTION ID>",
            };

            CaptureResponse response = await blockchyp.CaptureAsync(request);

            output.WriteLine("Response: {0}", JsonConvert.SerializeObject(response));

            Assert.True(response.Approved);
        }
    }
}
