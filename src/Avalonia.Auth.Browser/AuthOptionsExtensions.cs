namespace Avalonia.Auth.Browser;

public static class AuthOptionsExtensions
{
    public static AuthOptions UseBrowserAuth(this AuthOptions options, Action<BrowserVerification>? configurer = null)
    {
        options.UseExternalProviderVerification<BrowserVerification>();

        if (configurer != null)
        {
            configurer((BrowserVerification)options.ExternalProviderVerification!);
        }

        return options;
    }
}