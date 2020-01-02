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
    public class SimpleVoidTest
    {
        private readonly ITestOutputHelper output;

        public SimpleVoidTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_SimpleVoidTest()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            VoidRequest request = new VoidRequest
            {
                Test = true,
                TransactionId = "<PREVIOUS TRANSACTION ID>",
            };

            VoidResponse response = await blockchyp.VoidAsync(request);

            output.WriteLine("Response: {0}", JsonConvert.SerializeObject(response));

            Assert.True(response.Approved);
        }
    }
}
