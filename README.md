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


## Additional Documentation

Complete documentation can be found on our [Developer Documentation Portal].

[Developer Documentation Portal]: https://docs.blockchyp.com/

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

### Payment Endpoints


These are the core payment APIs used to execute and work with payment transactions in BlockChyp.



#### Charge



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

Our most popular transaction executes a standard authorization and capture.
This is the most basic of
basic payment transactions, typically used in conventional retail.

Charge transactions can use a payment terminal to capture a payment or
use a previously enrolled payment token.

**Terminal Transactions**

For terminal transactions, make sure you pass in the terminal name using the `terminalName` property.

**Token Transactions**

If you have a payment token, omit the `terminalName` property and pass in the token with the `token`
property instead.

**Card Numbers and Mag Stripes**

You can also pass in PANs and Mag Stripes, but you probably shouldn't, as this will
put you in PCI scope and the most common vector for POS breaches is keylogging.
If you use terminals for manual card entry, you'll bypass any keyloggers that
might be maliciously running on the point-of-sale system.

**Common Variations**

* **Gift Card Redemption**:  There's no special API for gift card redemption in BlockChyp. Simply execute a plain charge transaction and if the customer swipes a gift card, our terminals will identify the gift card and run a gift card redemption. Also note that if for some reason the gift card's original purchase transaction is associated with fraud or a chargeback, the transaction will be rejected.
* **EBT**: Set the `CardType` field to `CardType.EBT` to process an EBT SNAP transaction. Note that test EBT transactions always assume a balance of $100.00, so test EBT transactions over that amount may be declined.
* **Cash Back**: To enable cash back for debit transactions, set the `CashBack` field. If the card presented isn't a debit card, the `CashBack` field will be ignored.
* **Manual Card Entry**: Set the `ManualEntry` field to enable manual card entry. Good as a backup when chips and MSR's don't work or for more secure phone orders. You can even combine the `ManualEntry` field with the `CardType` field set to `CardType.EBT` for manual EBT card entry.
* **Inline Tokenization**: You can enroll the payment method in the token vault inline with a charge transaction by setting the `Enroll` field. You'll get a token back in the response. You can even bind the token to a customer record if you also pass in customer data.
* **Prompting for Tips**: Set the `PromptForTip` field if you'd like to prompt the customer for a tip before authorization. Good for pay-at-the-table and other service related scenarios.
* **Cash Discounting and Surcharging**:  The `Surcharge` and `CashDiscount` fields can be used together to support cash discounting or surcharge problems. Consult the Cash Discount documentation for more details.
* **Cryptocurrency** The `Cryptocurrency` field can be used to switch the standard present card screen to a cryptocurrency screen.  The field value can be `ANY` to enable any supported cryptocurrency or a single currency code such as `BTC` for Bitcoin.



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



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

A preauthorization puts a hold on funds and must be captured later.  This is used
in scenarios where the final transaction amount might change.  A common example is 
fine dining, where a tip adjustment is required before final settlement.

Another use case for preauthorization is e-commerce.  Typically, an online order
is preauthorized at the time of the order and then captured when the order ships.

Preauthorizations can use a payment terminal to capture a payment or
use a previously enrolled payment token.

**Terminal Transactions**

For terminal transactions, make sure you pass in the terminal name using the `terminalName` property.

**Token Transactions**

If you have a payment token, omit the `terminalName` property and pass in the token with the `token`
property instead.

**Card Numbers and Mag Stripes**

You can also pass in PANs and Mag Stripes, but you probably shouldn't, as this will
put you in PCI scope and the most common vector for POS breaches is key logging.
If you use terminals for manual card entry, you'll bypass any key loggers that
might be maliciously running on the point-of-sale system.

**Cryptocurrency**

Note that preauths are not supported for cryptocurrency.

**Common Variations**

* **Manual Card Entry**: Set the `ManualEntry` field to enable manual card entry. Good as a backup when chips and MSR's don't work or for more secure phone orders. You can even combine the `ManualEntry` field with `CardType` set to `CardType.EBT` for manual EBT card entry.
* **Inline Tokenization**: You can enroll the payment method in the token vault in line with a charge transaction by setting the `Enroll` field. You'll get a token back in the response. You can even bind the token to a customer record if you also pass in customer data.
* **Prompting for Tips**: Set the `PromptForTip` field if you'd like to prompt the customer for a tip before authorization. You can prompt for tips as part of a preauthorization, although it's not a very common approach.
* **Cash Discounting and Surcharging**: The `Surcharge` and `CashDiscount` fields can be used together to support cash discounting or surcharge problems. Consult the Cash Discount documentation for more details.




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

#### Capture Preauthorization



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API allows you to capture a previously approved preauthorization.

You'll need to make sure you pass in the Transaction ID returned by the original preauth transaction 
so we know which transaction we're capturing.  If you want to capture the transaction for the
exact amount of the preauth, the Transaction ID is all you need to pass in.

You can adjust the total if you need to by passing in a new `amount`.  We
also recommend you pass in updated amounts for `tax` and `tip` as it can
sometimes reduce your interchange fees. (Level II Processing, for example.)




```c#
// Populate request parameters.
CaptureRequest request = new CaptureRequest
{
    Test = true,
    TransactionId = "<ORIGINAL TRANSACTION ID>",
    Amount = "32.00",
};

// Run the transaction.
CaptureResponse response = await blockchyp.CaptureAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Refund



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

It's not ideal, but sometimes customers want their money back.

Our refund API allows you to confront this unpleasant reality by executing refunds in a few different scenarios.

The most fraud resistent method is to execute refunds in the context of a previous transaction.  You should always keep track of the Transaction ID
returned in a BlockChyp response.  To refund the full amount of the previous transaction, just pass in the original Transaction ID with the refund requests.

**Partial Refunds**

For a partial refund, just pass in an amount along with the Transaction ID.
The only rule is that the amount must be equal to or less than the original
transaction.  You can execute multiple partial refunds against the same
original transaction as long as the total refunded amount doesn't exceed the original amount.

**Tokenized Refunds**

You can also use a token to execute a refund.  Pass in a token instead
of the Transaction ID and the desired refund amount.

**Free Range Refunds**

When you execute a refund without referencing a previous transaction, we
call this a *free range refund*.

We don't recommend this type of refund, but it is permitted.  If you absolutely insist on
doing it, pass in a Terminal Name and an amount.

You can execute a manual or keyed refund by passing the `ManualEntry` field
to a free range refund request.

**Gift Card Refunds**

Gift card refunds are allowed in the context of a previous transaction, but
free range gift card refunds are not allowed.  Use the gift card activation
API if you need to add more funds to a gift card.

**Store and Forward Support**

Refunds are not permitted when a terminal falls back to store and forward mode.

**Auto Voids**

If a refund referencing a previous transaction is executed for the full amount
before the original transaction's batch is closed, the refund is automatically
converted to a void.  This saves the merchant a little bit of money.

**Cryptocurrency**

Note that refunds are not supported for cryptocurrency.  You must refund crypto transactions
manually from your cryptocurrency wallet.




```c#
// Populate request parameters.
RefundRequest request = new RefundRequest
{
    TransactionId = "<PREVIOUS TRANSACTION ID>",
    Amount = "5.00",
};

// Run the transaction.
AuthorizationResponse response = await blockchyp.RefundAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Void



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

Mistakes happen.  If a transaction is made by mistake, you can void it
with this API.  All that's needed is to pass in a Transaction ID and execute
the void before the original transaction's batch closes.

Voids work with EBT and gift card transactions with no additional parameters.

**Cryptocurrency**

Note that voids are not supported for cryptocurrency.  You must refund crypto transactions
manually from your cryptocurrency wallet.




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

#### Time Out Reversal



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

Payment transactions require a stable network to function correctly and
no network is stable all the time.  Time out reversals are a great line
of defense against accidentally double charging consumers when payments
are retried during shaky network conditions.

We highly recommend developers use this API whenever a charge, preauth, or refund transaction times out.  If you don't receive a definitive response
from BlockChyp, you can't be certain about whether or not the transaction went through.

The best practice in this situation is to send a time out reversal request.  Time out reversals check for a transaction and void it if it exists.

The only caveat is that developers must use the `transactionRef` property (`txRef` for the CLI) when executing charge, preauth, and refund transactions.

The reason for this requirement is that if a system never receives a definitive
response for a transaction, the system would never have received the BlockChyp
generated Transaction ID.  We have to fall back to Transaction Ref to identify
a transaction.

**Cryptocurrency**

Note that refunds are not supported for cryptocurrency.  You must refund crypto transactions
manually from your cryptocurrency wallet.




