# Gaiato.Net.Network

[![NuGet](https://img.shields.io/nuget/v/Gaiato.Net.Network)](https://www.nuget.org/packages/Gaiato.Net.Network/)
[![Build Status](https://github.com/Gaiato-Net/Gaiato.Net/actions/workflows/publish-nuget.yml/badge.svg)](https://github.com/Gaiato-Net/Gaiato.Net/actions)

## Descrição

**Gaiato.Net.Network** é um pacote NuGet que fornece uma maneira simples e eficiente de consultar APIS públicas como por exemplo, para obter o endereço IP externo de uma máquina utilizando o `ipify`.

O pacote foi desenvolvido seguindo os princípios de **Clean Code** e **SOLID**, garantindo flexibilidade, testabilidade e manutenibilidade. É compatível com projetos .NET 7 ou superior.

## Recursos

- Obtenção do endereço IP externo com apenas uma chamada assíncrona.
- Integração fácil com `HttpClient` e injeção de dependência.
- Testado e validado com testes unitários.
- Código otimizado para performance e confiabilidade.

## Instalação

Para instalar o pacote, utilize o seguinte comando no terminal:

```bash
dotnet add package Gaiato.Net.Network
```

Ou adicione diretamente via o **Gerenciador de Pacotes NuGet** do Visual Studio, buscando por `Gaiato.Net.Network`.

## Uso

### Configuração no Startup ou Program.cs

Adicione o serviço ao contêiner de injeção de dependência utilizando o método de extensão incluído:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Gaiato.Net.Network;

var services = new ServiceCollection();
services.AddExternalIpService();

var serviceProvider = services.BuildServiceProvider();
var ipService = serviceProvider.GetRequiredService<IExternalIpService>();

var externalIp = await ipService.GetExternalIpAsync();
Console.WriteLine($"Seu IP externo é: {externalIp}");
```

### Injeção em Serviços

Você também pode injetar o serviço diretamente em suas classes:

```csharp
public class MyService
{
    private readonly IExternalIpService _externalIpService;

    public MyService(IExternalIpService externalIpService)
    {
        _externalIpService = externalIpService;
    }

    public async Task LogExternalIpAsync()
    {
        var ip = await _externalIpService.GetExternalIpAsync();
        Console.WriteLine($"Endereço IP externo: {ip}");
    }
}
```

## Estrutura do Projeto

```plaintext
├── Gaiato.Net.Network/
│   ├── Gaiato.Net.Network.csproj
│   ├── ExternalIpService.cs
│   ├── IExternalIpService.cs
│   ├── ServiceCollectionExtensions.cs
├── .github/
│   └── workflows/
│       └── publish-nuget.yml
├── README.md
```

## Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para ajudar com:

- Reportar problemas ou sugerir melhorias na aba **Issues**.
- Fazer um fork do repositório e enviar **pull requests**.
- Melhorar a documentação ou adicionar novos testes.

### Passo a Passo para Contribuir

1. Faça um fork do repositório.
2. Crie uma nova branch para sua funcionalidade ou correção:
   ```bash
   git checkout -b minha-nova-funcionalidade
   ```
3. Faça suas alterações e commit:
   ```bash
   git commit -m "Adicionei minha nova funcionalidade"
   ```
4. Envie para sua branch:
   ```bash
   git push origin minha-nova-funcionalidade
   ```
5. Abra um **pull request** no GitHub.

## Licença

Este projeto está licenciado sob a licença **MIT**. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.

## Referências

- [ipify API](https://www.ipify.org)
- [NuGet.org](https://www.nuget.org)

---

### Status do Build

O processo de publicação é automatizado utilizando [GitHub Actions](https://github.com/seu-usuario/seu-repositorio/actions). Ao enviar um commit para a branch `main` ou criar uma tag no formato `v1.0.0`, o pacote será automaticamente publicado no [NuGet](https://www.nuget.org/packages/Gaiato.Net.Network/).


### Projeto Gaiato.Net
- [Site](https://gaiato.net)
- [YouTube](https://www.youtube.com/@gaiatonet)
- [X (Twitter)](https://twitter.com/gaiatonet)
- [Linkedin](https://www.linkedin.com/company/101314141)
- [Discord](https://discord.com/channels/1181618892985073745/1181618893689724980)
### #SejaGaiato

