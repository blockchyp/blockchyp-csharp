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

## Examples

### Basic Usage

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

### Charge

This transaction is the basic authorize and capture transaction.

```c#
var request = new AuthRequest
{
    TerminalName = "Test Terminal",
    Amount = "55.55",
    TransactionRef = "your invoice or tender id",
};

AuthResponse response = await blockchyp.ChargeAsync(request);

if (response.Approved)
{
    Console.WriteLine("Approved!");
}
```

### Preauth

This transaction preauthorizes a payment.

```c#
var request = new AuthRequest
{
    TerminalName = "Test Terminal",
    Amount = "50.00",
    TransactionRef = "your invoice or tender id",
};

AuthResponse response = await blockchyp.PreauthAsync(request);

if (response.Approved)
{
    Console.WriteLine("Approved!");
}
```

### Capture

This one captures a preauth. Can be for a different amount than the
original authorization, optionally with a tip adjustment.

```c#
var request = new CaptureRequest
{
    TransactionId = preauthResponse.TransactionId,
    TipAmount = "5.00",
    Amount = "55.00",
};

CaptureResponse response = await blockchyp.CaptureAsync(request);

if (response.Approved)
{
    Console.WriteLine("Approved!");
}
```

### Enroll

This captures a payment method on the terminal and then enrolls it in the
token vault. You can then use the token for recurring payments.

```c#
var request = new AuthRequest
{
    TerminalName = "Test Terminal",
    TransactionRef = "your invoice or tender id",
};

AuthResponse response = await blockchyp.EnrollAsync(request);

if (response.Approved)
{
    Console.WriteLine("Approved!");
}

string token = response.Token; // This is your re-usable token!
```

### Refunds (The right way)

If you need to execute a refund, the best way is to do so using the
transaction id from the transaction you're refunding. This lowers the surface
area for fraud and makes refunds easily traceable to the original purchase.

```c#
var request = new RefundRequest
{
    TransactionId = previousTransaction.TransactionId,
    Amount = "25.00", // Could be less than the original transaction if it's a partial refund
};

AuthResponse response = await blockchyp.RefundAsync(request);

if (response.Approved)
{
    Console.WriteLine("Approved!");
}
```

### Refunds (The wrong way)

If you absolutely must do a refund without referencing the previous
transaction here's how you do it. But please don't.

```c#
var request = new RefundRequest
{
    TerminalName = "Test Terminal",
    TransactionId = previousTransaction.TransactionId,
    Amount = "55.00",
};

AuthResponse response = await blockchyp.RefundAsync(request);

if (response.Approved)
{
    Console.WriteLine("Approved!");
}
```

### Void

You can void a transaction anytime before the batch closes. Here's an example.

```c#
var request = new VoidRequest
{
    TransactionId = previousTransaction.TransactionId,
};

VoidResponse response = await blockchyp.VoidAsync(request);

if (response.Approved)
{
    Console.WriteLine("Approved!");
}
```

### Time Out Reversal

We love time out reversals. Don't be afraid to use them whenever a request to
a BlockChyp terminal times out. You have up to two minutes to reverse any
transaction. The only caveat is that you must assign transactionRef values
when you build the original request. Otherwise, we have no real way of
knowing which transaction you're trying to reverse because we may not have
assigned it an id yet. And if we did assign it an id, you wouldn't know
what it is because your request to the terminal timed out before you got a
response.

```c#
var request = new AuthRequest
{
    TerminalName = "Test Terminal",
    TransactionRef = "your invoice or tender id",
    Amount = "50.00",
};

try
{
    AuthResponse response = await blockchyp.ChargeAsync(request);

    if (response.Approved)
    {
        Console.WriteLine("Approved!");
    }
}
catch (TimeoutException)
{
    AuthResponse reverseResponse = await blockchyp.ReverseAsync(request);

    if (reverseResponse.Approved)
    {
        // The transaction was authorized, but the response never
        // came back for some reason. It has now been reversed.
    }
    else
    {
        // We never actually got the transaction, but that's ok.
        // Reversals are idempotent. When in doubt, send a reversal.
    }
}

```

### Batch Close

By default, batches always close at 3 AM in the merchant's local time zone.
You can adjust this in the dashboard or turn off automatic batching, in which
case, you'll need this code snippet to close out a batch programmatically.

```c#
var request = new CloseBatchRequest();

CloseBatchResponse response = await blockchyp.CloseBatchAsync(request);

if (response.Success)
{
    Console.WriteLine("Batch closed!");
    Console.WriteLine($"Captured total: {response.CapturedTotal}");
    Console.WriteLine($"Uncaptured transaction volume: {response.OpenPreauths}");
}
```

### Heartbeat

This method is used primarily to test connectivity with the gateway.
But it also returns a timestamp and some blockchain stuff you might find
interesting.  Pro Tip: If merchantPk is non null in the response, your
credentials are valid.

```c#
var response = await blockchyp.HeartbeatAsync(false);

if (response.Success)
{
    Console.WriteLine("Gateway is up");
}

if (!String.IsNullOrEmpty(response.MerchantPublicKey))
{
    Console.WriteLine("Authentication is valid");
}
```

### Ping

This gives you the ability to test if communication with a terminal
is possible.

```c#
var request = new PingRequest
{
    TerminalName = "Test Terminal"
};

var response = await blockchyp.PingAsync(request);

if (response.Success)
{
    Console.WriteLine("Terminal is online");
}
```

