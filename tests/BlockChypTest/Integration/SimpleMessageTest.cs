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
    public class SimpleMessageTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public SimpleMessageTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_SimpleMessageTest()
        {
            ShowTestOnTerminal("SimpleMessage");

            MessageRequest request = new MessageRequest
            {
                Test = true,
                TerminalName = "Test Terminal",
                Message = "Thank You For Your Business",
            };

            output.WriteLine("Request: {0}", JsonConvert.SerializeObject(request));

            Acknowledgement response = await blockchyp.MessageAsync(request);

            output.WriteLine("Response: {0}", JsonConvert.SerializeObject(response));

            Assert.True(response.Success, "response.Success");
        }
    }
}
