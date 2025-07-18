namespace Avalonia.Auth.Google;

public class GoogleOptions(string clientId, string clientSecret, string authorizationEndpoint, string tokenEndpoint, string redirectUri) : OAuthOptions(clientId, clientSecret, authorizationEndpoint, tokenEndpoint, redirectUri)
{
}