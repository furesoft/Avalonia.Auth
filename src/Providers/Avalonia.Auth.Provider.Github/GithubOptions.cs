using Avalonia.Auth.OAuth;
using Duende.IdentityModel.Jwk;

namespace Avalonia.Auth.Provider.Github;

public class GithubOptions : OAuthOptions
{
    public GithubOptions()
    {
        Authority = "https://github.com/";
        Scope = "read:user user:email";
        ProviderInformation = new()
        {
            AuthorizeEndpoint = "https://github.com/login/oauth/authorize",
            TokenEndpoint = "https://github.com/login/oauth/access_token",
            UserInfoEndpoint = "https://api.github.com/user",
            IssuerName = "Github",
            KeySet = new JsonWebKeySet()
        };

        Policy.Discovery.ValidateIssuerName = false;
    }
}