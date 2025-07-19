using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace Avalonia.Auth.Controls;

internal class AuthProviderButton : Button
{
    public static readonly StyledProperty<bool> IconOnlyProperty = AvaloniaProperty.Register<AuthProviderButton, bool>(nameof(IconOnly));

    public static readonly StyledProperty<IImage> IconProperty =
        AvaloniaProperty.Register<AuthProviderButton, IImage>(nameof(Icon));

    public static readonly StyledProperty<string> LabelProperty =
        AvaloniaProperty.Register<AuthProviderButton, string>(nameof(Label));

    public static readonly StyledProperty<AuthProvider> ProviderProperty =
        AvaloniaProperty.Register<AuthProviderButton, AuthProvider>(nameof(Provider));

    public IImage Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public AuthProvider Provider
    {
        get => GetValue(ProviderProperty);
        set => SetValue(ProviderProperty, value);
    }

    public bool IconOnly
    {
        get { return GetValue(IconOnlyProperty); }
        set { SetValue(IconOnlyProperty, value); }
    }

    static AuthProviderButton()
    {
        ProviderProperty.Changed.AddClassHandler<AuthProviderButton>((b, e) => b.OnProviderChanged());
    }

    private void OnProviderChanged()
    {
        Background = new SolidColorBrush(Provider.Background);
        Foreground = new SolidColorBrush(Provider.Foreground);
        if (Provider.Icon is not null)
            Icon = Provider.Icon;

        Label = Provider?.Label;
    }

    private void AuthProviderButton_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        Provider.Authenticate();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        var border = e.NameScope.Find<Border>("PART_Border");
        border!.PointerPressed += AuthProviderButton_OnPointerPressed;
    }
}