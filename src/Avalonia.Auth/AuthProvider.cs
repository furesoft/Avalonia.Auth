using Avalonia.Auth.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Svg.Skia;
using Splat;

namespace Avalonia.Auth;

public abstract class AuthProvider
{
    private IImage? _icon;
    private bool _iconInitialized;

    public virtual string Label { get; }
    public virtual Color Background { get; } = Colors.Gray;
    public virtual Color Foreground { get; } = Colors.White;
    public virtual IImage? Icon
    {
        get
        {
            if (!_iconInitialized)
            {
                _icon = GetIconInternal();
                _iconInitialized = true;
            }
            return _icon;
        }
    }
    public AuthContext Context { get; internal set; } = null!;

    public virtual Task<bool> Authenticate()
    {
        return Task.FromResult(false);
    }

    /// <summary>
    /// Loads an icon from the specified URI. Supports both bitmap and SVG formats.
    /// Derived classes can override this method to provide a custom icon.
    /// </summary>
    /// <returns>An IImage containing the loaded icon, or null if loading fails</returns>
    protected virtual IImage? GetIconInternal()
    {
        return null;
    }

    /// <summary>
    /// Loads an icon from the specified URI. Supports both bitmap and SVG formats.
    /// </summary>
    /// <param name="uri">The URI to the icon file (supports .png, .jpg, .svg)</param>
    /// <returns>An IImage containing the loaded icon, or null if loading fails</returns>
    protected IImage? GetIcon(string uri)
    {
        try
        {
            if (uri.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
            {
                var stream = AssetLoader.Open(new Uri(uri));
                var cssColor = Foreground.ToString();
                var css = $"svg {{ fill: {cssColor}; }}";
                return new SvgImage { Source = SvgSource.LoadFromStream(stream), Css = css};
            }
            else
            {
                return new Bitmap(AssetLoader.Open(new Uri(uri)));
            }
        }
        catch
        {
            return null;
        }
    }

    protected TOptions? GetOptions<TOptions>() where TOptions : class
    {
        var options = (TOptions?)Locator.Current.GetService(typeof(TOptions));

        if (options is null)
        {
            options = Activator.CreateInstance<TOptions>();
            Locator.CurrentMutable.RegisterConstant(options);
        }

        return options;
    }
}