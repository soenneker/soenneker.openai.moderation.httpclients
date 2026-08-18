using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.OpenAI.Moderation.HttpClients.Abstract;

/// <summary>
/// An HTTPClient singleton for OpenAI Moderation
/// </summary>
public interface IOpenAIModerationHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached HTTP client configured for OpenAI moderation.
    /// </summary>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
