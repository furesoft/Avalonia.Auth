using Avalonia.Auth.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Avalonia.Auth;

public abstract class AuthProvider
{
    public virtual string Label { get; }
    public virtual Color Background { get; } = Colors.Gray;
    public virtual Color Foreground { get; } = Colors.White;
    public virtual IImage? Icon { get; } = null;
    public AuthContext Context { get; internal set; }
    public virtual void Authenticate() {}

    protected static IImage? GetIcon(string uri)
    {
        return new Bitmap(AssetLoader.Open(new Uri(uri)));
    }
}