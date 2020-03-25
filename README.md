# BlockChyp C# SDK

[![Build Status](https://circleci.com/gh/blockchyp/blockchyp-csharp/tree/master.svg?style=shield)](https://circleci.com/gh/blockchyp/blockchyp-csharp/tree/master)
[![NuGet](https://img.shields.io/nuget/v/blockchyp.svg)](https://www.nuget.org/packages/BlockChyp/)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/blockchyp/blockchyp-csharp/blob/master/LICENSE)

The [BlockChyp] .NET SDK, with support for .NET standard 2.0 and .NET Framework 4.5+.

## Installation

Using the [.NET CLI]:

```sh
dotnet add package BlockChyp
```

Using the [NuGet CLI]:

```sh
nuget install BlockChyp
```

Using the [Package Manager Console]:

```powershell
Install-Package BlockChyp
```

## API Documentation

For complete API documentation, check out the [BlockChyp Documentation].

## Basic Usage

You can provision a BlockChyp API client with a set of API credentials.

```c#
var credentials = new ApiCredentials(
    "ZDSMMZLGRPBPRTJUBTAFBYZ33Q",
    "ZLBW5NR4U5PKD5PNP3ZP3OZS5U",
    "9c6a5e8e763df1c9256e3d72bd7f53dfbd07312938131c75b3bfd254da787947");

var blockchyp = new BlockChypClient(credentials);
```

The BlockChyp client should be kept and re-used for subsequent requests.
Terminal routes and HTTP connection pools are cached between requests.


## The Rest APIs

All BlockChyp SDKs provide a convenient way of accessing the BlockChyp REST APIs.
You can checkout the REST API documentation via the links below.

[Terminal REST API Docs](https://docs.blockchyp.com/rest-api/terminal/index.html)

[Gateway REST API Docs](https://docs.blockchyp.com/rest-api/gateway/index.html)

## Other SDKs

BlockChyp has officially supported SDKs for eight different development platforms and counting.
Here's the full list with links to their GitHub repositories.

[Go SDK](https://github.com/blockchyp/blockchyp-go)

[Node.js/JavaScript SDK](https://github.com/blockchyp/blockchyp-js)

[Java SDK](https://github.com/blockchyp/blockchyp-java)

[.net/C# SDK](https://github.com/blockchyp/blockchyp-csharp)

[Ruby SDK](https://github.com/blockchyp/blockchyp-ruby)

[PHP SDK](https://github.com/blockchyp/blockchyp-php)

[Python SDK](https://github.com/blockchyp/blockchyp-python)

[iOS (Objective-C/Swift) SDK](https://github.com/blockchyp/blockchyp-ios)

## Getting a Developer Kit

In order to test your integration with real terminals, you'll need a BlockChyp
Developer Kit. Our kits include a fully functioning payment terminal with
test pin encryption keys. Every kit includes a comprehensive set of test
cards with test cards for every major card brand and entry method, including
Contactless and Contact EMV and mag stripe cards. Each kit also includes
test gift cards for our blockchain gift card system.

Access to BlockChyp's developer program is currently invite only, but you
can request an invitation by contacting our engineering team at **nerds@blockchyp.com**.

You can also view a number of long form demos and learn more about us on our [YouTube Channel](https://www.youtube.com/channel/UCE-iIVlJic_XArs_U65ZcJg).

## Transaction Code Examples

You don't want to read words. You want examples. Here's a quick rundown of the
stuff you can do with the BlockChyp C# SDK and a few basic examples.

#### Charge

Executes a standard direct preauth and capture.


```c#
// Populate request parameters.
AuthorizationRequest request = new AuthorizationRequest
{
    Test = true,
    TerminalName = "Test Terminal",
    Amount = "55.00",
};

// Run the transaction.
AuthorizationResponse response = await blockchyp.ChargeAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Preauthorization

Executes a preauthorization intended to be captured later.


```c#
// Populate request parameters.
AuthorizationRequest request = new AuthorizationRequest
{
    Test = true,
    TerminalName = "Test Terminal",
    Amount = "27.00",
};

// Run the transaction.
AuthorizationResponse response = await blockchyp.PreauthAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Terminal Ping

Tests connectivity with a payment terminal.


```c#
// Populate request parameters.
PingRequest request = new PingRequest
{
    TerminalName = "Test Terminal",
};

// Run the transaction.
PingResponse response = await blockchyp.PingAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Balance

Checks the remaining balance on a payment method.


```c#
// Populate request parameters.
BalanceRequest request = new BalanceRequest
{
    Test = true,
    TerminalName = "Test Terminal",
    CardType = CardType.EBT,
};

// Run the transaction.
BalanceResponse response = await blockchyp.BalanceAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Terminal Clear

Clears the line item display and any in progress transaction.


```c#
// Populate request parameters.
ClearTerminalRequest request = new ClearTerminalRequest
{
    Test = true,
    TerminalName = "Test Terminal",
};

// Run the transaction.
Acknowledgement response = await blockchyp.ClearAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Terms & Conditions Capture

Prompts the user to accept terms and conditions.


```c#
// Populate request parameters.
TermsAndConditionsRequest request = new TermsAndConditionsRequest
{
    Test = true,
    TerminalName = "Test Terminal",
    TcAlias = "hippa",
    TcName = "HIPPA Disclosure",
    TcContent = "Full contract text",
    SigFormat = SignatureFormat.PNG,
    SigWidth = 200,
    SigRequired = true,
};

// Run the transaction.
TermsAndConditionsResponse response = await blockchyp.TermsAndConditionsAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Update Transaction Display

Appends items to an existing transaction display.  Subtotal, Tax, and Total are
overwritten by the request. Items with the same description are combined into
groups.


```c#
// Populate request parameters.
TransactionDisplayRequest request = new TransactionDisplayRequest
{
    Test = true,
    TerminalName = "Test Terminal",
    Transaction = new TransactionDisplayTransaction
    {
        Subtotal = "60.00",
        Tax = "5.00",
        Total = "65.00",
        Items = new List<TransactionDisplayItem>
        {
            new TransactionDisplayItem
            {
                Description = "Leki Trekking Poles",
                Price = "35.00",
                Quantity = 2,
                Extended = "70.00",
                Discounts = new List<TransactionDisplayDiscount>
                {
                    new TransactionDisplayDiscount
                    {
                        Description = "memberDiscount",
                        Amount = "10.00",
                    }
                },
            }
        },
    },
};

// Run the transaction.
Acknowledgement response = await blockchyp.UpdateTransactionDisplayAsync(request);

// View the result.
Console.WriteLine(response);

```

#### New Transaction Display

Displays a new transaction on the terminal.


```c#
// Populate request parameters.
TransactionDisplayRequest request = new TransactionDisplayRequest
{
    Test = true,
    TerminalName = "Test Terminal",
    Transaction = new TransactionDisplayTransaction
    {
        Subtotal = "60.00",
        Tax = "5.00",
        Total = "65.00",
        Items = new List<TransactionDisplayItem>
        {
            new TransactionDisplayItem
            {
                Description = "Leki Trekking Poles",
                Price = "35.00",
                Quantity = 2,
                Extended = "70.00",
                Discounts = new List<TransactionDisplayDiscount>
                {
                    new TransactionDisplayDiscount
                    {
                        Description = "memberDiscount",
                        Amount = "10.00",
                    }
                },
            }
        },
    },
};

// Run the transaction.
Acknowledgement response = await blockchyp.NewTransactionDisplayAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Text Prompt

Asks the consumer a text based question.


```c#
// Populate request parameters.
TextPromptRequest request = new TextPromptRequest
{
    Test = true,
    TerminalName = "Test Terminal",
    PromptType = PromptType.Email,
};

// Run the transaction.
TextPromptResponse response = await blockchyp.TextPromptAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Boolean Prompt

Asks the consumer a yes/no question.


```c#
// Populate request parameters.
BooleanPromptRequest request = new BooleanPromptRequest
{
    Test = true,
    TerminalName = "Test Terminal",
    Prompt = "Would you like to become a member?",
    YesCaption = "Yes",
    NoCaption = "No",
};

// Run the transaction.
BooleanPromptResponse response = await blockchyp.BooleanPromptAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Display Message

Displays a short message on the terminal.


```c#
// Populate request parameters.
MessageRequest request = new MessageRequest
{
    Test = true,
    TerminalName = "Test Terminal",
    Message = "Thank you for your business.",
};

// Run the transaction.
Acknowledgement response = await blockchyp.MessageAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Refund

Executes a refund.


```c#
// Populate request parameters.
RefundRequest request = new RefundRequest
{
    TerminalName = "Test Terminal",
    TransactionId = "<PREVIOUS TRANSACTION ID>",
    Amount = "5.00",
};

// Run the transaction.
AuthorizationResponse response = await blockchyp.RefundAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Enroll

Adds a new payment method to the token vault.


```c#
// Populate request parameters.
EnrollRequest request = new EnrollRequest
{
    Test = true,
    TerminalName = "Test Terminal",
};

// Run the transaction.
EnrollResponse response = await blockchyp.EnrollAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Gift Card Activation

Activates or recharges a gift card.


```c#
// Populate request parameters.
GiftActivateRequest request = new GiftActivateRequest
{
    Test = true,
    TerminalName = "Test Terminal",
    Amount = "50.00",
};

// Run the transaction.
GiftActivateResponse response = await blockchyp.GiftActivateAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Time Out Reversal

Executes a manual time out reversal.

We love time out reversals. Don't be afraid to use them whenever a request to a
BlockChyp terminal times out. You have up to two minutes to reverse any
transaction. The only caveat is that you must assign transactionRef values when
you build the original request. Otherwise, we have no real way of knowing which
transaction you're trying to reverse because we may not have assigned it an id
yet. And if we did assign it an id, you wouldn't know what it is because your
request to the terminal timed out before you got a response.


```c#
// Populate request parameters.
AuthorizationRequest request = new AuthorizationRequest
{
    TerminalName = "Test Terminal",
    TransactionRef = "<LAST TRANSACTION REF>",
};

// Run the transaction.
AuthorizationResponse response = await blockchyp.ReverseAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Capture Preauthorization

Captures a preauthorization.


```c#
// Populate request parameters.
CaptureRequest request = new CaptureRequest
{
    Test = true,
    TransactionId = "<PREAUTH TRANSACTION ID>",
};

// Run the transaction.
CaptureResponse response = await blockchyp.CaptureAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Close Batch

Closes the current credit card batch.


```c#
// Populate request parameters.
CloseBatchRequest request = new CloseBatchRequest
{
    Test = true,
};

// Run the transaction.
CloseBatchResponse response = await blockchyp.CloseBatchAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Void Transaction

Discards a previous preauth transaction.


```c#
// Populate request parameters.
VoidRequest request = new VoidRequest
{
    Test = true,
    TransactionId = "<PREVIOUS TRANSACTION ID>",
};

// Run the transaction.
VoidResponse response = await blockchyp.VoidAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Terminal Status

Returns the current status of a terminal.


```c#
// Populate request parameters.
TerminalStatusRequest request = new TerminalStatusRequest
{
    TerminalName = "Test Terminal",
};

// Run the transaction.
TerminalStatusResponse response = await blockchyp.TerminalStatusAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Capture Signature.

Captures and returns a signature.


```c#
// Populate request parameters.
CaptureSignatureRequest request = new CaptureSignatureRequest
{
    TerminalName = "Test Terminal",
    SigFormat = SignatureFormat.PNG,
    SigWidth = 200,
};

// Run the transaction.
CaptureSignatureResponse response = await blockchyp.CaptureSignatureAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Update Customer

Updates or creates a customer record.


```c#
// Populate request parameters.
UpdateCustomerRequest request = new UpdateCustomerRequest
{
    Customer = new Customer
    {
        Id = "ID of the customer to update",
        CustomerRef = "Customer reference string",
        FirstName = "FirstName",
        LastName = "LastName",
        CompanyName = "Company Name",
        EmailAddress = "support@blockchyp.com",
        SmsNumber = "(123) 123-1231",
    },
};

// Run the transaction.
CustomerResponse response = await blockchyp.UpdateCustomerAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Retrieve Customer

Retrieves a customer by id.


```c#
// Populate request parameters.
CustomerRequest request = new CustomerRequest
{
    CustomerId = "ID of the customer to retrieve",
};

// Run the transaction.
CustomerResponse response = await blockchyp.CustomerAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Search Customer

Searches the customer database.


```c#
// Populate request parameters.
CustomerSearchRequest request = new CustomerSearchRequest
{
    Query = "(123) 123-1234",
};

// Run the transaction.
CustomerSearchResponse response = await blockchyp.CustomerSearchAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Transaction Status

Retrieves the current status of a transaction.


```c#
// Populate request parameters.
TransactionStatusRequest request = new TransactionStatusRequest
{
    TransactionId = "ID of transaction to retrieve",
};

// Run the transaction.
AuthorizationResponse response = await blockchyp.TransactionStatusAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Send Payment Link

Creates and send a payment link to a customer.


```c#
// Populate request parameters.
PaymentLinkRequest request = new PaymentLinkRequest
{
    Amount = "199.99",
    Description = "Widget",
    Subject = "Widget invoice",
    Transaction = new TransactionDisplayTransaction
    {
        Subtotal = "195.00",
        Tax = "4.99",
        Total = "199.99",
        Items = new List<TransactionDisplayItem>
        {
            new TransactionDisplayItem
            {
                Description = "Widget",
                Price = "195.00",
                Quantity = 1,
            }
        },
    },
    AutoSend = true,
    Customer = new Customer
    {
        CustomerRef = "Customer reference string",
        FirstName = "FirstName",
        LastName = "LastName",
        CompanyName = "Company Name",
        EmailAddress = "support@blockchyp.com",
        SmsNumber = "(123) 123-1231",
    },
};

// Run the transaction.
PaymentLinkResponse response = await blockchyp.SendPaymentLinkAsync(request);

// View the result.
Console.WriteLine(response);

```

## Running Integration Tests

If you'd like to run the integration tests, create a new file on your system
called `sdk-itest-config.json` with the API credentials you'll be using as
shown in the example below.

```
{
 "gatewayHost": "https://api.blockchyp.com",
 "testGatewayHost": "https://test.blockchyp.com",
 "apiKey": "PZZNEFK7HFULCB3HTLA7HRQDJU",
 "bearerToken": "QUJCHIKNXOMSPGQ4QLT2UJX5DI",
 "signingKey": "f88a72d8bc0965f193abc7006bbffa240663c10e4d1dc3ba2f81e0ca10d359f5"
}
```

This file can be located in a few different places, but is usually located
at `<USER_HOME>/.config/blockchyp/sdk-itest-config.json`. All BlockChyp SDKs
use the same configuration file.

To run the integration test suite via `make`, type the following command:

`make integration`

[BlockChyp Documentation]: https://docs.blockchyp.com
[BlockChyp]: https://www.blockchyp.com
[.NET CLI]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[NuGet CLI]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[Package Manager Console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console

## Contributions

BlockChyp welcomes contributions from the open source community, but bear in mind
that this repository has been generated by our internal SDK Generator tool. If
we choose to accept a PR or contribution, your code will be moved into our SDK
Generator project, which is a private repository.

## License

Copyright BlockChyp, Inc., 2019

Distributed under the terms of the [MIT] license, blockchyp-csharp is free and open source software.

[MIT]: https://github.com/blockchyp/blockchyp-csharp/blob/master/LICENSE
