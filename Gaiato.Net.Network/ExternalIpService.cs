namespace Gaiato.Net.Network;

public class ExternalIpService : IExternalIpService
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Inicializa uma nova instância de <see cref="ExternalIpService"/>.
    /// </summary>
    /// <param name="httpClient">Instância do <see cref="HttpClient"/> injetada para realizar requisições.</param>
    public ExternalIpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc />
    public async Task<string> GetExternalIpAsync()
    {
        const string apiUrl = "https://api.ipify.org";
        var response = await _httpClient.GetStringAsync(apiUrl);
        return response;
    }
}
