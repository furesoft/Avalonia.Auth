using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Auth.Controls;

public class AuthProviderButton : Button
{
    public static readonly StyledProperty<IImage?> IconProperty =
        AvaloniaProperty.Register<AuthProviderButton, IImage?>(nameof(Icon));

    public static readonly StyledProperty<string?> TitleProperty =
        AvaloniaProperty.Register<AuthProviderButton, string?>(nameof(Title));

    public static readonly StyledProperty<string?> ProviderNameProperty =
        AvaloniaProperty.Register<AuthProviderButton, string?>(nameof(ProviderName));

    public IImage? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string? Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string? ProviderName
    {
        get => GetValue(ProviderNameProperty);
        set => SetValue(ProviderNameProperty, value);
    }
}