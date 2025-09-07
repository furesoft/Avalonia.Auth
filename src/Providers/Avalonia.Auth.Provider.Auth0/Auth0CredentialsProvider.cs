using System.Text;
using System.Text.Json;

namespace Avalonia.Auth.Provider.Auth0;

/*
 * test@test.com
 * ufgg9vh$TvzP
 */
//ToDo: fix
public class Auth0CredentialsProvider : ICredentialsProvider
{
    private readonly HttpClient _httpClient = new();
    public string Domain { get; set; }
    public string ClientId { get; set; }

    public async Task<bool> AuthenticateAsync(string username, string password)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://{Domain}/oauth/token");
        var body = new
        {
            grant_type = "password",
            username,
            password,
            audience = $"https://{Domain}/api/v2/",
            client_id = ClientId,
            scope = "openid profile email"
        };
        var json = JsonSerializer.Serialize(body);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            return false;

        var responseContent = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(responseContent);

        //todo: store the token in Session
        return doc.RootElement.TryGetProperty("access_token", out _);
    }
}