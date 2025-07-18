using Avalonia.Media;

namespace Avalonia.Auth.Github;

public class GithubProvider : OAuthProvider
{
    public override string Label => "Login with Github";
    public override Color Background => Color.Parse("#ffffff");
    public override Color Foreground => Color.Parse("#000000");
    public override IImage? Icon { get; } = GetIcon("avares://Avalonia.Auth.Github/Assets/github.png");
    public override void Authenticate()
    {
        var options = GetOptions<GithubOptions>();
        Context.AuthenticatedCommand.Execute(null);
    }
}