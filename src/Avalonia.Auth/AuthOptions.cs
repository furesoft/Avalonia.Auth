using Splat;

namespace Avalonia.Auth;

public class AuthOptions
{
    internal readonly List<AuthProvider> Providers = [];

    public string? Title { get; set; }
    internal bool EnableUsernamePassword => CredentialProvider != null;
    public bool ShowForgotPasswordLink { get; set; } = true;
    public bool ShowRegisterLink { get; set; } = true;

    public ICredentialsProvider? CredentialProvider { get; private set; }
    public IExternalProviderVerification? ExternalProviderVerification { get; private set; }

    public AuthOptions AddProvider<TProvider, TOptions>(
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

    public AuthOptions AddProvider<TProvider>()
        where TProvider : AuthProvider, new()
    {
        Providers.Add(new TProvider());

        return this;
    }

    public AuthOptions UseCredentialProvider<TProvider>()
        where TProvider : ICredentialsProvider, new()
    {
        CredentialProvider = new TProvider();
        return this;
    }

    public AuthOptions UseCredentialProvider<TProvider>(Action<TProvider> configurer)
        where TProvider : ICredentialsProvider, new()
    {
        CredentialProvider = new TProvider();
        configurer((TProvider)CredentialProvider);

        return this;
    }

    public AuthOptions UseExternalProviderVerification<TVerification>()
        where TVerification : IExternalProviderVerification, new()
    {
        ExternalProviderVerification = new TVerification();
        return this;
    }
}