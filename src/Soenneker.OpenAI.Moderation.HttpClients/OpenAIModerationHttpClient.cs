using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.Configuration;
using Soenneker.OpenAI.Moderation.HttpClients.Abstract;
using Soenneker.OpenAI.Moderation.HttpClients.Constants;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.OpenAI.Moderation.HttpClients;

/// <inheritdoc cref="IOpenAIModerationHttpClient" />
public sealed class OpenAIModerationHttpClient : IOpenAIModerationHttpClient
{
    private const string _cacheKey = nameof(OpenAIModerationHttpClient);
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _configuration;

    public OpenAIModerationHttpClient(IHttpClientCache httpClientCache, IConfiguration configuration)
    {
        _httpClientCache = httpClientCache;
        _configuration = configuration;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        string apiKey = _configuration.GetValueStrict<string>(OpenAIModerationHttpClientDefaults.ApiKeyConfigurationKey);
        string baseUrl = _configuration.GetString("OpenAI:ClientBaseUrl") ?? OpenAIModerationHttpClientDefaults.BaseUrl;
        string authHeaderName = _configuration.GetString("OpenAI:AuthHeaderName") ?? "Authorization";
        string authHeaderTemplate = _configuration.GetString("OpenAI:AuthHeaderValueTemplate") ?? "Bearer {token}";
        string authHeaderValue = authHeaderTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

        return _httpClientCache.Get(_cacheKey, (baseUrl, authHeaderName, authHeaderValue), static state => new HttpClientOptions
        {
            BaseAddress = new Uri(state.baseUrl),
            DefaultRequestHeaders = new Dictionary<string, string>
            {
                [state.authHeaderName] = state.authHeaderValue
            }
        }, cancellationToken);
    }

    public void Dispose()
    {
    }

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }
}