```c#
// Populate request parameters.
AuthorizationRequest request = new AuthorizationRequest
{
    TransactionRef = "<LAST TRANSACTION REF>",
};

// Run the transaction.
AuthorizationResponse response = await blockchyp.ReverseAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Gift Card Activation



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API activates or adds value to BlockChyp gift cards.
Just pass in the terminal name and the amount to add to the card.
Once the customer swipes their card, the terminal will use keys
on the mag stripe to add value to the card.

You don't need to handle a new gift card activation or a gift card recharge any
differently.  The terminal firmware will figure out what to do on its
own while also returning the new balance for the gift card.

This is the part of the system where BlockChyp's blockchain DNA comes
closest to the surface.  The BlockChyp gift card system doesn't really
use gift card numbers.  This means they can't be stolen.

BlockChyp identifies cards with an elliptic curve public key instead.
Gift card transactions are actually blocks signed with those keys.
This means there are no shared secrets sent over the network.
To keep track of a BlockChyp gift card, hang on to the **public key** returned
during gift card activation.  That's the gift card's elliptic curve public key.

We sometimes print numbers on our gift cards, but these are actually
decimal encoded hashes of a portion of the public key to make our gift
cards seem *normal* to *normies*.  They can be used
for balance checks and play a lookup role in online gift card
authorization, but are of little use beyond that.

**Voids and Reversals**

Gift card activations can be voided and reversed just like any other
BlockChyp transaction.  Use the Transaction ID or Transaction Ref
to identify the gift activation transaction as you normally would for
voiding or reversing a conventional payment transaction.

**Importing Gift Cards**

BlockChyp does have the ability to import gift card liability from
conventional gift card platforms.  Unfortunately, BlockChyp does not
support activating cards on third party systems.  However, you can import
your outstanding gift cards and customers can swipe them on the
terminals like BlockChyp's standard gift cards.

No special coding is required to access this feature.  The gateway and
terminal firmware handle everything for you.

**Third Party Gift Card Networks**

BlockChyp does not currently provide any native support for other gift card
platforms beyond importing gift card liability.  We do have a white listing system
that can be used to support your own custom gift card implementations.  We have a security review
process before we can allow a BIN range to be white listed, so contact
support@blockchyp.com if you need to white list a BIN range.




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

#### Balance



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API checks a gift or EBT card balance.

**Gift Card Balance Checks**

For gift cards, pass in a terminal name and the customer will be prompted
to swipe a card on that terminal.  The remaining balance will be displayed
briefly on the terminal screen and the API response will include the gift card's public key and the remaining balance.

**EBT Balance Checks**

All EBT transactions require a PIN, so to check an EBT card balance,
you need to pass in the `ebt` flag just like you would for a normal EBT
charge transaction.  The customer will be prompted to swipe their card and
enter a PIN code.  If everything checks out, the remaining balance on the 
card will be displayed on the terminal for the customer and returned with the API response.

**Testing Gift Card Balance Checks**

Test gift card balance checks work no differently than live gift cards.  You
must activate a test gift card first to test balance checks.  Test
gift cards are real blockchain cards that live on our parallel test blockchain.

**Testing EBT Gift Card Balance Checks**

All test EBT transactions assume a starting balance of $100.00.  As a result,
test EBT balance checks always return a balance of $100.00.




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

#### Close Batch



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API will close the merchant's batch if it's currently open.

By default, merchant batches will close automatically at 3 AM in their
local time zone.  The automatic batch closure time can be changed
in the Merchant Profile or disabled completely.

If automatic batch closure is disabled, you'll need to use this API to
close the batch manually.



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

#### Send Payment Link



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API allows you to send an invoice to a customer and capture payment
via a BlockChyp hosted payment page.

If you set the `autoSend` flag, BlockChyp will send a basic invoice email
to the customer for you that includes the payment link.  If you'd rather have
more control over the look of the email message, you can omit the `autoSend`
flag and send the customer email yourself.

There are a lot of optional parameters for this API, but at a minimum
you'll need to pass in a total, customer name, and email address. (Unless
you use the `cashier` flag.)

**Customer Info**

Unless you're using the `cashier` flag, you must specify a customer; either by
creating a new customer record inline or passing in an existing Customer ID or Customer Ref.

**Line Item Level Data**

It's not strictly required, but we strongly recommend sending line item level
detail with every request.  It will make the invoice look more complete
and the data format for line item level data is the exact same format used
for terminal line item display, so the same code can be used to support both areas.

**Descriptions**

You can also provide a free form description or message to display near
the bottom of the invoice.  Usually this is some kind of thank you note
or instruction.

**Terms and Conditions**

You can include long form contract language with a request and capture
terms and conditions accepted at the same time payment is captured.

The interface is identical to that used for the terminal based Terms and
Conditions API in that you can pass in content directly via `tcContent` or via
a preconfigured template via `tcAlias`.  The Terms and Conditions log will also be updated when
agreement acceptance is incorporated into a send link request.

**Auto Send**

BlockChyp does not send the email notification automatically.   This safeguard prevents real 
emails from going out when you may not expect them If you want BlockChyp to send the email 
for you, just add the `autoSend` flag with all requests.

**Cryptocurrency**

If the merchant is configured to support cryptocurrency transactions, the payment page will
display additional UI widgets that allowing customers to switch to a crypto payment method.

**Tokenization**

Add the `enroll` flag to a send link request to enroll the payment method
in the token vault.

**Cashier Facing Card Entry**

BlockChyp can be used to generate internal/cashier facing card entry pages as well.  This is
designed for situations where you might need to take a phone order and don't
have an available terminal.

If you pass in the `cashier` flag, no email will be sent and you'll be able to
load the link in a browser or iframe for payment entry.  When the `cashier` flag
is used, the `autoSend` flag will be ignored.

Note that cryptocurrency is not supported for cashier facing payment entry.

**Payment Notifications**

When a customer successfully submits payment, the merchant will receive an email
notifying them that the payment was received.

**Real Time Callback Notifications**

Email notifications are fine, but you may want your system to be informed
immediately whenever a payment event occurs.  By using the optional `callbackUrl` request
property, you can specify a URL to which the Authorization Response will be posted
every time the user submits a payment, whether approved or otherwise.

The response will be sent as a JSON encoded POST request and will be the exact
same format as all BlockChyp charge and preauth transaction responses.

**Status Polling**

If real time callbacks aren't practical or necessary in your environment, you can
always use the Transaction Status API described below.

A common use case for the send link API with status polling is curbside pickup.
You could have your system check the Transaction Status when a customer arrives to
ensure it's been paid without necessarily needing to create background threads
to constantly poll for status updates.




```c#
// Populate request parameters.
PaymentLinkRequest request = new PaymentLinkRequest
{
    TransactionRef = "<TX REF>",
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
        EmailAddress = "notifications@blockchypteam.m8r.co",
        SmsNumber = "(123) 123-1231",
    },
};

// Run the transaction.
PaymentLinkResponse response = await blockchyp.SendPaymentLinkAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Cancel Payment Link



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API cancels a payment link.




```c#
// Populate request parameters.
CancelPaymentLinkRequest request = new CancelPaymentLinkRequest
{
    LinkCode = "<PAYMENT LINK CODE>",
};

// Run the transaction.
CancelPaymentLinkResponse response = await blockchyp.CancelPaymentLinkAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Transaction Status



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API returns the current status for any transaction.  You can lookup a transaction
by its BlockChyp assigned Transaction ID or your own Transaction Ref.

You should alway use globally unique Transaction Ref values, but in the event
that you duplicate Transaction Refs, the most recent transaction matching your
Transaction Ref is returned.




```c#
// Populate request parameters.
TransactionStatusRequest request = new TransactionStatusRequest
{
    TransactionId = "<TRANSACTION ID>",
};

// Run the transaction.
AuthorizationResponse response = await blockchyp.TransactionStatusAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Cash Discount



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API calculates the surcharge, cash discount, and total amounts for cash transactions.

If you're using BlockChyp's cash discounting features, you can use this endpoint
to ensure the numbers and receipts for true cash transactions are consistent
with transactions processed by BlockChyp.