### Terminal Line Item Display

This fun option gives you the ability to display line items and totals
on the terminals as orders are scanned or entered. Use liberally.

```c#
var request = new TransactionDisplayRequest
{
    TerminalName = "Test Terminal",
    Transaction = new TransactionDisplayTransaction
    {
        Subtotal = "1.00",
        Tax = "0.30",
        Total = "1.30",
        Items = new TransactionDisplayItem[]
        {
            new TransactionDisplayItem
            {
                Description = "Grid Square",
                Price = "1.50",
                Quantity = 1,
                Discounts = new TransactionDisplayDiscount[]
                {
                    new TransactionDisplayDiscount
                    {
                        Amount = "0.50",
                        Description = "Member Discount",
                    },
                },
            },
        },
    },
};

var response = await blockchyp.NewTransactionDisplayAsync(request);

// Update the original request
request = new TransactionDisplayRequest
{
    TerminalName = "Test Terminal",
    Transaction = new TransactionDisplayTransaction
    {
        Subtotal = "2.50",
        Tax = "0.70",
        Total = "3.20",
        Items = new TransactionDisplayItem[]
        {
            new TransactionDisplayItem
            {
                Description = "Headlight Fluid",
                Price = "0.50",
                Quantity = 2,
            },
        }
    },
};

response = await blockchyp.UpdateTransactionDisplayAsync(request);
```

### Terminal Message

This one displays a message on the terminal. These might be little thank
you's or some kind of promotional message. The message is displayed for
thirty seconds before the terminal is placed in the idle state.

```c#
var request = new MessageRequest
{
    TerminalName = "Test Terminal",
    Message = "Something derogatory about Verifone.",
};

var response = await blockchyp.MessageAsync(request);

if (response.Success)
{
    Console.WriteLine("The truth is now out there.");
}
```

### Terminal Yes/No Prompt

This one lets you ask the user yes or no questions. You might do this for
suggestive selling or if the POS is feeling lonely.

```c#
var request = new BooleanPromptRequest
{
    TerminalName = "Test Terminal",
    Prompt = "True or False: Everything I say is a lie",
    YesCaption = "True",
    NoCaption = "False",
};

var response = await blockchyp.BooleanPromptAsync(request);

if (response.Response)
{
    Console.WriteLine("Correct!");
}
```

### Terminal Text Prompt

This option allows you to prompt the user for text or numeric data.
You can use this to capture email addresses, phone numbers,
customer numbers, and rewards numbers.

Unlike boolean prompts, which support freeform prompt text, PCI rules restrict
free form prompts when text can be entered because you might prompt the user
for card numbers or pin codes - and that would be bad.

```c#
var request = new TextPromptRequest
{
    TerminalName = "Test Terminal",
    PromptType = PromptType.Email,
};

var response = await blockchyp.TextPromptAsync(request);

if (response.Success)
{
    Console.WriteLine($"User entered: {response.Response}");
}
```

### Clearing The Terminal

This example shows you how to clear and reset the terminal.
Any in progress line item display, prompt, or transaction will be cancelled.

```c#
var request = new ClearRequest
{
    TerminalName = "Test Terminal",
};

var response = await blockchyp.ClearAsync(request);

if (response.Success)
{
    Console.WriteLine("Terminal was cleared");
}
```

## The Test Flag

During development, you'll want to send requests to the test API. You can
do this by setting the test flag in any payment request.

```c#
var request = new AuthRequest
{
    Test = true,
}
```

## Signature Capture

If the payment terminal prompts the user for an on-screen signature, BlockChyp
uploads the signature image to our web scale database for archival.

By default, the signature is not returned. You do have the option of getting
the image back in PNG or JPEG format, either as hex or written to file.

```c#
var request = new AuthRequest
{
    SignatureFormat = SignatureFormat.PNG,
    SignatureWidth = 200,
    SignatureFile = "signature.png", // The signature will be written out to this file
};
```

## Keyed Entry mode

If you need the consumer to enter a card number by hand, set the manual entry
flag on an authorization request.

```c#
var request = new AuthRequest
{
    ManualEntry = true,
};
```

## Cloud Relay

It's not always possible for terminals to live in the same network as the
application they're integrated with. For example, cloud or SaaS based
applications may not have access to the in store network. To address this,
terminals can be configured for cloud relay when they're activated.

When a terminal is configured for cloud relay, the SDK will send
transactions to the Gateway and the Gateway will relay them back to the
terminal. This is a bit slower since requests have to make a round trip out
to the gateway. But more importantly, offline or store and forward
processing is not available to applications using cloud relay.

It's an option, but only use it if you really need it.

## Sync/Async

All methods include a synchronous and an asynchronous form. You should prefer
the asynchronous methods where possible.

## Terminal Route Caching

In the default configuration, terminal routes are resolved once per hour.
For all requests within that hour period, requests are routed via the
cached route. This default behavior should work for most cases. You can
override this behavior by setting a custom cache timeout:

```c#
blockchyp.RouteCache.TimeToLive = TimeSpan.FromMinutes(30);
```

Routes are cached to disk by default. You can disable this and maintain the
cache in memory only as follows:

```c#
blockchyp.RouteCache.OfflineEnabled = false;
```

[blockchyp-docs]: https://docs.blockchyp.com
[blockchyp]: https://www.blockchyp.com
[dotnet-cli]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
