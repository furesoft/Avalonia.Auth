using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Provider.Google;

public class GoogleProvider : OAuthProvider<GoogleOptions>
{
    public override string Label => "Login with Google";
    public override Color Background => Color.Parse("#ffffff");
    public override Color Foreground => Color.Parse("#3c4043");

    public override IImage? Icon { get; } = GetIcon("avares://Avalonia.Auth.Provider.Google/Assets/google.png");
}