```c#
// Populate request parameters.
CashDiscountRequest request = new CashDiscountRequest
{
    Amount = "100.00",
    CashDiscount = true,
    Surcharge = true,
};

// Run the transaction.
CashDiscountResponse response = await blockchyp.CashDiscountAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Batch History



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This endpoint allows developers to query the gateway for the merchant's batch history.
The data will be returned in descending order of open date with the most recent
batch returned first.  The results will include basic information about the batch.
Consider using the Batch Details API for more detail about a specific batch.

**Limiting Results**

This API will return a maximum of 250 results.  Use the `maxResults` property to
limit maximum results even further and use the `startIndex` property to
page through results that span multiple queries.

For example, if you want the ten most recent batches, pass in a value of
`10` for `maxResults`.  Also note that `startIndex` is zero based. Use a value of `0` to
get the first batch in the dataset.

**Filtering by Date Range**

You can also filter results by date.  Use the `startDate` and `endDate`
properties to return only those batches opened between those dates.
You can use either `startDate` and `endDate` and you can use date filters
in conjunction with `maxResults` and `startIndex`




```c#
// Populate request parameters.
BatchHistoryRequest request = new BatchHistoryRequest
{
    MaxResults = 250,
    StartIndex = 0,
};

// Run the transaction.
BatchHistoryResponse response = await blockchyp.BatchHistoryAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Batch Details



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API allows developers to pull down details for a specific batch,
including captured volume, gift card activity, expected deposit, and
captured volume broken down by terminal.

The only required request parameter is `batchId`.  Batch IDs are returned
with every transaction response and can be discovered using the Batch
History API.




```c#
// Populate request parameters.
BatchDetailsRequest request = new BatchDetailsRequest
{
    BatchId = "<BATCH ID>",
};

// Run the transaction.
BatchDetailsResponse response = await blockchyp.BatchDetailsAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Transaction History



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This endpoint provides several different methods to sift through
transaction history.

By default with no filtering properties, this endpoint will return the 250
most recent transactions.

**Limiting Results**

This API will return a maximum of 50 results in a single query.  Use the `maxResults` property
to limit maximum results even further and use the `startIndex` property to
page through results that span multiple queries.

For example, if you want the ten most recent batches, pass in a value of
`10` for `maxResults`.  Also note that `startIndex` is zero based. Use a value of `0` to
get the first transaction in the dataset.

**Filtering By Date Range**

You can also filter results by date.  Use the `startDate` and `endDate`
properties to return only transactions run between those dates.
You can use either `startDate` or `endDate` and you can use date filters
in conjunction with `maxResults` and `startIndex`

**Filtering By Batch**

To restrict results to a single batch, pass in the `batchId` parameter.

**Filtering By Terminal**

To restrict results to those executed on a single terminal, pass in the terminal name.

**Combining Filters**

None of the above filters are mutually exclusive.  You can combine any of the
above properties in a single request to restrict transaction results to a
narrower set of results.

**Searching Transaction History**

You can search transaction history by passing in search criteria with the 
`query` option.  The search system will match the amount (requested and authorized),
last four of the card number, cardholder name, and the auth code.

Note that when search queries are used, terminalName or 
batch id filters are not supported.




```c#
// Populate request parameters.
TransactionHistoryRequest request = new TransactionHistoryRequest
{
    MaxResults = 10,
    BatchId = "<BATCH ID>",
};

// Run the transaction.
TransactionHistoryResponse response = await blockchyp.TransactionHistoryAsync(request);

// View the result.
Console.WriteLine(response);

```

#### List Queued Transactions



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

Returns a list of transaction refs of transactions queued on a terminal.
Details about the transactions can be retrieved using the Transaction Status
API.




```c#
// Populate request parameters.
ListQueuedTransactionsRequest request = new ListQueuedTransactionsRequest
{
    TerminalName = "Test Terminal",
};

// Run the transaction.
ListQueuedTransactionsResponse response = await blockchyp.ListQueuedTransactionsAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Delete Queued Transaction



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

Deletes one or all queued transactions from a terminal. If `*` is passed as
a transaction ref, then the entire terminal queue will be cleared. An error is
returned if the passed transaction ref is not queued on the terminal.




```c#
// Populate request parameters.
DeleteQueuedTransactionRequest request = new DeleteQueuedTransactionRequest
{
    TerminalName = "Test Terminal",
    TransactionRef = "*",
};

// Run the transaction.
DeleteQueuedTransactionResponse response = await blockchyp.DeleteQueuedTransactionAsync(request);

// View the result.
Console.WriteLine(response);

```

### Terminal Management Endpoints


These APIs support terminal management functions and additional terminal 
features such as line item display, messages, and interactive prompts.  
These features can be used to extend a point of sale system's functionality.



#### Terminal Ping



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This simple test transaction helps ensure good communication with a payment terminal 
and is usually the first test you'll run in development.

It tests communication with the terminal and returns a positive response if everything
is okay.  It works the same way in local or cloud relay mode.

If you get a positive response, you've successfully verified all of the following:

* The terminal is online.
* There is a valid route to the terminal.
* The API Credentials are valid.




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

#### Terminal Locate



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This endpoint returns a terminal's routing and location information.

The result will indicate whether or not the terminal is in cloud relay mode and will
return the local IP address if the terminal is in local mode.

The terminal will also return the public key for the terminal.




```c#
// Populate request parameters.
LocateRequest request = new LocateRequest
{
    TerminalName = "Test Terminal",
};

// Run the transaction.
LocateResponse response = await blockchyp.LocateAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Terminal Clear



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API interrupts whatever a terminal may be doing and returns it to the
idle state.





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

#### Terminal Status



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API returns the current status of a payment terminal.  This is typically used
as a way to determine if the terminal is busy before sending a new transaction.

If the terminal is busy, `idle` will be false and the `status` field will return
a short string that indicates the transaction type currently in progress.  The system
will also return the timestamp of the last status change in the `since` field.

The `cardInSlot` field in the response will indicates whether or not a card is currently in the card reader slot.

If the system is running a payment transaction and you wisely passed in a
Transaction Ref, this API will also return the Transaction Ref of the in progress
transaction.

The table below lists all possible status responses.

| Status Code          | Description                                                                                |
|----------------------|--------------------------------------------------------------------------------------------|
| idle                 | The terminal is idle and ready for transactions.  The default branding is being displayed. |
| activate             | The terminal is the processing of activating and pairing with the merchant account.        |
| balance              | A balance check (EBT or Gift Card) is pending on the terminal.                             |
| boolean-prompt       | A boolean prompt (yes/no) operation is pending on the terminal.                            |      
| signature            | A signature capture is pending.                                                            |
| crypto               | A cryptocurrency transaction is pending.                                                   |
| enroll               | A token vault enrollment operation is pending.                                             |
| gift-activate        | A gift card activation operation is in progress.                                           | 
| message              | The terminal is displaying a custom message.                                               |
| charge               | The terminal is executing a charge transaction.                      |
| preauth              | The terminal is executing a preauth transaction. |
| refund               | The terminal is executing a refund transaction. |
| survey               | The terminal is displaying post transaction survey questions. |
| terms-and-conditions | The terminal is pending terms and conditions acceptance and signature. |
| text-prompt          | The terminal is awaiting response to a text input prompt. |
| txdisplay            | The terminal is displaying transaction and/or line item level details. |




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

#### Capture Signature



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This endpoint captures a written signature from the terminal and returns the
image.

Unlike the Terms & Conditions API, this endpoint performs basic signature
capture with no agreement display or signature archival.

Under the hood, signatures are captured in a proprietary vector format and
must be converted to a common raster format in order to be useful to most
applications.  At a minimum, you must specify an image format using the
`sigFormat` parameter.  Currently, JPG and PNG are supported.

By default, images are returned in the JSON response as hex encoded binary.
You can redirect the binary image output to a file using the `sigFile`
parameter.

You can also scale the output image to your preferred width by
passing in a `sigWidth` parameter.  The image will be scaled to that
width, preserving the aspect ratio of the original image.




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

#### New Transaction Display



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API sends totals and line item level data to the terminal.

At a minimum, you should send total information as part of a display request,
including `total`, `tax`, and `subtotal`.

You can also send line item level data and each line item can have a `description`,
`qty`, `price`, and `extended` price.

If you fail to send an extended price, BlockChyp will multiply the `qty` by the
`price`.  However, we strongly recommend you precalculate all the fields yourself
to ensure consistency.  For example, your treatment of floating-point multiplication 
and rounding may differ slightly from BlockChyp's.

**Discounts**

You have the option to show discounts on the display as individual line items
with negative values or you can associate discounts with a specific line item.
You can apply any number of discounts to an individual line item with a description
and amount.




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

#### Update Transaction Display



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

Similar to *New Transaction Display*, this variant allows developers to update
line item level data currently being displayed on the terminal.

This feature is designed for situations where you want to update the terminal display as
items are scanned.  You'll only have to send information to the
terminal that's changed, which usually means the new line item and updated totals.

If the terminal is not in line item display mode and you invoke this endpoint,
the first invocation will behave like a *New Transaction Display* call.

At a minimum, you should send total information as part of a display request,
including `total`, `tax`, and `subtotal`.

You can also send line item level data and each line item can have a `description`,
`qty`, `price`, and `extended` price.

If you fail to send an extended price, BlockChyp will multiply the `qty` by the
`price`.  However, we strongly recommend you precalculate all the fields yourself
to ensure consistency.  For example, your treatment of floating-point multiplication and rounding
may differ slightly from BlockChyp's.

**Discounts**

You have the option to show discounts on the display as individual line items
with negative values or you can associate discounts with a specific line item.
You can apply any number of discounts to an individual line item with a description
and amount.




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

#### Display Message



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API displays a message on the payment terminal.

Just specify the target terminal and the message using the `message` parameter.




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

#### Boolean Prompt



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API Pprompts the customer to answer a yes or no question.

You can specify the question or prompt with the `prompt` parameter and
the response is returned in the `response` field.

This can be used for a number of use cases including starting a loyalty enrollment
workflow or customer facing suggestive selling prompts.

**Custom Captions**

You can optionally override the "YES" and "NO" button captions by
using the `yesCaption` and `noCaption` request parameters.




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

#### Text Prompt



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API prompts the customer to enter numeric or alphanumeric data.

Due to PCI rules, free-form prompts are not permitted when the response
could be any valid string.  The reason for this is that a malicious
developer (not you, of course) could use text prompts to ask the customer to
input a card number or PIN code.

This means that instead of providing a prompt, you provide a `promptType` instead.

The prompt types currently supported are listed below:

* **phone**: Captures a phone number.
* **email**: Captures an email address.
* **first-name**: Captures a first name.
* **last-name**: Captures a last name.
* **customer-number**: Captures a customer number.
* **rewards-number**: Captures a rewards number.

You can specify the prompt with the `promptType` parameter and
the response is returned in the `response` field.





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

#### List Terminals



* **API Credential Types:** Merchant & Partner
* **Required Role:** Terminal Management

This API returns details about terminals associated with a merchant account.

Status and resource information is returned for all terminals along with a preview of the 
current branding image displayed on the terminal




```c#
// Populate request parameters.
TerminalProfileRequest request = new TerminalProfileRequest
{

};

