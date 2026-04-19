using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Provider.Twitch;

public class TwitchProvider : OAuthProvider<TwitchOptions>
{
    public override string Label => "Login with Twitch";
    public override Color Background => Color.Parse("#9146FF");
    public override Color Foreground => Color.Parse("#ffffff");
    public override string ProviderName => "Twitch";

    protected override IImage? GetIconInternal()
    {
        return GetIcon("avares://Avalonia.Auth.Provider.Twitch/Assets/twitch.svg");
    }
}