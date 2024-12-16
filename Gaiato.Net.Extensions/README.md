# Gaiato.Net.Extensions
[![NuGet](https://img.shields.io/nuget/v/Gaiato.Net.Network)](https://www.nuget.org/packages/Gaiato.Net.Network/)
[![Build Status](https://github.com/Gaiato-Net/Gaiato.Net/actions/workflows/publish-nuget.yml/badge.svg)](https://github.com/Gaiato-Net/Gaiato.Net/actions)

## Descri��o

Uma biblioteca de extens�es .NET.

Inclue sanitiza��o segura de strings HTML, oferecendo prote��o contra XSS (Cross-Site Scripting) e outras vulnerabilidades de seguran�a.

## Instala��o

```bash
dotnet add package Gaiato.Net.Extensions
```

## Funcionalidades

- Remo��o de tags HTML perigosas e seu conte�do
- Remo��o de atributos potencialmente maliciosos
- Filtragem de protocolos n�o permitidos
- Remo��o de express�es JavaScript/CSS perigosas
- Codifica��o HTML de caracteres especiais
- Preserva��o opcional de quebras de linha
- Prote��o contra ReDoS (Regex Denial of Service)
- Alta performance com Regex compilados

## Como Usar

### Uso B�sico

```csharp
using Gaiato.Net.Extensions;

string conteudoPerigoso = "<script>alert('xss')</script>Ol�, mundo!";
string conteudoSeguro = conteudoPerigoso.ToSafe();
// Resultado: "Ol�, mundo!"
```

### Preservando Quebras de Linha

```csharp
string textoFormatado = @"Primeira linha
Segunda linha
Terceira linha";

string resultadoComQuebras = textoFormatado.ToSafe(preserveNewLines: true);
// Mant�m as quebras de linha no resultado
```

### Exemplos de Sanitiza��o

```csharp
// Remove tags perigosas
string html = "<iframe src='malicious.com'></iframe><p>Conte�do seguro</p>";
string resultado = html.ToSafe();
// Resultado: "<p>Conte�do seguro</p>"

// Remove atributos maliciosos
html = "<img src='foto.jpg' onerror='alert(1)' />";
resultado = html.ToSafe();
// Remove o atributo onerror

// Remove protocolos n�o permitidos
html = "<a href='javascript:alert(1)'>Link</a>";
resultado = html.ToSafe();
// Remove o protocolo javascript:

// Codifica caracteres especiais
html = "<p>Tags & S�mbolos</p>";
resultado = html.ToSafe();
// Codifica caracteres especiais como &amp;
```

### Tratamento de Valores Nulos ou Vazios

```csharp
string? nulo = null;
string resultado = nulo.ToSafe(); // Retorna string.Empty

string vazia = "";
resultado = vazia.ToSafe(); // Retorna string.Empty

string apenasEspacos = "   ";
resultado = apenasEspacos.ToSafe(); // Retorna string.Empty
```

## Lista de Tags Bloqueadas

- script
- iframe
- object
- embed
- form
- style
- meta
- link
- applet
- frame
- frameset
- html
- body
- head
- base
- template
- svg
- math
- video
- audio

## Lista de Protocolos Permitidos

- http://
- https://
- mailto:
- tel:
- sms:

## Desempenho

A biblioteca utiliza v�rias otimiza��es para garantir o melhor desempenho poss�vel:

- Source Generators para Regex (requer .NET 7+)
- HashSet para busca eficiente de tags e atributos
- Compara��es case-insensitive otimizadas
- Tratamento eficiente de strings

## Seguran�a

A biblioteca implementa v�rias camadas de prote��o:

- Remo��o completa de tags perigosas e seu conte�do
- Sanitiza��o de atributos HTML maliciosos
- Prote��o contra ataques baseados em express�es CSS
- Filtragem de protocolos n�o seguros
- Codifica��o HTML de caracteres especiais
- Tratamento seguro de exce��es
- Prote��o contra ataques ReDoS

## Requisitos

- .NET 7.0 ou superior
- C# 11.0 ou superior

## Licen�a

MIT

## Contribuindo

Contribui��es s�o bem-vindas! Por favor, sinta-se � vontade para submeter pull requests.