// Run the transaction.
TerminalProfileResponse response = await blockchyp.TerminalsAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Deactivate Terminal



* **API Credential Types:** Merchant & Partner
* **Required Role:** Terminal Management

This API deactivates a payment terminal.

If the terminal exists and is currently online, it will be removed from the merchant's 
terminal inventory.  The terminal will be remotely cleared and factory reset.




```c#
// Populate request parameters.
TerminalDeactivationRequest request = new TerminalDeactivationRequest
{
    TerminalId = "<TERMINAL ID>",
};

// Run the transaction.
Acknowledgement response = await blockchyp.DeactivateTerminalAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Activate Terminal



* **API Credential Types:** Merchant & Partner
* **Required Role:** Terminal Management

This API activates a payment terminal.

If successful, the payment terminal will restart, generate new encryption keys, and download any active
branding assets for the merchant account it's been added to.

Activation requests require an activation code and a unique terminal name.  All terminal names must be unique across
a merchant account.

Optional Parameters

* **merchantId:** For partner scoped API credentials, a merchant ID is required.  For merchant scoped API credentials, the merchant ID is implicit and cannot be overridden.
* **cloudRelay:** Activates the terminal in cloud relay mode.



```c#
// Populate request parameters.
TerminalActivationRequest request = new TerminalActivationRequest
{
    TerminalName = "Test Terminal",
    ActivationCode = "<ACTIVATION CODE>",
};

// Run the transaction.
Acknowledgement response = await blockchyp.ActivateTerminalAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Reboot Terminal



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API reboots the terminal.




```c#
// Populate request parameters.
PingRequest request = new PingRequest
{
    TerminalName = "Test Terminal",
};

// Run the transaction.
Acknowledgement response = await blockchyp.RebootAsync(request);

// View the result.
Console.WriteLine(response);

```

### Terms & Conditions Endpoints


Developers can use BlockChyp to display and capture acceptance of contracts or agreements related to transactions.
These agreements can be any long-form contract ranging from rental agreements to HIPPA disclosures.

There are two basic approaches to terms and conditions capture.  Merchants can store contract templates in 
BlockChyp or they can send the full agreement text as part of every API call.  The right approach will largely 
depend on whether or not the system being integrated with BlockChyp already has a mechanism for organizing 
and managing agreements.  For systems that already have this feature built in, it's probably not necessary 
to use Terms and Conditions.

When agreements are displayed on a terminal, the consumer can scroll through and read the entire agreement,
and provide a signature.  Results are returned as part of the API response, but BlockChyp also stores a 
record of the agreement including the signature image, timestamp, and the full text of the agreement that was 
agreed to.

The Terms and Conditions Log APIs can be used to search and retrieve acceptance records.  Those records
can also be linked to a transaction if a transaction id is provided with the original API request.



#### Terms & Conditions Capture



* **API Credential Types:** Merchant
* **Required Role:** Terms & Conditions Management

This API allows you to prompt a customer to accept a legal agreement on the terminal
and (usually) capture their signature.

Content for the agreement can be specified in two ways.  You can reference a
previously configured T&C template or pass in the full agreement text with every request.

**Using Templates**

If your application doesn't keep track of agreements you can leverage BlockChyp's
template system.  You can create any number of T&C Templates in the merchant dashboard
and pass in the `tcAlias` flag to specify which one should display.

**Raw Content**

If your system keeps track of the agreement language or executes complicated merging
and rendering logic, you can bypass our template system and pass in the full text with
every transaction.  Use `tcName` to pass in the agreement name and `tcContent` to
pass in the contract text.  Note that only plain text is supported.

**Bypassing Signatures**

Signature images are captured by default.  If for some reason this doesn't fit your
use case and you'd like to capture acceptance without actually capturing a signature image, set
the `disableSignature` flag in the request.

**Terms & Conditions Log**

Every time a user accepts an agreement on the terminal, the signature image (if captured),
will be uploaded to the gateway.  The image will also be added to the log along with the full text of the
agreement.  This preserves the historical record in the event that standard agreements
or templates change over time.

**Associating Agreements with Transactions**

To associate a Terms & Conditions log entry with a transaction, just pass in the
Transaction ID or Transaction Ref for the associated transaction.





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

#### List Templates



* **API Credential Types:** Merchant
* **Required Role:** Terms & Conditions Management

This API returns all terms and conditions templates associated with a merchant account.




```c#
// Populate request parameters.
TermsAndConditionsTemplateRequest request = new TermsAndConditionsTemplateRequest
{

};

// Run the transaction.
TermsAndConditionsTemplateResponse response = await blockchyp.TcTemplatesAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Get Template



* **API Credential Types:** Merchant
* **Required Role:** Terms & Conditions Management

This API returns as single terms and conditions template.




```c#
// Populate request parameters.
TermsAndConditionsTemplateRequest request = new TermsAndConditionsTemplateRequest
{
    TemplateId = "<TEMPLATE ID>",
};

// Run the transaction.
TermsAndConditionsTemplate response = await blockchyp.TcTemplateAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Update Template



* **API Credential Types:** Merchant
* **Required Role:** Terms & Conditions Management

This API updates or creates a terms and conditions template.

Terms and conditions templates are fairly simple and essentially consist of a name, content, and alias.

The name is the caption that will be displayed at the top of the screen.  The alias is a code or short
description that will be used in subsequence API calls to refer to the template.

Content is the full text of the contract or agreement.  Currently, no special formatting or
merge behavior is supported.  Only plain text is supported.




```c#
// Populate request parameters.
TermsAndConditionsTemplate request = new TermsAndConditionsTemplate
{
    Alias = "HIPPA",
    Name = "HIPPA Disclosure",
    Content = "Lorem ipsum dolor sit amet.",
};

// Run the transaction.
TermsAndConditionsTemplate response = await blockchyp.TcUpdateTemplateAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Delete Template



* **API Credential Types:** Merchant
* **Required Role:** Terms & Conditions Management

This API deletes a terms and conditions template.

If a template is deleted, its alias can be reused and any previous Terms & Conditions log entry
derived from the template being deleted is fully preserved since log entries always include
a complete independent copy of the agreement text.




```c#
// Populate request parameters.
TermsAndConditionsTemplateRequest request = new TermsAndConditionsTemplateRequest
{
    TemplateId = "<TEMPLATE ID>",
};

// Run the transaction.
Acknowledgement response = await blockchyp.TcDeleteTemplateAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Terms & Conditions Log



