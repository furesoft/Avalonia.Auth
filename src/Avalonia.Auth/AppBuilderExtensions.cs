using Splat;

namespace Avalonia.Auth;

public static class LoginAppBuilderExtensions
{
    public static AppBuilder UseAuthProvider<TProvider, TOptions>(this AppBuilder builder, Action<TOptions> configureOptions)
        where TProvider : AuthProvider
        where TOptions : class, new()
    {
        builder.AfterSetup(_ =>
        {
            Locator.CurrentMutable.RegisterLazySingleton(() =>
            {
                var provider = Activator.CreateInstance<TProvider>();
                return provider;
            }, typeof(TProvider));

            var options = new TOptions();
            configureOptions(options);
            Locator.CurrentMutable.RegisterLazySingleton(() =>
            {
                var provider = Activator.CreateInstance<TOptions>();
                return provider;
            }, typeof(TOptions));
        });

        return builder;
    }

    public static AppBuilder UseAuthProvider<TProvider>(this AppBuilder builder)
        where TProvider : AuthProvider
    {
        builder.AfterSetup(_ =>
        {
            Locator.CurrentMutable.RegisterLazySingleton(() =>
            {
                var provider = Activator.CreateInstance<TProvider>();
                return provider;
            }, typeof(AuthProvider));
        });

        return builder;
    }

    public static AppBuilder ConfigureAuth(this AppBuilder builder, Action<AuthOptions> configureOptions)
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