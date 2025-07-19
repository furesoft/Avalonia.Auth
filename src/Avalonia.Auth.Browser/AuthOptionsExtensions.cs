namespace Avalonia.Auth.Browser;

public static class AuthOptionsExtensions
{
    public static AuthOptions UseBrowserAuth(this AuthOptions options)
    {
        options.UseExternalProviderVerification<BrowserVerification>();
        return options;
    }
}