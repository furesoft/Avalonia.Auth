using System.Security.Claims;
using Avalonia.Markup.Xaml;

namespace Avalonia.Auth.MarkupExtensions;

public class PrincipalNameExtension : MarkupExtension
{
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
        return principal?.Identity?.Name ?? string.Empty;
    }
}