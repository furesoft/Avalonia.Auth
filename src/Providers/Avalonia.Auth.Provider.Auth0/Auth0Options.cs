using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Provider.Auth0;

public class Auth0Options : OAuthOptions
{
    public Auth0Options()
    {
        Authority = "https://anders-software.eu.auth0.com";
        Scope = "openid email name profile";
    }
}