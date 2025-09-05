using System.Security.Claims;
using System.Security.Principal;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using Splat;

namespace Avalonia.Auth.MarkupExtensions;

public class HasRoleExtension : MarkupExtension
{
    public string Role { get; set; }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var session = Locator.Current.GetService<Session>()!;

        var binding = session.CreateBinding("Principal");
        binding.Converter = new FuncValueConverter<IPrincipal?, bool>(p => p.IsInRole(Role));
        return binding;
    }
}