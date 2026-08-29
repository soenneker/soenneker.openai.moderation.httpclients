[![](https://img.shields.io/nuget/v/soenneker.openai.moderation.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.moderation.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openai.moderation.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.openai.moderation.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.openai.moderation.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openai.moderation.httpclients/)

# Soenneker.OpenAI.Moderation.HttpClients

An HTTPClient singleton for OpenAI Moderation.

## Install

```bash
dotnet add package Soenneker.OpenAI.Moderation.HttpClients
```

## Quick start

```csharp
using Soenneker.OpenAI.Moderation.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddOpenAIModerationHttpClientAsSingleton();
```

Adds `IOpenAIModerationHttpClient` as a singleton service.

## What you get

- `IOpenAIModerationHttpClient` — An HTTPClient singleton for OpenAI Moderation.
- `OpenAIModerationHttpClientDefaults` — Configuration keys and defaults for the OpenAI moderation HTTP client.
- `OpenAIModerationHttpClientRegistrar` — An HTTPClient singleton for OpenAI Moderation.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IOpenAIModerationHttpClient.Get(cancellationToken)` | Gets the cached HTTP client configured for OpenAI moderation. | A task whose result is the requested http Client. |
| `OpenAIModerationHttpClientRegistrar.AddOpenAIModerationHttpClientAsSingleton(services)` | Adds `IOpenAIModerationHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `OpenAIModerationHttpClientRegistrar.AddOpenAIModerationHttpClientAsScoped(services)` | Adds `IOpenAIModerationHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
