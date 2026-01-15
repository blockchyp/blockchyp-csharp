// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
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
    public class ListTerminalsTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public ListTerminalsTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_ListTerminalsTest()
        {



            UseProfile("");


            TerminalProfileRequest request = new TerminalProfileRequest
            {

            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                TerminalProfileResponse response = await blockchyp.TerminalsAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
                            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
