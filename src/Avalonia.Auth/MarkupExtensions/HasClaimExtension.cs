using System.Security.Claims;
using Avalonia.Markup.Xaml;

namespace Avalonia.Auth.MarkupExtensions;

public class HasClaimExtension : MarkupExtension
{
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
        return principal?.HasClaim(ClaimType, ClaimValue) ?? false;
    }
}