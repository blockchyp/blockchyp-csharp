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
    public class SurveyQuestionsTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public SurveyQuestionsTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_SurveyQuestionsTest()
        {



            UseProfile("");

            SurveyQuestion setupRequest = new SurveyQuestion
            {
                Ordinal = 1,
                QuestionText = "Would you shop here again?",
                QuestionType = "yes_no",
            };

            output.WriteLine("Setup request: {0}", setupRequest);

            SurveyQuestion setupResponse = await blockchyp.UpdateSurveyQuestionAsync(setupRequest);

            output.WriteLine("Setup Response: {0}", setupResponse);


            SurveyQuestionRequest request = new SurveyQuestionRequest
            {

            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                SurveyQuestionResponse response = await blockchyp.SurveyQuestionsAsync(request);
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
