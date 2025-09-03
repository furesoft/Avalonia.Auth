using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Fusio;

public class FusioProvider : OAuthProvider<FusioOptions>
{
    public override string Label => "Login with Fusio";
    public override Color Background => Color.Parse("#5a5a5a");
    public override Color Foreground => Color.Parse("#FFFFFF");

    public override IImage? Icon { get; } = GetIcon("avares://Avalonia.Auth.Fusio/Assets/fusio.png");
}