using System.Security.Claims;
using Avalonia.Markup.Xaml;
using Splat;

namespace Avalonia.Auth.MarkupExtensions;

public class HasRoleExtension : MarkupExtension
{
    public string Role { get; set; }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var session = Locator.Current.GetService<Session>()!;
        var principal = Thread.CurrentPrincipal as ClaimsPrincipal;

        return principal?.IsInRole(Role) ?? false;
    }
}