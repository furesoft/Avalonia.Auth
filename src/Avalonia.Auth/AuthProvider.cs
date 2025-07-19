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
    public AuthContext Context { get; internal set; } = null!;

    public virtual Task<bool> Authenticate()
    {
        return Task.FromResult(false);
    }

    /// <summary>
    /// Loads an icon from the specified URI.
    /// </summary>
    /// <param name="uri"></param>
    /// <returns></returns>
    protected static IImage? GetIcon(string uri)
    {
        try
        {
            return new Bitmap(AssetLoader.Open(new Uri(uri)));
        }
        catch
        {
            return null;
        }
    }

    protected TOptions? GetOptions<TOptions>() where TOptions : class
    {
        return (TOptions?)Splat.Locator.Current.GetService(typeof(TOptions));
    }
}