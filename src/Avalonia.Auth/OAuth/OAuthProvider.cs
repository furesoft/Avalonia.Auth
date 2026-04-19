using Splat;

namespace Avalonia.Auth.OAuth;

public abstract class OAuthProvider<TOptions> : AuthProvider
    where TOptions : OAuthOptions, new()
{
    public sealed override Task<bool> Authenticate()
    {
        var options = GetOptions<TOptions>();
        return Locator.Current.GetService<AuthOptions>()?.ExternalProviderVerification.Open(options)!;
    }
}