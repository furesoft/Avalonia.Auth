namespace Avalonia.Auth;

public class OAuthProvider(
    string name,
    string clientId,
    string clientSecret,
    string authorizationEndpoint,
    string tokenEndpoint,
    string redirectUri)
    : IAuthProvider
{
    public virtual string Name { get; } = name;
    protected readonly string ClientId = clientId;
    protected readonly string ClientSecret = clientSecret;
    protected readonly string AuthorizationEndpoint = authorizationEndpoint;
    protected readonly string TokenEndpoint = tokenEndpoint;
    protected readonly string RedirectUri = redirectUri;

    public virtual void Authenticate()
    {
        // Generischer OAuth2-Flow (z.B. Öffnen des Browsers mit Auth-URL)
        // Diese Methode kann in abgeleiteten Klassen überschrieben werden
        throw new NotImplementedException("OAuth2-Authentifizierung muss implementiert werden.");
    }
}