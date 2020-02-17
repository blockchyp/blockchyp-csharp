// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using System;
using System.Collections.Generic;
using System.IO;
using BlockChyp.Entities;
using Xunit;
using Xunit.Abstractions;

namespace BlockChypTest.Integration
{
    public class CaptureSignatureTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public CaptureSignatureTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_CaptureSignatureTest()
        {
            ShowTestOnTerminal("CaptureSignature");

            CaptureSignatureRequest request = new CaptureSignatureRequest
            {
                TerminalName = "Test Terminal",
                SigFormat = SignatureFormat.PNG,
                SigWidth = 200,
            };

            output.WriteLine("Request: {0}", request);

            CaptureSignatureResponse response = await blockchyp.CaptureSignatureAsync(request);

            output.WriteLine("Response: {0}", response);

            Assert.True(response.Success, "response.Success");
        }
    }
}
