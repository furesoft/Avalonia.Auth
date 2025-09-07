using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Provider.Auth0;

public class Auth0Options : OAuthOptions
{
    public Auth0Options()
    {
        Authority = "https://anders-software.eu.auth0.com";
        Scope = "openid email name profile";
        ClientId = "T9PvTJOweIk0HraP0TOW0B4I0RwmvkjS";
        ClientSecret = "yL4qydfflvIMQEOfRN8x07Zee9KqQ0rRtTS0eQwa6W1Rr_vH6puBs4LGfvaY_kCE";
    }
}