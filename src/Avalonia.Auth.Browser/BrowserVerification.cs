using System.Diagnostics;
using System.Net;
using System.Text;
using Duende.IdentityModel.OidcClient;

namespace Avalonia.Auth.Browser;

public class BrowserVerification : IExternalProviderVerification
{
    public async Task<bool> Open(string url)
    {
        var redirectUri = "http://127.0.0.1:7890/";
        var http = new HttpListener();
        http.Prefixes.Add(redirectUri);
        Console.WriteLine("Listening..");
        http.Start();

        var options = new OidcClientOptions
        {
            Authority = "https://demo.duendesoftware.com",
            ClientId = "interactive.public",
            Scope = "openid profile api",
            RedirectUri = redirectUri
        };

        var client = new OidcClient(options);
        var state = await client.PrepareLoginAsync();

        Console.WriteLine($"Start URL: {state.StartUrl}");

        Process.Start(new ProcessStartInfo
        {
            FileName = state.StartUrl,
            UseShellExecute = true
        });

        // wait for the authorization response.
        var context = await http.GetContextAsync();

        // sends an HTTP response to the browser.
        var response = context.Response;
        var responseString =
            "<html><head><meta http-equiv='refresh' content='10;url=https://demo.duendesoftware.com'></head><body>Please return to the app.</body></html>";
        var buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        var responseOutput = response.OutputStream;
        await responseOutput.WriteAsync(buffer, 0, buffer.Length);
        responseOutput.Close();

        var result = await client.ProcessResponseAsync(context.Request.RawUrl, state);

        if (result.IsError)
        {
            Console.WriteLine("\n\nError:\n{0}", result.Error);
        }
        else
        {
            Console.WriteLine("\n\nClaims:");
            foreach (var claim in result.User.Claims) Console.WriteLine("{0}: {1}", claim.Type, claim.Value);

            Console.WriteLine();
            Console.WriteLine("Access token:\n{0}", result.AccessToken);

            if (!string.IsNullOrWhiteSpace(result.RefreshToken))
                Console.WriteLine("Refresh token:\n{0}", result.RefreshToken);
        }

        http.Stop();
        return true;
    }
}