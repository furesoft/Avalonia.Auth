using Duende.IdentityModel.Client;

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
        var client = new HttpClient();

        var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = $"https://{Domain}/oauth/token",

            ClientId = ClientId,
            Scope = "openid profile email",
            GrantType = "password",
            UserName = username,
            Password = password
        });

        var userinfo = await client.GetUserInfoAsync(new UserInfoRequest()
        {
            Token = response.AccessToken,
            Address = $"https://{Domain}/oauth/userinfo"
        });

        return !response.IsError;
    }
}