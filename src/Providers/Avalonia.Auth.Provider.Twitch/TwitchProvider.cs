using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Provider.Twitch;

public class TwitchProvider : OAuthProvider<TwitchOptions>
{
    public override string Label => "Login with Microsoft";
    public override Color Background => Color.Parse("#24292e");
    public override Color Foreground => Color.Parse("#ffffff");
    public override IImage? Icon { get; } = GetIcon("avares://Avalonia.Auth.Provider.Twitch/Assets/twitch.png");
}