using System.Security.Claims;
using Avalonia.Markup.Xaml;
using Splat;

namespace Avalonia.Auth.MarkupExtensions;

public class ClaimExtension : MarkupExtension
{
    public string ClaimType { get; set; }
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var session = Locator.Current.GetService<Session>()!;

        return session.CreateBinding($"Principal.Claims[{ClaimType}]");
    }
}