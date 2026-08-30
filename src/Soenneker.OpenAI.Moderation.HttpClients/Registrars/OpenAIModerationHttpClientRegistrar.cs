using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenAI.Moderation.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.OpenAI.Moderation.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAI moderation HTTP-client provider and its shared cache.
/// </summary>
public static class OpenAIModerationHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IOpenAIModerationHttpClient"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddOpenAIModerationHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton();
        services.TryAddSingleton<IOpenAIModerationHttpClient, OpenAIModerationHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IOpenAIModerationHttpClient"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddOpenAIModerationHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton();
        services.TryAddScoped<IOpenAIModerationHttpClient, OpenAIModerationHttpClient>();

        return services;
    }
}
