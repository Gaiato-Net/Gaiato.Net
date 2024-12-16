# Gaiato.Net.Extensions
[![NuGet](https://img.shields.io/nuget/v/Gaiato.Net.Network)](https://www.nuget.org/packages/Gaiato.Net.Network/)
[![Build Status](https://github.com/Gaiato-Net/Gaiato.Net/actions/workflows/publish-nuget.yml/badge.svg)](https://github.com/Gaiato-Net/Gaiato.Net/actions)

## Descrição

Uma biblioteca de extensões .NET.

Inclue sanitização segura de strings HTML, oferecendo proteção contra XSS (Cross-Site Scripting) e outras vulnerabilidades de segurança.

## Instalação

```bash
dotnet add package Gaiato.Net.Extensions
```

## Funcionalidades

- Remoção de tags HTML perigosas e seu conteúdo
- Remoção de atributos potencialmente maliciosos
- Filtragem de protocolos não permitidos
- Remoção de expressões JavaScript/CSS perigosas
- Codificação HTML de caracteres especiais
- Preservação opcional de quebras de linha
- Proteção contra ReDoS (Regex Denial of Service)
- Alta performance com Regex compilados

## Como Usar

### Uso Básico

```csharp
using Gaiato.Net.Extensions;

string conteudoPerigoso = "<script>alert('xss')</script>Olá, mundo!";
string conteudoSeguro = conteudoPerigoso.ToSafe();
// Resultado: "Olá, mundo!"
```

### Preservando Quebras de Linha

```csharp
string textoFormatado = @"Primeira linha
Segunda linha
Terceira linha";

string resultadoComQuebras = textoFormatado.ToSafe(preserveNewLines: true);
// Mantém as quebras de linha no resultado
```

### Exemplos de Sanitização

```csharp
// Remove tags perigosas
string html = "<iframe src='malicious.com'></iframe><p>Conteúdo seguro</p>";
string resultado = html.ToSafe();
// Resultado: "<p>Conteúdo seguro</p>"

// Remove atributos maliciosos
html = "<img src='foto.jpg' onerror='alert(1)' />";
resultado = html.ToSafe();
// Remove o atributo onerror

// Remove protocolos não permitidos
html = "<a href='javascript:alert(1)'>Link</a>";
resultado = html.ToSafe();
// Remove o protocolo javascript:

// Codifica caracteres especiais
html = "<p>Tags & Símbolos</p>";
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

A biblioteca utiliza várias otimizações para garantir o melhor desempenho possível:

- Source Generators para Regex (requer .NET 7+)
- HashSet para busca eficiente de tags e atributos
- Comparações case-insensitive otimizadas
- Tratamento eficiente de strings

## Segurança

A biblioteca implementa várias camadas de proteção:

- Remoção completa de tags perigosas e seu conteúdo
- Sanitização de atributos HTML maliciosos
- Proteção contra ataques baseados em expressões CSS
- Filtragem de protocolos não seguros
- Codificação HTML de caracteres especiais
- Tratamento seguro de exceções
- Proteção contra ataques ReDoS

## Requisitos

- .NET 7.0 ou superior
- C# 11.0 ou superior

## Licença

MIT

## Contribuindo

Contribuições são bem-vindas! Por favor, sinta-se à vontade para submeter pull requests.