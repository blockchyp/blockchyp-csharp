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

A basic charge transaction might look like this.

```c#
var request = new AuthorizationRequest
{
    TerminalName = "Terminal",
    Amount = "55.55",
};

var response = await blockchyp.Charge(request);

if (response.Approved)
{
    Console.WriteLine("Approved");
}
else
{
    Console.WriteLine(response.ResponseDescription);
}
```

[blockchyp-docs]: https://docs.blockchyp.com
[blockchyp]: https://www.blockchyp.com
[dotnet-cli]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
