using Splat;

namespace Avalonia.Auth;

public class AuthOptions
{
    internal readonly List<AuthProvider> Providers = [];

    public string Title { get; set; } = "Login";
    public bool EnableUsernamePassword { get; set; } = true;
    public bool ShowForgotPasswordLink { get; set; } = true;
    public bool ShowRegisterLink { get; set; } = true;
    public bool MinimalMode { get; set; }

    public AuthOptions UseAuthProvider<TProvider, TOptions>(
        Action<TOptions> configureOptions)
        where TProvider : AuthProvider, new()
        where TOptions : class, new()
    {
        Providers.Add(new TProvider());
        var options = new TOptions();
        configureOptions(options);
        Locator.CurrentMutable.RegisterLazySingleton(() =>
        {
            var provider = Activator.CreateInstance<TOptions>();
            return provider;
        }, typeof(TOptions));

        return this;
    }

    public AuthOptions UseAuthProvider<TProvider>()
        where TProvider : AuthProvider, new()
    {
        Providers.Add(new TProvider());

        return this;
    }
}