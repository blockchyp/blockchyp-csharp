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
    public class ActivateTerminalTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public ActivateTerminalTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_ActivateTerminalTest()
        {



            UseProfile("");


            TerminalActivationRequest request = new TerminalActivationRequest
            {
                TerminalName = "Bad Terminal Code",
                ActivationCode = "XXXXXX",
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                Acknowledgement response = await blockchyp.ActivateTerminalAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.False(response.Success, "response.Success");
                Assert.Equal("Invalid Activation Code", response.Error);
            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
