using Avalonia.Markup.Xaml;
using Splat;

namespace Avalonia.Auth.MarkupExtensions;

public class PrincipalNameExtension : MarkupExtension
{
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var session = Locator.Current.GetService<Session>()!;
        return session.CreateBinding("Principal.Identity.Name");
    }
}