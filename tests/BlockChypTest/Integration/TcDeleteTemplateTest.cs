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
    public class TcDeleteTemplateTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public TcDeleteTemplateTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_TcDeleteTemplateTest()
        {



            UseProfile("");

            TermsAndConditionsTemplate setupRequest = new TermsAndConditionsTemplate
            {
                Alias = Guid.NewGuid().ToString("N"),
                Name = "HIPPA Disclosure",
                Content = "Lorem ipsum dolor sit amet.",
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            TermsAndConditionsTemplate setupResponse = await blockchyp.TcUpdateTemplateAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);


            TermsAndConditionsTemplateRequest request = new TermsAndConditionsTemplateRequest
            {
                TemplateId = setupResponse.Id,
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                Acknowledgement response = await blockchyp.TcDeleteTemplateAsync(request);
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
