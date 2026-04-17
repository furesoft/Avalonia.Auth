using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Provider.Twitch;

public class TwitchOptions : OAuthOptions
{
    public TwitchOptions()
    {
        Authority = "https://id.twitch.tv/oauth2";
        ClientId = "ns6y2ybvbtr0jmh56ns702sd9hjd6u";
        Scope = "openid";
        RedirectUri = "https://localhost/";

        Policy.Discovery.ValidateIssuerName = false;
    }
}