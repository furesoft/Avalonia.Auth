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
            Authority = "https://issuer.hello.coop/",
            ClientId = "app_7VOU7y3FRsPuO2ALng6YQtYc_sWG",
            Scope = "openid profile name picture github email",
            RedirectUri = redirectUri,
            ClientSecret = "ZWm-UprQfZ-kRl_TIUaQa",
        };
        options.Policy.Discovery.ValidateEndpoints = false;

        var client = new OidcClient(options);

        var state = await client.PrepareLoginAsync();

        Process.Start(new ProcessStartInfo
        {
            FileName = state.StartUrl,
            UseShellExecute = true
        });

        var context = await http.GetContextAsync();

        await WriteToBrowser(context);

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
        Thread.CurrentPrincipal = result.User;
        return true;
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