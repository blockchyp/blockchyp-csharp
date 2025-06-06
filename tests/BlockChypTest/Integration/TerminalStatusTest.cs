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
    public class TerminalStatusTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public TerminalStatusTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_TerminalStatusTest()
        {


            UseProfile("");
            ShowTestOnTerminal("TerminalStatus");


            UseProfile("");


            TerminalStatusRequest request = new TerminalStatusRequest
            {
                TerminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                TerminalStatusResponse response = await blockchyp.TerminalStatusAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
                Assert.True(response.Idle, "response.Idle");
            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
