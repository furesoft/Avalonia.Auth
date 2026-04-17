using Avalonia.Auth.OAuth;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Duende.IdentityModel.OidcClient;
using Splat;

namespace Avalonia.Auth;

internal class BrowserVerification
{
    private TopLevel GetTopLevel()
    {
        if (Application.Current!.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            return  desktop.MainWindow!;
        }
        else if (Application.Current.ApplicationLifetime is ISingleViewApplicationLifetime singleView)
        {
            return TopLevel.GetTopLevel(singleView.MainView)!;
        }

        throw new InvalidOperationException("Unsupported application lifetime");
    }
    public async Task<bool> Open(OAuthOptions options)
    {
        var redirectUri = options.UseHostUriRedirectUrl ? "https://localhost/" : "https://127.0.0.1/";

        options.RedirectUri ??= redirectUri;
        options.Policy.Discovery.ValidateEndpoints = false;

        var client = new OidcClient(options);
        var state = await client.PrepareLoginAsync();

        var topLevelView = GetTopLevel();
        var authOptions = new WebAuthenticatorOptions(
            RequestUri: new Uri(state.StartUrl),
            RedirectUri: new Uri(options.RedirectUri));

        var rawUrl = await WebAuthenticationBroker.AuthenticateAsync(topLevelView, authOptions);

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
