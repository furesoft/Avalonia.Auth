using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Provider.Auth0;

public class Auth0Provider : OAuthProvider<Auth0Options>
{
    public override string Label => "Login with Auth0";
    public override Color Background => Color.Parse("#EB5424"); // Auth0 Orange
    public override Color Foreground => Color.Parse("#FFFFFF"); // Weiß

    protected override IImage? GetIconInternal()
    {
        return GetIcon("avares://Avalonia.Auth.Provider.Auth0/Assets/auth0.svg");
    }
}