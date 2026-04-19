using Avalonia.Metadata;
using DotNetEnv;
using Splat;

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

#if ANDROID
                var assets = Android.App.Application.Context.Assets;
                using var stream = assets.Open(".env"); // Name wie im AndroidAsset
                DotNetEnv.Env.Load(stream);
#else
#if DEBUG
            var envFile = ".env";
#elif RELEASE
            var envFile = "local.env";
#endif
            Env.TraversePath().Load(envFile);
#endif
        });

        return builder;
    }
}