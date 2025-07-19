using Splat;

namespace Avalonia.Auth;

public class OAuthProvider()
    : AuthProvider
{
    public override Task<bool> Authenticate()
    {
        return Locator.Current.GetService<AuthOptions>().ExternalProviderVerification.Open("");
    }
}
public class OAuthOptions(
    string clientId,
    string clientSecret,
    string authorizationEndpoint,
    string tokenEndpoint,
    string redirectUri)
{
    public string? ClientId { get; set; } = clientId;
    public string? ClientSecret { get; set; } = clientSecret;
    public string? AuthorizationEndpoint { get; set; } = authorizationEndpoint;
    public string? TokenEndpoint { get; set; } = tokenEndpoint;
    public string? RedirectUri { get; set; } = redirectUri;
}