using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.OpenAI.Moderation.HttpClients.Abstract;

/// <summary>
/// Provides the shared HTTP client configured for OpenAI moderation requests.
/// </summary>
public interface IOpenAIModerationHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached HTTP client configured for OpenAI moderation.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The cached HTTP client. The caller must not dispose it.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
