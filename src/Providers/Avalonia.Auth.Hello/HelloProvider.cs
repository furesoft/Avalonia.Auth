using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Hello;

public class HelloProvider : OAuthProvider<HelloOptions>
{
    public override string Label => "Continue with Hellō";
    public override Color Background => Color.Parse("#24292e");
    public override Color Foreground => Color.Parse("#ffffff");
    public override IImage? Icon { get; } = GetIcon("avares://Avalonia.Auth.Hello/Assets/hello.png");
}