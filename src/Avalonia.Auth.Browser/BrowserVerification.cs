using System.Diagnostics;
using System.Net;
using System.Text;
using Avalonia.Auth.OAuth;
using Duende.IdentityModel.OidcClient;

namespace Avalonia.Auth.Browser;

public class BrowserVerification : IExternalProviderVerification
{
    public async Task<bool> Open(OAuthOptions options)
    {
        string redirectUri;
        if (options.UseHostUriRedirectUrl)
        {
            redirectUri = "http://localhost:7890/";
        }
        else
        {
            redirectUri = "http://127.0.0.1:7890/";
        }

        var http = new HttpListener();
        http.Prefixes.Add(redirectUri);
        http.Start();

        options.Policy.Discovery.ValidateEndpoints = false;
        options.RedirectUri = redirectUri;

        try
        {
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
                return false;
            }

            Thread.CurrentPrincipal = result.User;
        }
        finally
        {
            http.Stop();
        }

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