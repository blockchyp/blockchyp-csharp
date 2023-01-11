// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
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
    public class TcEntryTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public TcEntryTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_TcEntryTest()
        {



            UseProfile("");

            TermsAndConditionsLogRequest setupRequest = new TermsAndConditionsLogRequest
            {

            };

            output.WriteLine("Setup request: {0}", setupRequest);

            TermsAndConditionsLogResponse setupResponse = await blockchyp.TcLogAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);


            TermsAndConditionsLogRequest request = new TermsAndConditionsLogRequest
            {
                LogEntryId = setupResponse.Results[0].Id,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                TermsAndConditionsLogEntry response = await blockchyp.TcEntryAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
                Assert.NotEmpty(response.Id);
                Assert.NotEmpty(response.TerminalId);
                Assert.NotEmpty(response.TerminalName);
                Assert.NotEmpty(response.Timestamp);
                Assert.NotEmpty(response.Name);
                Assert.NotEmpty(response.Content);
                Assert.True(response.HasSignature, "response.HasSignature");
                Assert.NotEmpty(response.Signature);
            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
