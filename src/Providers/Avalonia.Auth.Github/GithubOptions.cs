using Avalonia.Auth.OAuth;
using Duende.IdentityModel.Jwk;

namespace Avalonia.Auth.Github;

public class GithubOptions : OAuthOptions
{
    public GithubOptions()
    {
        Authority = "https://github.com/";
        ClientId = "Iv23liOoreSRswVF7FVO";
        Scope = "read:user user:email";
        ClientSecret = "d02ffb9764b85763601fb5832db5b296a06646a5";

        ProviderInformation = new();
        ProviderInformation.AuthorizeEndpoint = "https://github.com/login/oauth/authorize";
        ProviderInformation.TokenEndpoint = "https://github.com/login/oauth/access_token";
        ProviderInformation.UserInfoEndpoint = "https://api.github.com/user";
        ProviderInformation.IssuerName = "Github";
        ProviderInformation.KeySet = new JsonWebKeySet();

        Policy.Discovery.ValidateIssuerName = false;
    }

}