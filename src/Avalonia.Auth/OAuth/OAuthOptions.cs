using Duende.IdentityModel.OidcClient;

namespace Avalonia.Auth.OAuth;

public class OAuthOptions : OidcClientOptions
{
    public bool UseHostUriRedirectUrl { get; set; }
}