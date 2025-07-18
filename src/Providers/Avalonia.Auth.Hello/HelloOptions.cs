namespace Avalonia.Auth.Hello;

public class HelloOptions(string clientId, string clientSecret, string authorizationEndpoint, string tokenEndpoint, string redirectUri) : OAuthOptions(clientId, clientSecret, authorizationEndpoint, tokenEndpoint, redirectUri)
{
}