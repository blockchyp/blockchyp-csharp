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
    public class TcLogTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public TcLogTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_TcLogTest()
        {



            UseProfile("");

            TermsAndConditionsRequest setupRequest = new TermsAndConditionsRequest
            {
                Test = true,
                TerminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                TcName = "HIPPA Disclosure",
                TcContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ullamcorper id urna quis pulvinar. Pellentesque vestibulum justo ac nulla consectetur tristique. Suspendisse arcu arcu, viverra vel luctus non, dapibus vitae augue. Aenean ac volutpat purus. Curabitur in lacus nisi. Nam vel sagittis eros. Curabitur faucibus ut nisl in pulvinar. Nunc egestas, orci ut porttitor tempus, ante mauris pellentesque ex, nec feugiat purus arcu ac metus. Cras sodales ornare lobortis. Aenean lacinia ultricies purus quis pharetra. Cras vestibulum nulla et magna eleifend eleifend. Nunc nibh dolor, malesuada ut suscipit vitae, bibendum quis dolor. Phasellus ultricies ex vitae dolor malesuada, vel dignissim neque accumsan.",
                SigFormat = SignatureFormat.PNG,
                SigWidth = 200,
                SigRequired = true,
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            TermsAndConditionsResponse setupResponse = await blockchyp.TermsAndConditionsAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);


            TermsAndConditionsLogRequest request = new TermsAndConditionsLogRequest
            {

            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                TermsAndConditionsLogResponse response = await blockchyp.TcLogAsync(request);
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