* **API Credential Types:** Merchant
* **Required Role:** Terms & Conditions Management

This API allows developers to search and sort through terms and conditions log entries.

The default API call with no parameters will return the last 250 log entries in descending order.

Optional parameters can be used to filter and query the data set.

* **transactionId:** If provided, returns only those log entries associated with a specific transactions.  Paging and date filters are ignored if this parameter is used.
* **maxResults:** The max number of results to return in a single page.  Defaults to 250 and 250 is the maximum value.
* **startIndex** The zero based start index of results within the full result set to return.  Used to advance pages.  For example, if the page size is 10 and you wish to return the second page of results, send a startIndex of 10. 
* **startDate**: An optional start date for results provided as an ISO 8601 timestamp. (e.g. 2022-05-24T13:51:38+00:00)
* **endDate**: An optional end date for results provided as an ISO 8601 timestamp. (e.g. 2022-05-24T13:51:38+00:00)




```c#
// Populate request parameters.
TermsAndConditionsLogRequest request = new TermsAndConditionsLogRequest
{
    LogEntryId = "<LOG ENTRY ID>",
};

// Run the transaction.
TermsAndConditionsLogResponse response = await blockchyp.TcLogAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Terms & Conditions Details



* **API Credential Types:** Merchant
* **Required Role:** Terms & Conditions Management

This API returns details for a single terms and conditions log entry.  The `logEntryId` of the record to be returned is the only required parameter.

The signature image is returned as Base 64 encoded binary in the image format specified by the `sigFormat` field. 
The default format is PNG.




```c#
// Populate request parameters.
TermsAndConditionsLogRequest request = new TermsAndConditionsLogRequest
{
    LogEntryId = "<ENTRY ID>",
};

// Run the transaction.
TermsAndConditionsLogEntry response = await blockchyp.TcEntryAsync(request);

// View the result.
Console.WriteLine(response);

```

### Token Management


BlockChyp supports saved payments and recurring payments through the use of tokens.  Tokens can be created
via the Enroll API or the web tokenizer.  Once created, these tokens can be used for subsequent payments 
or associated with customer records as saved payment methods.

Tokens are limited to a single merchant by default, but can be shared across an organization for multi-location 
merchants by special arrangement with BlockChyp.  Contact your BlockChyp rep to setup token sharing.



#### Enroll



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API allows you to tokenize and enroll a payment method in the token
vault.  You can also pass in customer information and associate the
payment method with a customer record.

A token is returned in the response that can be used in subsequent charge,
preauth, and refund transactions.

**Gift Cards and EBT**

Gift Cards and EBT cards cannot be tokenized.

**E-Commerce Tokens**

The tokens returned by the enroll API and the e-commerce web tokenizer
are the same tokens and can be used interchangeably.




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

#### Token Metadata



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API retrieves status and metadata information about a token, 
including any links to customer records.  

This will also return any customer records related to the card
behind the token.  If the underlying card has been tokenized
multiple times, all customers related to the card will be returned,
even if those customer associations are related to other tokens.




```c#
// Populate request parameters.
TokenMetadataRequest request = new TokenMetadataRequest
{
    Token = "<TOKEN>",
};

// Run the transaction.
TokenMetadataResponse response = await blockchyp.TokenMetadataAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Link Token



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API links a payment token with a customer record.  Usually this would only be needed
to reverse a previous unlink operation.




```c#
// Populate request parameters.
LinkTokenRequest request = new LinkTokenRequest
{
    Token = "<TOKEN>",
    CustomerId = "<CUSTOMER ID>",
};

// Run the transaction.
Acknowledgement response = await blockchyp.LinkTokenAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Unlink Token



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API removes a payment token link from a customer record.

This will remove links between the customer record and all tokens
for the same underlying card.




```c#
// Populate request parameters.
UnlinkTokenRequest request = new UnlinkTokenRequest
{
    Token = "<TOKEN>",
    CustomerId = "<CUSTOMER ID>",
};

// Run the transaction.
Acknowledgement response = await blockchyp.UnlinkTokenAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Delete Token



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API deletes a payment token from the gateway.  Tokens are automatically deleted if they have not been used
for a year.




```c#
// Populate request parameters.
DeleteTokenRequest request = new DeleteTokenRequest
{
    Token = "<TOKEN>",
};

// Run the transaction.
DeleteTokenResponse response = await blockchyp.DeleteTokenAsync(request);

// View the result.
Console.WriteLine(response);

```

### Customer Endpoints


These APIs allow developers to create and manage customer records in BlockChyp.  Developers who wish to use
BlockChyp for tokenized recurring payments can use tokens directly if they have their own customer management
system.  However, BlockChyp provides additional tools for managing customers and keeping track of a customer's saved
payment tokens.

In addition, if customer features are used, BlockChyp can detect a payment method associated with an existing
customer, and return customer data with payment transactions.  This can be used as a passive method to detect
repeat customers.



#### Update Customer



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API adds or updates a customer record.

If you pass in customer information including `firstName`, `lastName`, `email`,
or `sms` without any Customer ID or Customer Ref, a new record will
be created.

If you pass in `customerRef` and `customerId`, the customer record will be updated
if it exists.

**Customer Ref**

The `customerRef` field is optional, but highly recommended as this allows you
to use your own customer identifiers instead of storing BlockChyp's Customer IDs
in your systems.

**Creating Customer Records With Payment Transactions**

If you have customer information available at the time a payment transaction is
executed, you can pass all the same customer information directly into a payment transaction.  BlockChyp
will create a customer record at the same time payment is captured.  The advantage of this approach is
that the customer's payment card is automatically associated with the customer record in a single step.
If the customer uses the payment card in the future, the customer data will automatically
be returned.  You won't need to ask the customer to provide any additional information.




```c#
// Populate request parameters.
UpdateCustomerRequest request = new UpdateCustomerRequest
{
    Customer = new Customer
    {
        Id = "<CUSTOMER ID>",
        CustomerRef = "Customer reference string",
        FirstName = "FirstName",
        LastName = "LastName",
        CompanyName = "Company Name",
        EmailAddress = "notifications@blockchypteam.m8r.co",
        SmsNumber = "(123) 123-1231",
    },
};

// Run the transaction.
CustomerResponse response = await blockchyp.UpdateCustomerAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Retrieve Customer



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

With this API, you can retrieve detailed information about a customer record, including saved payment
methods if available.

Customers can be looked up by `customerId` or `customerRef`.




```c#
// Populate request parameters.
CustomerRequest request = new CustomerRequest
{
    CustomerId = "<CUSTOMER ID>",
};

// Run the transaction.
CustomerResponse response = await blockchyp.CustomerAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Search Customer



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API searches the customer database and returns matching results.

Use `query` to pass in a search string and the system will return all results whose
first or last names contain the query string.




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

#### Delete Customer



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

This API deletes a customer record.




```c#
// Populate request parameters.
DeleteCustomerRequest request = new DeleteCustomerRequest
{
    CustomerId = "<CUSTOMER ID>",
};

// Run the transaction.
DeleteCustomerResponse response = await blockchyp.DeleteCustomerAsync(request);

// View the result.
Console.WriteLine(response);

```

### Survey Reference


These APIs are used to work with post-transaction surveys and survey data.

Merchants can optionally configure scaled (1-5) or yes/no questions that can be presented to consumers
after every approved Charge and Preauth transaction.  Surveys do not require any custom programming and
merchants can simply configure them without the point-of-sale system needing any additional customization.

However, these APIs allow point-of-sale or third-party system developers to integrate survey question configuration
or result visualization into their own systems.



#### List Questions



* **API Credential Types:** Merchant
* **Required Role:** Survey Management

This API returns all survey questions in the order in which they would be presented on the terminal.

All questions are returned, whether enabled or disabled.




```c#
// Populate request parameters.
SurveyQuestionRequest request = new SurveyQuestionRequest
{

};

// Run the transaction.
SurveyQuestionResponse response = await blockchyp.SurveyQuestionsAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Question Details



* **API Credential Types:** Merchant
* **Required Role:** Survey Management

This API returns a single survey question with response data.  `questionId` is required.




```c#
// Populate request parameters.
SurveyQuestionRequest request = new SurveyQuestionRequest
{
    QuestionId = "<QUESTION ID>",
};

// Run the transaction.
SurveyQuestion response = await blockchyp.SurveyQuestionAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Update Question



* **API Credential Types:** Merchant
* **Required Role:** Survey Management

This API updates or creates survey questions.  `questionText` and `questionType` are required 
fields.  The following values are valid for `questionType`.

