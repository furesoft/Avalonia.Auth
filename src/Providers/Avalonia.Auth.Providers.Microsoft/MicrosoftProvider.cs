using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Providers.Microsoft;

public class MicrosoftProvider : OAuthProvider<MicrosoftOptions>
{
    public override string Label => "Login with Microsoft";
    public override Color Background => Color.Parse("#24292e");
    public override Color Foreground => Color.Parse("#ffffff");
    public override IImage? Icon { get; } = GetIcon("avares://Avalonia.Auth.Providers.Microsoft/Assets/microsoft.png");
}