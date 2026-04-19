using Avalonia.Auth.OAuth;
using Avalonia.Media;

namespace Avalonia.Auth.Provider.Microsoft;

public class MicrosoftProvider : OAuthProvider<MicrosoftOptions>
{
    public override string Label => "Login with Microsoft";
    public override Color Background => Color.Parse("#0078D4");
    public override Color Foreground => Color.Parse("#ffffff");

    public override string ProviderName => "Microsoft";

    protected override IImage? GetIconInternal()
    {
        return GetIcon("avares://Avalonia.Auth.Provider.Microsoft/Assets/microsoft.svg");
    }
}