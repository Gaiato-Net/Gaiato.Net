namespace Gaiato.Net.Network;

/// <summary>
/// Define as operações para obtenção do endereço IP externo.
/// </summary>
public interface IExternalIpService
{
    /// <summary>
    /// Obtém o endereço IP externo.
    /// </summary>
    /// <returns>Uma string contendo o endereço IP externo.</returns>
    Task<string> GetExternalIpAsync();
}
