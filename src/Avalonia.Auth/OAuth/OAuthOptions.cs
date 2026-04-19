using Duende.IdentityModel.OidcClient;

namespace Avalonia.Auth.OAuth;

public class OAuthOptions : OidcClientOptions, IOptions
{
    public bool UseHostUriRedirectUrl { get; set; }

    public void Load(AuthProvider provider)
    {
        var providerKey = provider.ProviderName;

        var authority = GetEnv("Authority");
        if (!string.IsNullOrWhiteSpace(authority)) Authority = authority;

        var clientId = GetEnv("ClientId");
        if (!string.IsNullOrWhiteSpace(clientId)) ClientId = clientId;

        var clientSecret = GetEnv("ClientSecret");
        if (!string.IsNullOrWhiteSpace(clientSecret)) ClientSecret = clientSecret;

        var scope = GetEnv("Scope");
        if (!string.IsNullOrWhiteSpace(scope)) Scope = scope;

        var redirectUri = GetEnv("RedirectUri");
        if (!string.IsNullOrWhiteSpace(redirectUri)) RedirectUri = redirectUri;

        // Support setting nested ProviderInformation properties using either
        // "ProviderInformation.AuthorizeEndpoint" or short names like "AuthorizeEndpoint".
        var authorizeEndpoint = GetEnv("ProviderInformation.AuthorizeEndpoint") ?? GetEnv("AuthorizeEndpoint");
        var tokenEndpoint = GetEnv("ProviderInformation.TokenEndpoint") ?? GetEnv("TokenEndpoint");
        var userInfoEndpoint = GetEnv("ProviderInformation.UserInfoEndpoint") ?? GetEnv("UserInfoEndpoint");
        var issuerName = GetEnv("ProviderInformation.IssuerName") ?? GetEnv("IssuerName");

        if (!string.IsNullOrWhiteSpace(authorizeEndpoint) || !string.IsNullOrWhiteSpace(tokenEndpoint)
            || !string.IsNullOrWhiteSpace(userInfoEndpoint) || !string.IsNullOrWhiteSpace(issuerName))
        {
            ProviderInformation ??= new();

            if (!string.IsNullOrWhiteSpace(authorizeEndpoint)) ProviderInformation.AuthorizeEndpoint = authorizeEndpoint;
            if (!string.IsNullOrWhiteSpace(tokenEndpoint)) ProviderInformation.TokenEndpoint = tokenEndpoint;
            if (!string.IsNullOrWhiteSpace(userInfoEndpoint)) ProviderInformation.UserInfoEndpoint = userInfoEndpoint;
            if (!string.IsNullOrWhiteSpace(issuerName)) ProviderInformation.IssuerName = issuerName;
        }

        return;

        string? GetEnv(string prop) => Environment.GetEnvironmentVariable($"oauth.provider.{providerKey}.{prop}");
    }
}