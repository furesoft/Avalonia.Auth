using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Provider.WorldID;

public class WorldIdProvider : OAuthProvider<WorldIdOptions>
{
    public override string Label => "Continue with WorldID";
    public override Color Foreground => Color.Parse("#000000");
    public override Color Background => Color.Parse("#ffffff");
    public override IImage? Icon { get; } = GetIcon("avares://Avalonia.Auth.Provider.WorldID/Assets/worldid.png");
}