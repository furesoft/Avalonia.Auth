using Avalonia.Controls;

namespace Avalonia.Auth.Controls.Modal;

internal class ContentDialog : ContentControl
{
    public static readonly StyledProperty<object> DialogContentProperty =
        AvaloniaProperty.Register<ContentDialog, object>("DialogContent");

    public static readonly StyledProperty<bool> IsOpenedProperty =
        AvaloniaProperty.Register<ContentDialog, bool>("IsOpened");

    public object DialogContent
    {
        get => GetValue(DialogContentProperty);
        set => SetValue(DialogContentProperty, value);
    }

    public bool IsOpened
    {
        get => GetValue(IsOpenedProperty);
        set => SetValue(IsOpenedProperty, value);
    }
}