* **yes_no:** Use for simple yes or no questions.
* **scaled:** Displays the question with buttons that allow the customer to respond with values from 1 through 5.

Questions are disabled by default.  Pass in `enabled` to enable a question.

The `ordinal` field is used to control the sequence of questions when multiple questions are enabled.  We recommend keeping
the number of questions minimal.




```c#
// Populate request parameters.
SurveyQuestion request = new SurveyQuestion
{
    Id = "<QUESTION ID>",
    Ordinal = 1,
    QuestionText = "Would you shop here again?",
    QuestionType = "yes_no",
    Enabled = true,
};

// Run the transaction.
SurveyQuestion response = await blockchyp.UpdateSurveyQuestionAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Delete Question



* **API Credential Types:** Merchant
* **Required Role:** Survey Management

This API deletes a survey question. `questionId` is a required parameter.




```c#
// Populate request parameters.
SurveyQuestionRequest request = new SurveyQuestionRequest
{
    QuestionId = "<QUESTION ID>",
};

// Run the transaction.
Acknowledgement response = await blockchyp.DeleteSurveyQuestionAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Survey Results



* **API Credential Types:** Merchant
* **Required Role:** Survey Management

This API returns survey results for a single question.

The results returned include the response rate, which is the percentage of transactions after which
the consumer provided an answer.

The `responses` array breaks down the results by answer, providing the total number of responses,
the answer's percentage of the total, and the average transaction amount associated with a specific
answer.

By default, all results based on all responses are returned.  However, developers may optionally provide 
`startDate` and `endDate` parameters to return only responses provided between certain dates.

`startDate` and `endDate` can be provided in MM/DD/YYYY or YYYY-MM-DD format.




```c#
// Populate request parameters.
SurveyResultsRequest request = new SurveyResultsRequest
{
    QuestionId = "<QUESTION ID>",
};

// Run the transaction.
SurveyQuestion response = await blockchyp.SurveyResultsAsync(request);

// View the result.
Console.WriteLine(response);

```

### Media and Branding Control


BlockChyp has a sophisticated terminal media and branding control platform.  Terminals can be configured to
display logos, images, videos, and slide shows when a terminal is idle.  Branding assets can be configured
at the partner, organization, and merchant level with fine-grained hour-by-hour schedules, if desired. 

Conceptually, all branding and media start with the media library.  Merchants, Partners, and Organizations can
upload images or video and build branding assets from uploaded media.

Slide shows can combine images from the media library into a timed loop of repeating images.

Branding Assets can then be used to combine media or slide shows with priority and timing rules to create what 
we call the Terminal Branding Stack.

We call a group of branding assets the *Terminal Branding Stack* because there are implicit rules about which 
branding assets take priority. For example, a merchant with no branding assets configured will inherit the 
branding rules from any organization to which the merchant may belong.  If the merchant doesn't belong to an organization 
or the organization has no branding rules configured, then the system will defer to branding defaults established 
by the point-of-sale or software partner that owns the merchant.

This feature enables partners and organizations (multi-store operators and large national chains) to configure branding
for potentially thousands of terminals from a single interface.

Terminal Branding can also be configured at the individual terminal level and a merchant's terminal fleet 
can be broken into groups and branding configured at the group level.  Branding configured at the terminal
level will always override branding from any higher level group.

The order of priority for the Terminal Branding Stack is given below.

* Terminal
* Terminal Group
* Merchant
* Organization (Region, Chain, etc)
* Partner
* BlockChyp Default Logo



#### Media Library



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API returns the entire media library associated with the API Credentials (Merchant, Partner, or Organization).  The media library results will include the ID used
to reference a media asset in slide shows and branding assets along with the full file url and thumbnail.




```c#
// Populate request parameters.
MediaRequest request = new MediaRequest
{

};

// Run the transaction.
MediaLibraryResponse response = await blockchyp.MediaAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Upload Media



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API supports media library uploads.  The operation of this API works slightly differently depending 
on the SDK platform.  In all cases, the intent is to allow the file's binary to be passed into the SDK using 
the lowest level I/O primitive possible in order to support situations where developers aren't working
with literal files.  It might be (and usually is) more convenient to work with buffers, raw bytes, or streams.

For example, the Go implementation accepts an `io.Reader` and the Java implementation accepts a
`java.io.InputStream`.  The CLI does accept a literal File URL via the `-file` command line parameter.

The following file formats are accepted as valid uploads:

* .png
* .jpg
* .jpeg
* .gif
* .mov
* .mpg
* .mp4
* .mpeg

The UploadMetadata object allows developers to pass additional metadata about the upload including
`fileName`, `fileSize`, and `uploadId`.

None of these values are required, but providing them can unlock some additional functionality relating to 
media uploads.  `fileName` will be used to record the original file name in the media library.  `fileSize` 
and `uploadId` are used to support upload status tracking, which is especially useful for large video file
uploads.  

The `fileSize` should be the file's full size in bytes.  

The `uploadId` value can be any random string.  This is the value you'll use to check the status of an upload
via the Upload Status API.  This API will return information needed to drive progress feedback on uploads and 
return video transcoding information.




```c#
// Populate request parameters.
UploadMetadata request = new UploadMetadata
{
    FileName = "aviato.png",
    FileSize = 18843,
    UploadId = "<RANDOM ID>",
};

// Run the transaction.
MediaMetadata response = await blockchyp.UploadMediaAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Upload Status



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API returns status and progress information about in progress or recently completed uploads.

Before calling this API, developers must first start a file upload with `fileSize` and `uploadId` parameters.

The data structure returned will include the file size, number of bytes uploaded, a narrative status
and flags indicating whether or not the upload is complete or post upload processing is in progress.  
If the upload is completed, the ID assigned to the media asset and a link to the thumbnail image will 
also be returned.




```c#
// Populate request parameters.
UploadStatusRequest request = new UploadStatusRequest
{
    UploadId = "<UPLOAD ID>",
};

// Run the transaction.
UploadStatus response = await blockchyp.UploadStatusAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Get Media Asset



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API returns a detailed media asset.  The data returned includes the exact same media information returned
by the full media library endpoint, including fully qualified URLs pointing to the original media file
and the thumbnail.




```c#
// Populate request parameters.
MediaRequest request = new MediaRequest
{
    MediaId = "<MEDIA ASSET ID>",
};

// Run the transaction.
MediaMetadata response = await blockchyp.MediaAssetAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Delete Media Asset



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API deletes a media asset.  Note that a media asset cannot be deleted if it is in use in a slide 
show or in the terminal branding stack.




```c#
// Populate request parameters.
MediaRequest request = new MediaRequest
{
    MediaId = "<MEDIA ASSET ID>",
};

// Run the transaction.
Acknowledgement response = await blockchyp.DeleteMediaAssetAsync(request);

// View the result.
Console.WriteLine(response);

```

#### List Slide Shows



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API returns all slide shows.  

Note that slide level data is not returned with this API.   Use the Get Slide Show API to get slide level detail.




```c#
// Populate request parameters.
SlideShowRequest request = new SlideShowRequest
{

};

// Run the transaction.
SlideShowResponse response = await blockchyp.SlideShowsAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Get Slide Show



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API returns a single slide show.  Slide level detail is returned with the fully qualified thumbnail URL
for each slide.

`slideShowId` is the only required parameter.




```c#
// Populate request parameters.
SlideShowRequest request = new SlideShowRequest
{
    SlideShowId = "<SLIDE SHOW ID>",
};

// Run the transaction.
SlideShow response = await blockchyp.SlideShowAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Update Slide Show



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API updates or creates a slide show.  `name`, `delay` and `slides` are required.

The slides property is an array of slides.  The Slide data structure has ordinal and thumbnail URL fields, 
but these are not required when updating or creating a slide show.  Only the `mediaId` field is required
when updating or creating a slide show.

When using the CLI, slides can be specified by sending a comma-separated list of media ids via the `-mediaId`
parameter.




```c#
// Populate request parameters.
SlideShow request = new SlideShow
{
    Name = "Test Slide Show",
    Delay = 5,
    Slides = new List<Slide>
    {
        new Slide
        {
            MediaId = "<MEDIA ID>",
        }
    },
};

// Run the transaction.
SlideShow response = await blockchyp.UpdateSlideShowAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Delete Slide Show



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API deletes a slide show  `slideShowId` is the only required parameter.




```c#
// Populate request parameters.
SlideShowRequest request = new SlideShowRequest
{
    SlideShowId = "<SLIDE SHOW ID>",
};

// Run the transaction.
Acknowledgement response = await blockchyp.DeleteSlideShowAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Terminal Branding



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API returns the full branding stack for a given API scope in the order of priority.

