using Avalonia.Media;

namespace Avalonia.Auth.Hello;

public class HelloProvider : AuthProvider
{
    public override string Label => "Continue with Hellō";
    public override Color Background => Color.Parse("#24292e");
    public override Color Foreground => Color.Parse("#ffffff");
    public override IImage? Icon { get; } = GetIcon("avares://Avalonia.Auth.Hello/Assets/hello.png");
    public override async Task<bool> Authenticate()
    {
        var options = GetOptions<HelloOptions>();

        return true;
    }
}