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
    public class UpdateSurveyQuestionTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public UpdateSurveyQuestionTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_UpdateSurveyQuestionTest()
        {



            UseProfile("");


            SurveyQuestion request = new SurveyQuestion
            {
                Ordinal = 1,
                QuestionText = "Would you shop here again?",
                QuestionType = "yes_no",
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                SurveyQuestion response = await blockchyp.UpdateSurveyQuestionAsync(request);
                output.WriteLine("Response: {0}", response);
                Assert.True(response.Success, "response.Success");
                Assert.Equal("Would you shop here again?", response.QuestionText);
                Assert.Equal("yes_no", response.QuestionType);
            }
            catch (Exception e) {
                err = e;
            }


            Assert.Null(err);


        }
    }
}
