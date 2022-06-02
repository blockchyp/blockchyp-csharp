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
    public class BooleanPromptTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public BooleanPromptTest(ITestOutputHelper output)
        {
            this.output = output;
        }



        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_BooleanPromptTest()
        {


            UseProfile("");
            ShowTestOnTerminal("BooleanPrompt");


            UseProfile("");


            BooleanPromptRequest request = new BooleanPromptRequest
            {
                Test = true,
                TerminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                Prompt = "Would you like to become a member?",
                YesCaption = "Yes",
                NoCaption = "No",
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                BooleanPromptResponse response = await blockchyp.BooleanPromptAsync(request);
                output.WriteLine("Response: {0}", response);                                                            Assert.True(response.Success, "response.Success");
                                                                                                                                                                            Assert.True(response.Response, "response.Response");
                                                                                                                            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
