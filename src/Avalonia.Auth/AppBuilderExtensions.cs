using Splat;
using Avalonia.Metadata;

[assembly: XmlnsDefinition("http://furesoft.de/schemas/auth", "Avalonia.Auth.Controls")]
[assembly: XmlnsDefinition("http://furesoft.de/schemas/auth", "Avalonia.Auth.MarkupExtensions")]

namespace Avalonia.Auth;

public static class LoginAppBuilderExtensions
{

    public static AppBuilder WithAuth(this AppBuilder builder, Action<AuthOptions> configureOptions)
    {
        builder.AfterSetup(_ =>
        {
            var options = new AuthOptions();
            configureOptions(options);
            Locator.CurrentMutable.RegisterConstant(options);

            Locator.CurrentMutable.RegisterConstant(new Session());
        });

        return builder;
    }
}
