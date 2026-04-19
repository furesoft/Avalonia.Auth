using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Provider.Discord;

public class DiscordOptions : OAuthOptions
{
    public DiscordOptions()
    {
        Authority = "https://discord.com/";
        Scope = "identify email";
    }
}