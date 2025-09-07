using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Provider.WorldID;

public class WorldIdOptions : OAuthOptions
{
    public WorldIdOptions()
    {
        Authority = "https://id.worldcoin.org/";
        ClientId = "app_5c8a790af0a067432493d01c37d3b927";
        ClientSecret = "sk_0a39850fc7ddb43fa06467ce52d0d38a19c032708f8b7c00";
        Scope = "openid profile email";
        UseHostUriRedirectUrl = true;
        RedirectUri = "https://id.auth.com";
    }
}