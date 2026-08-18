using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenAI.Moderation.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.OpenAI.Moderation.HttpClients.Registrars;

/// <summary>
/// An HTTPClient singleton for OpenAI Moderation
/// </summary>
public static class OpenAIModerationHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IOpenAIModerationHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenAIModerationHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton();
        services.TryAddSingleton<IOpenAIModerationHttpClient, OpenAIModerationHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IOpenAIModerationHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenAIModerationHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton();
        services.TryAddScoped<IOpenAIModerationHttpClient, OpenAIModerationHttpClient>();

        return services;
    }
}
