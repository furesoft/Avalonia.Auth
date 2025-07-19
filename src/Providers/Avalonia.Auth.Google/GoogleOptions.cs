using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Google;

public class GoogleOptions : OAuthOptions
{
    public GoogleOptions()
    {
        Authority = "https://accounts.google.com/";
        Scope = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email";
        ClientId = "148559676177-0mm94sppm60kqv6veht8pg29vnh6ji0s.apps.googleusercontent.com";
        ClientSecret = "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";
    }
}