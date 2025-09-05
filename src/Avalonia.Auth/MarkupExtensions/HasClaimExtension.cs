using System.Security.Claims;
using Avalonia.Data.Converters;
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

        var binding = session.CreateBinding("Principal");
        binding.Converter = new FuncValueConverter<ClaimsPrincipal?, bool>(p => p.HasClaim(ClaimType, ClaimValue));
        return binding;
    }
}