Consumers of this API should pay special attention to the `editable` field.  This field indicates whether or
not a branding asset is read-only from the perspective of a particular API Credential scope.

The `thumbnail` and `previewImage` attributes can be used to support building user interfaces for
managing the branding stack. `previewImage` differs from `thumbnail` in that the preview image is 
intended to show how an asset would actually look when displayed on the terminal.

`activeAsset` returns the asset that is currently visible on the terminal.




```c#
// Populate request parameters.
BrandingAssetRequest request = new BrandingAssetRequest
{

};

// Run the transaction.
BrandingAssetResponse response = await blockchyp.TerminalBrandingAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Update Branding Asset



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API updates or creates a single Branding Asset.

Branding Assets represent a single element of the terminal branding stack.  A Branding Asset can be a video or image,
in which case a `mediaId` referencing an asset from the media library must be provided.  A Branding Asset can also
be a slide show, in which case `slideShowId` must be provided.  Branding Assets must have a valid `mediaId` or a valid
`slideShowId`.  The optional `notes` field can be used to provide short notes and descriptions for a Branding asset.

**Visibility Flags**

In order for a Branding Asset to be visible on a terminal, the `enabled` flag must be set to true and the `preview`
must be turned off.  `preview` is intended to show how a proposed Branding Asset will behave
without pushing it to live terminals.  The Publish button in the BlockChyp merchant portal effectively turns
the `preview` setting off.

**Order and Sequencing**

The `ordinal` field is used to specify priority for a Branding Asset.  Assets with a higher value for `ordinal`
will be prioritized first.

**Padding Images**

For plain images, it's sometimes helpful to add margins to images.  This is especially helpful with logos
or any image file rendered without any white space or margins between the image content and edge of the image file.
Set the `padded` flag to true if you'd like BlockChyp to auto apply margins when displaying an image on 
the terminal.

**Scheduling**

By default, a Branding Asset placed on top of the Branding Stack, if it's `enabled` and not in `preview`
mode, will immediately be displayed on the terminal round the clock.

Branding Assets can be scheduled with effective start and stop dates for seasonal campaigns.  These assets can
also be scheduled for specific times of day and specific days of the week.

* **startDate:** Optional date after which the Branding Asset is eligible for display.  Can be provided in MM/DD/YYYY or YYYY-MM-DD format.
* **endDate:** Optional date before which the Branding Asset is eligible for display.  Can be provided in MM/DD/YYYY or YYYY-MM-DD format.
* **startTime** Optional time of day after which the branding asset is eligible for display.  Must be provided in 24 hour time: HH:MM.
* **endTime** Optional time of day before which the branding asset is eligible for display.  Must be provided in 24 hour time format: HH:MM
* **daysOfWeek** For branding assets that should only be displayed on certain days of the week, this field is an array of day of the week constants. (Constants vary by SDK platform.)

**Read Only Fields**

The Branding Asset data structure has a number of read only fields that are returned when Branding Assets are 
retrieved.  But these fields are ignored when you try to send them as part of an update.  These are derived
or calculated fields and are helpful for displaying branding assets in a management user interface, but 
cannot be changed via an API call.

These fields are:

* ownerId
* merchantId
* organizationId
* partnerId
* userId
* userName
* thumbnail
* lastModified
* editable
* assetType
* ownerType
* ownerTypeCaption
* previewImage
* narrativeEffectiveDates
* narrativeDisplayPeriod




```c#
// Populate request parameters.
BrandingAsset request = new BrandingAsset
{
    MediaId = "<MEDIA ID>",
    Padded = true,
    Ordinal = 10,
    StartDate = "01/06/2021",
    StartTime = "14:00",
    EndDate = "11/05/2024",
    EndTime = "16:00",
    Notes = "Test Branding Asset",
    Preview = false,
    Enabled = true,
};

// Run the transaction.
BrandingAsset response = await blockchyp.UpdateBrandingAssetAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Delete Branding Asset



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Media Management

This API deletes a Branding Asset from the branding stack.

Note that deleting a Branding Asset does not delete the underlying media from the media library or slide
show from the slide show library.




```c#
// Populate request parameters.
BrandingAssetRequest request = new BrandingAssetRequest
{
    AssetId = "<BRANDING ASSET ID>",
};

// Run the transaction.
Acknowledgement response = await blockchyp.DeleteBrandingAssetAsync(request);

// View the result.
Console.WriteLine(response);

```

### Merchant Management


These APIs allow partners to manage and configure their merchant portfolios.

Use of these APIs (other than the Merchant Profile API) requires partner scoped API credentials
with special roles and permissions that may require a special arrangement with BlockChyp.

For example, Partners usually can't board merchants directly, but must board merchants using
the standard underwriting process via offer codes and invitations.



#### Merchant Profile



* **API Credential Types:** Merchant
* **Required Role:** Payment API Access

The API returns detailed metadata about the merchant's configuration, including
basic identity information, terminal settings, store and forward settings,
and bank account information for merchants that support split settlement.

Some of these fields can be updated via the Update Merchant API, but many of these
fields are controlled by underwriting and cannot be altered outside of the 
underwriting and risk processes.

**Merchant Descriptive Fields**

The following fields are basic descriptive fields that can be used to describe and identify merchants.

* **companyName:** The merchant's official corporate entity name.
* **dbaName:** The business's DBA (doing business as) name.
* **contactName:** Name of the merchant's primary control contact.
* **contactNumber:** Primary control contact's phone number.
* **locationName:** Optional location name for multi-location operators.
* **storeNumber:** Optional store number for multi-location operators.
* **partnerRef:** Optional reference number partners can add to a merchant record.  Usually the partner's own identifier for the merchant.
* **timeZone:** Unix style local time zone for the merchant. Example: America/New_York.
* **publicKey:** Read only field.  The merchant's blockchain public key.  Generated and assigned when a merchant account is first created.
* **billingAddress:** Address for billing and written correspondence.
* **shippingAddress:** Physical shipping address. Usually the actual street address of the business.
* **status:** Current status of the merchant account.
* **tcDisabled:** Disables all terms and conditions features in the merchant dashboard.  Used to hide the feature if a partner has not chosen to support it.
* **gatewayOnly:** Indicates that a merchant has been boarded in gateway only mode.  Not common.

**Batch and Terminal Settings**

The following fields are used to control batch closure and high level terminal configuration.

* **batchCloseTime:** Time in 24 hour HH:MM format when batches will automatically close in the merchant's local time.  Defaults to 3 AM.
* **autoBatchClose:** Flag the determines whether or not batches will automatically close.  Defaults to true.
* **disableBatchEmails:** Flag that optionally turns off automatic batch closure notification emails.
* **cooldownTimeout:** The amount of time in seconds after a transactions for which the transaction response is displayed on the terminal.  After the cooldown period elapses, the terminal will revert to the idle state and display the currently active terminal branding.
* **surveyTimeout:** The amount of time in seconds a survey question should be displayed on a terminal before reverting to the idle screen.
* **pinEnabled:** Enables pin code entry for debit cards, EBT cards, and EMV cards with pin CVMs.  Will be ignored if terminals are not injected with the proper encryption keys.
* **pinBypassEnabled:** Enable pin bypass for debit transactions.
* **cashBackEnabled:** Enables cash back for debit transactions.
* **cashbackPresets:** An array of four default values for cashback amounts when cashback is enabled.
* **storeAndForwardEnabled:** Enables automatic store and forward during network outages.  Store and Forward does not support cash back, refunds, EBT, or gift card transactions.
* **storeAndForwardFloorLimit:** Maximum dollar value of a store and forward transaction.
* **ebtEnabled:** Enables EBT (SNAP) on BlockChyp terminals.
* **tipEnabled:** Enables tips entry on the terminal.
* **promptForTip:** If true, the terminal will always prompt for a tip, even if the API call does not request a tip prompt.
* **tipDefaults:** An array of exactly three percentages that will be used to calculate default tip amounts.
* **giftCardsDisabled:** Disables BlockChyp gift cards.  Normally only used if the merchant is using an alternate gift card system.
* **digitalSignaturesEnabled:** Enables electronic signature capture for mag stripe cards and EMV cards with Signature CVMs.
* **digitalSignatureReversal:** Will cause a transaction to auto-reverse if the consumer refuses to provide a signature.
* **manualEntryEnabled:** Enables manual card entry.
* **manualEntryPromptZip:** Requires zip code based address verification for manual card entry.
* **manualEntryPromptStreetNumber:** Requires street/address based verification for manual card entry.

**Card Brand and Transaction Settings**

