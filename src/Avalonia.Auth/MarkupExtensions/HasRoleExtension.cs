using System.Security.Claims;
using Avalonia.Markup.Xaml;

namespace Avalonia.Auth.MarkupExtensions;

public class HasRoleExtension : MarkupExtension
{
    public string Role { get; set; }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var principal = Thread.CurrentPrincipal as ClaimsPrincipal;

        return principal?.IsInRole(Role) ?? false;
    }
}