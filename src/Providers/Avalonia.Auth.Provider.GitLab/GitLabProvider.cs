using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Provider.GitLab;

public class GitLabProvider : OAuthProvider<GitLabOptions>
{
    public override string Label => "Login with GitLab";
    public override Color Background => Color.Parse("#FC6D26");
    public override Color Foreground => Colors.White;
    public override string ProviderName => "GitLab";

    protected override IImage? GetIconInternal()
    {
        return GetIcon("avares://Avalonia.Auth.Provider.GitLab/Assets/gitlab.svg");
    }
}
