using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Reddit;

public class RedditProvider : OAuthProvider<RedditOptions>
{
    public override string Label => "Login with Reddit";
    public override Color Background => Color.Parse("#FF4500");
    public override Color Foreground => Color.Parse("#FFFFFF");
    public override IImage? Icon { get; } = GetIcon("avares://Avalonia.Auth.Reddit/Assets/reddit.png");
}