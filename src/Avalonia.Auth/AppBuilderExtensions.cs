using Splat;

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
        });

        return builder;
    }
}