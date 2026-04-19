using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Provider.Microsoft;

public class MicrosoftOptions : OAuthOptions
{
    public MicrosoftOptions()
    {
        Authority = "https://login.microsoftonline.com/common/v2.0/";
        Scope = "openid";

        Policy.Discovery.ValidateIssuerName = false;
    }
}