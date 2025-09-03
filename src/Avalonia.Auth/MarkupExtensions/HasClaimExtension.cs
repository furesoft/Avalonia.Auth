using System.Security.Claims;
using Avalonia.Markup.Xaml;
using Splat;

namespace Avalonia.Auth.MarkupExtensions;

public class HasClaimExtension : MarkupExtension
{
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var session = Locator.Current.GetService<Session>()!;

        var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
        return principal?.HasClaim(ClaimType, ClaimValue) ?? false;
    }
}