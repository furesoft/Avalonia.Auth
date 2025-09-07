using Avalonia.Auth.OAuth;
using Duende.IdentityModel.Jwk;

namespace Avalonia.Auth.Reddit;

public class RedditOptions : OAuthOptions
{
    public RedditOptions()
    {
        Authority = "https://www.reddit.com/";
        ClientId = "c5aopB4iqdCvmofMS3MAzQ";
        Scope = "openid profile";

        ProviderInformation = new();
        ProviderInformation.AuthorizeEndpoint = "https://www.reddit.com/api/v1/authorize";
        ProviderInformation.TokenEndpoint = "https://www.reddit.com/api/v1/access_token";
        ProviderInformation.UserInfoEndpoint = "https://www.reddit.com/api/v1/me";
        ProviderInformation.IssuerName = "Reddit";
        ProviderInformation.KeySet = new JsonWebKeySet();

        Policy.Discovery.ValidateIssuerName = false;
    }
}