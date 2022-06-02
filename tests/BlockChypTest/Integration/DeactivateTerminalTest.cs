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
    public class DeactivateTerminalTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public DeactivateTerminalTest(ITestOutputHelper output)
        {
            this.output = output;
        }



        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_DeactivateTerminalTest()
        {



            UseProfile("");


            TerminalDeactivationRequest request = new TerminalDeactivationRequest
            {
                TerminalId = Guid.NewGuid().ToString("N"),
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                Acknowledgement response = await blockchyp.DeactivateTerminalAsync(request);
                output.WriteLine("Response: {0}", response);                                                                            Assert.False(response.Success, "response.Success");
                                                                                                            }
            catch (Exception e) {
                err = e;
            }


            Assert.NotNull(err);


        }
    }
}
