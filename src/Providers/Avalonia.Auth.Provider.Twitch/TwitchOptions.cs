using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Provider.Twitch;

public class TwitchOptions : OAuthOptions
{
    public TwitchOptions()
    {
        Authority = "https://id.twitch.tv/oauth2";
        Scope = "openid";
        RedirectUri = "https://localhost/";

        Policy.Discovery.ValidateIssuerName = false;
    }
}