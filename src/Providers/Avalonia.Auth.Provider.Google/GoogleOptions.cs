using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Provider.Google;

public class GoogleOptions : OAuthOptions
{
    public GoogleOptions()
    {
        Authority = "https://accounts.google.com/";
        Scope = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email";
    }
}