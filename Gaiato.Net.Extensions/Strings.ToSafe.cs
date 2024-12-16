using System.Text.RegularExpressions;
using System.Web;

namespace Gaiato.Net.Extensions;

public static partial class Strings
{
    private static readonly HashSet<string> BlackListTags = new(StringComparer.OrdinalIgnoreCase)
    {
        "script", "iframe", "object", "embed", "form", "style", "meta", "link",
        "applet", "frame", "frameset", "html", "body", "head", "base", "template",
        "svg", "math", "video", "audio"
    };

    private static readonly HashSet<string> BlackListAttributes = new(StringComparer.OrdinalIgnoreCase)
    {
        "onload", "onclick", "onerror", "onmouseover", "onmouseout", "onmouseenter",
        "onmouseleave", "onkeydown", "onkeyup", "onkeypress", "href", "src",
        "formaction", "rel", "data", "action", "onsubmit", "onfocus", "onblur",
        "onchange", "onselect", "onreset", "onabort", "ondblclick", "ondrag",
        "xlink:href", "xmlns", "data-*"
    };

    private static readonly HashSet<string> AllowedProtocols = new(StringComparer.OrdinalIgnoreCase)
    {
        "http://", "https://", "mailto:", "tel:", "sms:"
    };

    [GeneratedRegex(@"<!--.*?-->", RegexOptions.Singleline)]
    private static partial Regex CommentsRegex();

    [GeneratedRegex(@"expression\s*\(.*?\)|javascript:|vbscript:|livescript:|data:",
        RegexOptions.IgnoreCase | RegexOptions.Singleline)]
    private static partial Regex DangerousExpressionsRegex();

    public static string ToSafe(this string? input, bool preserveNewLines = false)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Pré-processamento para preservar quebras de linha se necessário
            if (preserveNewLines)
            {
                input = input.Replace("\n", "[[NEWLINE]]")
                            .Replace("\r", string.Empty);
            }

            // Remove comentários HTML usando Regex gerado em tempo de compilação
            input = CommentsRegex().Replace(input, string.Empty);

            // Remove tags na blacklist com seus conteúdos
            foreach (var tag in BlackListTags)
            {
                var pattern = $@"<{tag}[^>]*>.*?</{tag}>";
                input = Regex.Replace(input, pattern, string.Empty,
                    RegexOptions.IgnoreCase | RegexOptions.Singleline);

                // Remove também tags de fechamento órfãs
                input = Regex.Replace(input, $@"</{tag}>", string.Empty,
                    RegexOptions.IgnoreCase);
            }

            // Remove tags individuais na blacklist
            var combinedTags = string.Join("|", BlackListTags);
            input = Regex.Replace(input, $@"<(?:{combinedTags})\s*[^>]*>",
                string.Empty, RegexOptions.IgnoreCase);

            // Remove atributos maliciosos
            foreach (var attr in BlackListAttributes)
            {
                input = Regex.Replace(input,
                    $@"(?:<[^>]*)\s+{attr}\s*=\s*(['""]?).*?\1(?:[^>]*>)",
                    match => match.Value.Replace(match.Groups[0].Value, string.Empty),
                    RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }

            // Remove protocolos não permitidos
            var allowedProtocolsPattern = string.Join("|", AllowedProtocols);
            input = Regex.Replace(input,
                $@"(?:href|src|data)\s*=\s*(['""])((?!(?:{allowedProtocolsPattern})).*?)\1",
                string.Empty,
                RegexOptions.IgnoreCase);

            // Remove expressões perigosas usando Regex gerado em tempo de compilação
            input = DangerousExpressionsRegex().Replace(input, string.Empty);

            // Encode caracteres especiais HTML
            var sanitized = HttpUtility.HtmlEncode(input);

            // Pós-processamento para restaurar quebras de linha se necessário
            if (preserveNewLines)
            {
                sanitized = sanitized.Replace("[[NEWLINE]]", Environment.NewLine);
            }

            return sanitized;
        }
        catch (RegexMatchTimeoutException)
        {
            // Timeout específico de regex - retorna string vazia por segurança
            return string.Empty;
        }
        catch
        {
            // Qualquer outra exceção - retorna string vazia
            return string.Empty;
        }
    }
}