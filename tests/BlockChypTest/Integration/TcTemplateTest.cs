// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
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
    public class TcTemplateTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public TcTemplateTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_TcTemplateTest()
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
                TermsAndConditionsTemplate response = await blockchyp.TcTemplateAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
                Assert.Equal("HIPPA Disclosure", response.Name);
                Assert.Equal("Lorem ipsum dolor sit amet.", response.Content);
            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
