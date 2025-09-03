using System.Net;
using System.Text;
using Avalonia.Auth.OAuth;
using Avalonia.Controls;
using Duende.IdentityModel.OidcClient;
using Splat;

namespace Avalonia.Auth.Embedded;

public class BrowserVerification : IExternalProviderVerification
{
    public async Task<bool> Open(OAuthOptions options)
    {
        string redirectUri;
        if (options.UseHostUriRedirectUrl)
            redirectUri = "http://localhost:7890/";
        else
            redirectUri = "http://127.0.0.1:7890/";

        options.Policy.Discovery.ValidateEndpoints = false;
        options.RedirectUri ??= redirectUri;


        var client = new OidcClient(options);

        var state = await client.PrepareLoginAsync();
        var rawUrl = await OpenBrowser(options, state.StartUrl);
        var result = await client.ProcessResponseAsync(rawUrl, state);

        if (result.IsError)
        {
            Console.WriteLine("\n\nError:\n{0}", result.Error);
            return false;
        }

        var session = Locator.Current.GetService<Session>()!;
        session.Principal = result.User;

        return true;
    }

    private Task<string> OpenBrowser(OidcClientOptions options, string url)
    {
        var browser = new AvaloniaWebView.WebView();
        var window = new Window
        {
            Name = "Login",
            Title = "Login",
            WindowStartupLocation = WindowStartupLocation.CenterScreen
        };
        var tcs = new TaskCompletionSource<string>();

        browser.NavigationStarting += (_, arg) =>
        {
            // reached the end of the signin process
            if (arg.Url?.AbsoluteUri.StartsWith(options.RedirectUri) is true)
            {
                tcs.SetResult(arg.Url.ToString());
                window.Close();
            }
        };

        window.Content = browser;
        browser.Url = new Uri(url);

        window.Show();
        return tcs.Task;
    }

    private static async Task WriteToBrowser(HttpListenerContext context)
    {
        var response = context.Response;
        var responseString =
            "<html><body>Please return to the app.</body></html>";
        var buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        var responseOutput = response.OutputStream;
        await responseOutput.WriteAsync(buffer, 0, buffer.Length);
        responseOutput.Close();
    }
}