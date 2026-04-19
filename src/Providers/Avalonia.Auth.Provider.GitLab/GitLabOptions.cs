using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Provider.GitLab;

public class GitLabOptions : OAuthOptions
{
    public GitLabOptions()
    {
        Authority = "https://gitlab.com/";
        Scope = "read_user";
        // Set ClientId/ClientSecret in config
    }
}
