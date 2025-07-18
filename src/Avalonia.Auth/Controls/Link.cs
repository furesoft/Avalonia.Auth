using Avalonia.Controls;
using Avalonia.Media;

namespace Avalonia.Auth.Controls;

internal class Link : Button
{
    public static StyledProperty<TextDecorationCollection> TextDecorationsProperty =
        AvaloniaProperty.Register<Link, TextDecorationCollection>(nameof(TextDecorations));

    public static StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<Link, string>(nameof(Title));

    public TextDecorationCollection TextDecorations
    {
        get => GetValue(TextDecorationsProperty);
        set => SetValue(TextDecorationsProperty, value);
    }

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
}