using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Provider.Hello;

public class HelloProvider : OAuthProvider<HelloOptions>
{
    public override string Label => "Continue with Hellō";
    public override Color Background => Color.Parse("#000000");
    public override Color Foreground => Color.Parse("#ffffff");

    protected override IImage? GetIconInternal()
    {
        return GetIcon("avares://Avalonia.Auth.Provider.Hello/Assets/hello.svg");
    }
}