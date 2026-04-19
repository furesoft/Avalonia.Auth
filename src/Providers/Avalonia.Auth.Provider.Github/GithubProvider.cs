using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Provider.Github;

public class GithubProvider : OAuthProvider<GithubOptions>
{
    public override string Label => "Login with Github";
    public override Color Background => Color.Parse("#ffffff");
    public override Color Foreground => Color.Parse("#24292e");
    public override string ProviderName => "Github";

    protected override IImage? GetIconInternal()
    {
        return GetIcon("avares://Avalonia.Auth.Provider.Github/Assets/github.svg");
    }
}