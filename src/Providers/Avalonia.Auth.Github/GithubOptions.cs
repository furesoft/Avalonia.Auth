namespace Avalonia.Auth.Github;

public class GithubOptions(string clientId, string clientSecret, string authorizationEndpoint, string tokenEndpoint, string redirectUri) : OAuthOptions(clientId, clientSecret, authorizationEndpoint, tokenEndpoint, redirectUri)
{
}