* **freeRangeRefundsEnabled:** Enables direct refunds that do not reference a previous transaction.
* **partialAuthEnabled:** Indicates that partial authorizations (usually for gift card support) are enabled.
* **splitBankAccountsEnabled:** Used for law firm merchants only.
* **contactlessEmv:** Enables contactless/tap transactions on a terminal.  Defaults to true.
* **visa:** Enables Visa transactions.
* **masterCard:** Enables MasterCard transactions.
* **amex:** Enables American Express transactions.
* **discover:** Enables Discover transactions.
* **jcb:** Enables JCB (Japan Card Bureau) transactions.
* **unionPay:** Enables China UnionPay transactions.




```c#
// Populate request parameters.
MerchantProfileRequest request = new MerchantProfileRequest
{

};

// Run the transaction.
MerchantProfileResponse response = await blockchyp.MerchantProfileAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Get Merchants



* **API Credential Types:** Partner & Organization
* **Required Role:** Merchant Management

This is a partner or organization level API that can be used to return the merchant portfolio.

Live merchants are returned by default.  Use the `test` flag to return only test merchants.  The 
results returned include detailed settings including underwriting controlled flags.

A maximum of 250 merchants are returned by default.  For large merchant portfolios, the `maxResults`
and `startIndex` field can be used to reduce the page size and page through multiple pages of results.




```c#
// Populate request parameters.
GetMerchantsRequest request = new GetMerchantsRequest
{
    Test = true,
};

// Run the transaction.
GetMerchantsResponse response = await blockchyp.GetMerchantsAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Update Merchant



* **API Credential Types:** Merchant, Partner, & Organization
* **Required Role:** Merchant Management

This API can be used to update or create merchant accounts.

Merchant scoped API credentials can be used to update merchant account settings.

Partner scoped API credentials can be used to update merchants, create new test 
merchants or board new gateway merchants.

**Merchant Descriptive Fields**

The following fields are basic descriptive fields that can be used to describe and identify merchants.

* **companyName:** The merchant's official corporate entity name.
* **dbaName:** The businesses DBA (doing business as) name.
* **contactName:** Name of the merchant's primary control contact.
* **contactNumber:** Primary control contact's phone number.
* **locationName:** Optional location name for multi location operators.
* **storeNumber:** Optional store number for multi location operators.
* **partnerRef:** Optional reference number partners can add to a merchant record.  Usually the partner's own identifier for the merchant.
* **timeZone:** Unix style local time zone for the merchant. Example: America/New_York.
* **publicKey:** Read only field.  The merchant's blockchain public key.  Generated and assigned when a merchant account is first created.
* **billingAddress:** Address for billing and written correspondence.
* **shippingAddress:** Physical shipping address. Usually the actual street address of the business.
* **status:** Current status of the merchant account.
* **tcDisabled:** Disables all terms and conditions features in the merchant dashboard.  Used to hide the feature if a partner has not chosen to support it.
* **gatewayOnly:** Indicates that a merchant has been boarded in gateway only mode.  Not common.

**Batch and Terminal Settings**

The following fields are used to control batch closure and high level terminal configuration.

* **batchCloseTime:** Time in 24 hour HH:MM format when batches will automatically close in the merchant's local time.  Defaults to 3 AM.
* **autoBatchClose:** Flag the determines whether or not batches will automatically close.  Defaults to true.
* **disableBatchEmails:** Flag that optionally turns off automatic batch closure notification emails.
* **cooldownTimeout:** The amount of time in seconds after a transactions for which the transaction response is displayed on the terminal.  After the cooldown period elapses, the terminal will revert to the idle state and display the currently active terminal branding.
* **surveyTimeout:** The amount of time in seconds a survey question should be displayed on a terminal before reverting to the idle screen.
* **pinEnabled:** Enables pin code entry for debit cards, EBT cards, and EMV cards with pin CVMs.  Will be ignored if terminals are not injected with the proper encryption keys.
* **pinBypassEnabled:** Enable pin bypass for debit transactions.
* **cashBackEnabled:** Enables cash back for debit transactions.
* **cashbackPresets:** An array of four default values for cashback amounts when cashback is enabled.
* **storeAndForwardEnabled:** Enables automatic store and forward during network outages.  Store and Forward does not support cash back, refunds, EBT, or gift card transactions.
* **storeAndForwardFloorLimit:** Maximum dollar value of a store and forward transaction.
* **ebtEnabled:** Enables EBT (SNAP) on BlockChyp terminals.
* **tipEnabled:** Enables tips entry on the terminal.
* **promptForTip:** If true, the terminal will always prompt for a tip, even if the API call does not request a tip prompt.
* **tipDefaults:** An array of exactly three percentages that will be used to calculate default tip amounts.
* **giftCardsDisabled:** Disables BlockChyp gift cards.  Normally only used if the merchant is using an alternate gift card system.
* **digitalSignaturesEnabled:** Enables electronic signature capture for mag stripe cards and EMV cards with Signature CVMs.
* **digitalSignatureReversal:** Will cause a transaction to auto-reverse if the consumer refuses to provide a signature.
* **manualEntryEnabled:** Enables manual card entry.
* **manualEntryPromptZip:** Requires zip code based address verification for manual card entry.
* **manualEntryPromptStreetNumber:** Requires street/address based verification for manual card entry.

**Card Brand and Transaction Settings**

* **freeRangeRefundsEnabled:** Enables direct refunds that do not reference a previous transaction.
* **partialAuthEnabled:** Indicates that partial authorizations (usually for gift card support) are enabled.
* **splitBankAccountsEnabled:** Used for law firm merchants only.
* **contactlessEmv:** Enables contactless/tap transactions on a terminal.  Defaults to true.
* **visa:** Enables Visa transactions.
* **masterCard:** Enables MasterCard transactions.
* **amex:** Enables American Express transactions.
* **discover:** Enables Discover transactions.
* **jcb:** Enables JCB (Japan Card Bureau) transactions.
* **unionPay:** Enables China UnionPay transactions.




```c#
// Populate request parameters.
MerchantProfile request = new MerchantProfile
{
    MerchantId = "<MERCHANT ID>",
    Test = true,
    DbaName = "Test Merchant",
    CompanyName = "Test Merchant",
    BillingAddress = new Address
    {
        Address1 = "1060 West Addison",
        City = "Chicago",
        StateOrProvince = "IL",
        PostalCode = "60613",
    },
};

// Run the transaction.
MerchantProfileResponse response = await blockchyp.UpdateMerchantAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Merchant Users



* **API Credential Types:** Partner & Organization
* **Required Role:** Merchant Management

This API returns all users and pending invites associated with a merchant account including any assigned role codes.




```c#
// Populate request parameters.
MerchantProfileRequest request = new MerchantProfileRequest
{
    MerchantId = "<MERCHANT ID>",
};

// Run the transaction.
MerchantUsersResponse response = await blockchyp.MerchantUsersAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Invite Merchant User



* **API Credential Types:** Partner & Organization
* **Required Role:** Merchant Management

Invites a new user to join a merchant account.  `email`, `firstName`, and `lastName` are required.

The user will be sent an invite email with steps for creating a BlockChyp account and linking it to
a merchant account.  If the user already has a BlockChyp user account, the new user signup wil be skipped
and the existing user account will be linked to the merchant account.

Developers can optionally restrict the user's access level by sending one or more role codes.
Otherwise, the user will be given the default merchant user role. (STDMERCHANT)




```c#
// Populate request parameters.
InviteMerchantUserRequest request = new InviteMerchantUserRequest
{
    Email = "Email address for the invite",
};

// Run the transaction.
Acknowledgement response = await blockchyp.InviteMerchantUserAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Add Test Merchant



* **API Credential Types:** Partner
* **Required Role:** Merchant Management

This is a partner level API that can be used to create test merchant accounts.  This creates
a basic test merchant with default settings.

Settings can be changed by using the Update Merchant API.




```c#
// Populate request parameters.
AddTestMerchantRequest request = new AddTestMerchantRequest
{
    DbaName = "DBA Name",
    CompanyName = "Corporate Entity Name",
};

// Run the transaction.
MerchantProfileResponse response = await blockchyp.AddTestMerchantAsync(request);

// View the result.
Console.WriteLine(response);

```

#### Delete Test Merchant



* **API Credential Types:** Partner
* **Required Role:** Merchant Management

This partner API can be used to delete unused test merchant accounts. `merchantId` is a required parameter.




```c#
// Populate request parameters.
MerchantProfileRequest request = new MerchantProfileRequest
{
    MerchantId = "<MERCHANT ID>",
};

// Run the transaction.
Acknowledgement response = await blockchyp.DeleteTestMerchantAsync(request);

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
