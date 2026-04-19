using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Provider.Hello;

public class HelloOptions : OAuthOptions
{
    public HelloOptions()
    {
        Authority = "https://issuer.hello.coop/";
        Scope = "openid profile name picture github email";
    }
}