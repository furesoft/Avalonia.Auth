using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.WorldID;

public class WorldIdOptions : OAuthOptions
{
    public WorldIdOptions()
    {
        Authority = "https://issuer.hello.coop/";
        ClientId = "app_7VOU7y3FRsPuO2ALng6YQtYc_sWG";
        Scope = "openid profile name picture github email";
        ClientSecret = "ZWm-UprQfZ-kRl_TIUaQa";
    }
}