using Avalonia.Auth.OAuth;

namespace Avalonia.Auth.Fusio;

public class FusioOptions : OAuthOptions
{
    public FusioOptions()
    {
        //Todo: configure to use it with sample fusio instance
        Authority = "";
        Scope = "identify email";
        ClientId = "4b5c0dff-2635-437c-8993-31c016df62d4";
        ClientSecret = "a870f921f2570a74f604e8b2283b3212b4e478adb656efe2f9045850cfc8abf0";
    }
}