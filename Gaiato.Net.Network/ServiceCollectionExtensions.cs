using Microsoft.Extensions.DependencyInjection;

namespace Gaiato.Net.Network;
/// <summary>
/// Extensões para registrar o serviço de IP externo.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adiciona o serviço de IP externo ao contêiner de dependências.
    /// </summary>
    /// <param name="services">Coleção de serviços do contêiner.</param>
    /// <returns>A coleção de serviços atualizada.</returns>
    public static IServiceCollection AddExternalIpService(this IServiceCollection services)
    {
        services.AddHttpClient<IExternalIpService, ExternalIpService>();
        return services;
    }
}
