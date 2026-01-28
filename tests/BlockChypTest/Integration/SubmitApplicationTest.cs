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
    public class SubmitApplicationTest : IntegrationTest
    {
        private readonly ITestOutputHelper output;

        public SubmitApplicationTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Trait("Category", "partner")]
        [Trait("Category", "Integration")]
        [Fact]
        public async void Run_SubmitApplicationTest()
        {



            UseProfile("partner");


            SubmitApplicationRequest request = new SubmitApplicationRequest
            {
                Test = true,
                InviteCode = "asdf",
                DbaName = "BlockChyp",
                CorporateName = "BlockChyp Inc.",
                WebSite = "https://www.blockchyp.com",
                TaxIdNumber = "123456789",
                EntityType = "CORPORATION",
                StateOfIncorporation = "UT",
                MerchantType = "RETAIL",
                BusinessDescription = "Payment processing solutions",
                YearsInBusiness = "5",
                BusinessPhoneNumber = "5555551234",
                PhysicalAddress = new Address
                {
                    Address1 = "355 S 520 W",
                    City = "Lindon",
                    StateOrProvince = "UT",
                    PostalCode = "84042",
                    CountryCode = "US",
                },
                MailingAddress = new Address
                {
                    Address1 = "355 S 520 W",
                    City = "Lindon",
                    StateOrProvince = "UT",
                    PostalCode = "84042",
                    CountryCode = "US",
                },
                ContactFirstName = "John",
                ContactLastName = "Doe",
                ContactPhoneNumber = "5555555678",
                ContactEmail = "john.doe@example.com",
                ContactTitle = "CEO",
                ContactTaxIdNumber = "987654321",
                ContactDob = "1980-01-01",
                ContactDlNumber = "D1234567",
                ContactDlStateOrProvince = "NY",
                ContactDlExpiration = "2025-12-31",
                ContactHomeAddress = new Address
                {
                    Address1 = "355 S 520 W",
                    City = "Lindon",
                    StateOrProvince = "UT",
                    PostalCode = "84042",
                    CountryCode = "US",
                },
                ContactRole = "OWNER",
                Owners = new List<Owner>
                {
                    new Owner
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        JobTitle = "CEO",
                        TaxIdNumber = "876543210",
                        PhoneNumber = "5555559876",
                        Dob = "1981-02-02",
                        Ownership = "50",
                        Email = "john.doe@example.com",
                        DlNumber = "D7654321",
                        DlStateOrProvince = "UT",
                        DlExpiration = "2024-12-31",
                        Address = new Address
                        {
                            Address1 = "355 S 520 W",
                            City = "Lindon",
                            StateOrProvince = "UT",
                            PostalCode = "84042",
                            CountryCode = "US",
                        },
                    }
                },
                ManualAccount = new ApplicationAccount
                {
                    Name = "Business Checking",
                    Bank = "Test Bank",
                    AccountHolderName = "BlockChyp Inc.",
                    RoutingNumber = "124001545",
                    AccountNumber = "987654321",
                },
                AverageTransaction = "100.00",
                HighTransaction = "1000.00",
                AverageMonth = "10000.00",
                HighMonth = "20000.00",
                RefundPolicy = "30_DAYS",
                RefundDays = "30",
                TimeZone = "America/Denver",
                BatchCloseTime = "23:59",
                MultipleLocations = "false",
                EbtRequested = "false",
                Ecommerce = "true",
                CardPresentPercentage = "70",
                PhoneOrderPercentage = "10",
                EcomPercentage = "20",
                SignerName = "John Doe",
            };

            output.WriteLine("Request: {0}", request);

            Exception err = null;
            try
            {
                Acknowledgement response = await blockchyp.SubmitApplicationAsync(request);
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
