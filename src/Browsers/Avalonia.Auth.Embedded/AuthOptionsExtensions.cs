namespace Avalonia.Auth.Embedded;

public static class AuthOptionsExtensions
{
    public static AuthOptions UseEmbeddedAuth(this AuthOptions options)
    {
        options.UseExternalProviderVerification<BrowserVerification>();
        return options;
    }
}