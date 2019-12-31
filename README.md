# BlockChyp C# SDK

[![NuGet](https://img.shields.io/nuget/v/blockchyp.svg)](https://www.nuget.org/packages/BlockChyp/)
[![Build Status](https://circleci.com/gh/blockchyp/blockchyp-csharp/tree/master.svg?style=shield)](https://circleci.com/gh/blockchyp/blockchyp-csharp/tree/master)

The [BlockChyp][blockchyp] .NET SDK, with support for .NET standard 2.0 and .NET Framework 4.5+.

## Installation

Using the [.NET CLI][dotnet-cli]:

```sh
dotnet add package BlockChyp
```

Using the [NuGet CLI][nuget-cli]:

```sh
nuget install BlockChyp
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package BlockChyp
```

## API Documentation

For complete API documentation, check out the [BlockChyp Documentation][blockchyp-docs].

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

## Getting a Developer Kit

In order to test your integration with real terminals, you'll need a BlockChyp
Developer Kit.  Our kits include a fully functioning payment terminal with
test pin encryption keys.  Every kit includes a comprehensive set of test
cards with test cards for every major card brand and entry method, including
Contactless and Contact EMV and mag stripe cards.  Each kit also includes
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
if (response.Approved)
{
    Console.WriteLine("Approved");
}

Console.WriteLine(response.AuthCode)
Console.WriteLine(response.AuthorizedAmount)

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
if (response.Approved)
{
    Console.WriteLine("Approved");
}

Console.WriteLine(response.AuthCode)
Console.WriteLine(response.AuthorizedAmount)

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
if (response.Success)
{
    Console.WriteLine("Success");
}


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
if (response.Success)
{
    Console.WriteLine("Success");
}


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
if (response.Success)
{
    Console.WriteLine("Success");
}


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
if (response.Success)
{
    Console.WriteLine("Success");
}

Console.WriteLine(response.Sig)
Console.WriteLine(response.SigFile)

```
#### Update Transaction Display

Appends items to an existing transaction display Subtotal, Tax, and Total are
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
if (response.Success)
{
    Console.WriteLine("Succeded");
}


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
if (response.Success)
{
    Console.WriteLine("Succeded");
}


```
#### Text Prompt

Asks the consumer text based question.

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
if (response.Success)
{
    Console.WriteLine("Success");
}

Console.WriteLine(response.Response)

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
if (response.Success)
{
    Console.WriteLine("Success");
}

Console.WriteLine(response.Response)

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
if (response.Success)
{
    Console.WriteLine("Success");
}


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
if (response.Approved)
{
    Console.WriteLine("Approved");
}


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
if (response.Approved)
{
    Console.WriteLine("Approved");
}

Console.WriteLine(response.Token)

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
if (response.Approved)
{
    Console.WriteLine("Approved");
}

Console.WriteLine(response.Amount)
Console.WriteLine(response.CurrentBalance)
Console.WriteLine(response.PublicKey)

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
if (response.Approved)
{
    Console.WriteLine("Approved");
}


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
if (response.Approved)
{
    Console.WriteLine("Approved");
}


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
if (response.Success)
{
    Console.WriteLine("Success");
}

Console.WriteLine(response.CapturedTotal)
Console.WriteLine(response.OpenPreauths)

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
if (response.Approved)
{
    Console.WriteLine("Approved");
}


```
## Contributions

BlockChyp welcomes contributions from the open source community, but bear in mind
that this repository has been generated by our internal SDK Generator tool.  If
we choose to accept a PR or contribution, your code will be moved into our SDK
Generator project, which is a private repository.

## License

Copyright BlockChyp, Inc., 2019

Distributed under the terms of the [MIT] license, blockchyp-csharp is free and open source software.

[MIT]: https://github.com/blockchyp/blockchyp-csharp/blob/master/LICENSE
