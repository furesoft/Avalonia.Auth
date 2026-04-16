using Avalonia.Auth.OAuth;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Duende.IdentityModel.OidcClient;
using Splat;

namespace Avalonia.Auth;

internal class BrowserVerification
{
    public async Task<bool> Open(OAuthOptions options)
    {
        var redirectUri = options.UseHostUriRedirectUrl ? "http://localhost:7890/" : "http://127.0.0.1:7890/";

        options.RedirectUri ??= redirectUri;
        options.Policy.Discovery.ValidateEndpoints = false;

        var client = new OidcClient(options);
        var state = await client.PrepareLoginAsync();

        var lifetime = Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
        var authOptions = new WebAuthenticatorOptions(
            RequestUri: new Uri(state.StartUrl),
            RedirectUri: new Uri(redirectUri));

        var rawUrl = await WebAuthenticationBroker.AuthenticateAsync(
            lifetime!.MainWindow!,
            authOptions);

        var result = await client.ProcessResponseAsync(rawUrl.CallbackUri.ToString(), state);

        if (result.IsError)
        {
            Console.WriteLine("\n\nError:\n{0}", result.Error);
            return false;
        }

        var session = Locator.Current.GetService<Session>()!;
        session.Principal = result.User;

        return true;
    }
}
