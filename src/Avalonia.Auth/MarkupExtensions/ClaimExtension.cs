using System.Security.Claims;
using Avalonia.Markup.Xaml;

namespace Avalonia.Auth.MarkupExtensions;

public class ClaimExtension : MarkupExtension
{
    public string ClaimType { get; set; }
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
        return principal?.FindFirst(ClaimType)?.Value ?? string.Empty;
    }
}