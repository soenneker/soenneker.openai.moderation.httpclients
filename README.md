[![](https://img.shields.io/nuget/v/soenneker.openai.moderation.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.moderation.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openai.moderation.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.openai.moderation.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openai.moderation.httpclients/codeql.yml?label=codeql&style=for-the-badge)](https://github.com/soenneker/soenneker.openai.moderation.httpclients/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.openai.moderation.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.moderation.httpclients/)

# Soenneker.OpenAI.Moderation.HttpClients

Provides a cached `HttpClient` configured for OpenAI moderation requests.

## Install

```bash
dotnet add package Soenneker.OpenAI.Moderation.HttpClients
```

## Registration

```csharp
using Microsoft.Extensions.DependencyInjection;
using Soenneker.OpenAI.Moderation.HttpClients.Registrars;

services.AddOpenAIModerationHttpClientAsSingleton();
```

Use `AddOpenAIModerationHttpClientAsScoped()` when the wrapper must follow a consumer scope. Both registrations reuse the singleton HTTP-client cache; disposing a scoped wrapper does not destroy the shared client.

## Configuration

The API key is required:

```json
{
  "OpenAI": {
    "Moderation": {
      "ApiKey": "..."
    }
  }
}
```

Keep the key in a secret store or environment variable. The client uses `https://api.openai.com/v1` and an `Authorization: Bearer <token>` header by default. Compatible endpoints can be configured with these optional keys:

```json
{
  "OpenAI": {
    "ClientBaseUrl": "https://example.com/v1",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

`{token}` is replaced with `OpenAI:Moderation:ApiKey`.

## Usage

Inject `IOpenAIModerationHttpClient` and retrieve the cached client:

```csharp
using Soenneker.OpenAI.Moderation.HttpClients.Abstract;

HttpClient client = await moderationHttpClient.Get(cancellationToken);

using var request = new HttpRequestMessage(HttpMethod.Get, "models");
using HttpResponseMessage response = await client.SendAsync(request, cancellationToken);

response.EnsureSuccessStatusCode();
```

Do not dispose the returned `HttpClient`; its lifetime is owned by the singleton cache.
