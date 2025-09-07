using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Provider.Discord;

public class DiscordProvider : OAuthProvider<DiscordOptions>
{
    public override string Label => "Login with Discord";
    public override Color Background => Color.Parse("#5865F2");
    public override Color Foreground => Color.Parse("#FFFFFF");

    public override IImage? Icon { get; } = GetIcon("avares://Avalonia.Auth.Provider.Discord/Assets/discord.png");
}