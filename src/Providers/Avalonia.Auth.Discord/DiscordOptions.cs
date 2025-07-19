using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Discord;

public class DiscordOptions : OAuthOptions
{
    public DiscordOptions()
    {
        Authority = "https://discord.com/";
        Scope = "identify email";
        ClientId = "1396179237353820171";
        ClientSecret = "gMP_t8OklWA5kcopyLG2-VN7PfCCrLdY";
    }
}