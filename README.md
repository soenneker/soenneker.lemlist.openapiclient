[![](https://img.shields.io/nuget/v/soenneker.lemlist.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.lemlist.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.openapiclient/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.openapiclient/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.lemlist.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.lemlist.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.lemlist.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.lemlist.openapiclient/actions/workflows/codeql.yml)

# Soenneker.Lemlist.OpenApiClient

A Kiota-generated .NET client for Lemlist's API, including typed request builders, models, query parameters, and API error responses.

## Install

```bash
dotnet add package Soenneker.Lemlist.OpenApiClient
```

## Direct usage

```csharp
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Lemlist.OpenApiClient;

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
    "Basic",
    Convert.ToBase64String(Encoding.UTF8.GetBytes($":{apiKey}")));

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var lemlist = new LemlistOpenApiClient(adapter);

var campaigns = await lemlist.Campaigns.GetAsync(request =>
{
    request.QueryParameters.Limit = 25;
    request.QueryParameters.Page = 1;
}, cancellationToken);
```

Lemlist uses HTTP Basic authentication with an empty username and the API key as the password. Reuse the `HttpClient`, request adapter, and `LemlistOpenApiClient` rather than creating them per request.

API failures are exposed as the generated endpoint-specific error types listed on each request method. Because this package is regenerated from Lemlist's OpenAPI document, generated names and models can change when the upstream specification changes.

For application registration and managed client reuse, use `Soenneker.Lemlist.OpenApiClientUtil` with `Soenneker.Lemlist.HttpClients`.
