using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using Splat;

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

    public static readonly StyledProperty<AuthProviderButtonState> StateProperty =
        AvaloniaProperty.Register<AuthProviderButton, AuthProviderButtonState>(nameof(State), AuthProviderButtonState.Normal);

    public AuthProviderButtonState State
    {
        get => GetValue(StateProperty);
        set => SetValue(StateProperty, value);
    }

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
        if (Provider == null) return;

        Background = new SolidColorBrush(Provider.Background);
        Foreground = new SolidColorBrush(Provider.Foreground);
        if (Provider.Icon is not null)
            Icon = Provider.Icon;

        Label = Provider.Label;
    }

    private async void AuthProviderButton_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        State = AuthProviderButtonState.Loading;

        try
        {
            if (await Provider.Authenticate())
            {
                var session = Locator.Current.GetService<Session>()!;

                Provider.Context.AuthenticatedCommand?.Execute(session);
            }
        }
        catch
        {
            State = AuthProviderButtonState.Error;
        }
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        var border = e.NameScope.Find<Border>("PART_Border");
        border!.PointerPressed += AuthProviderButton_OnPointerPressed;
    }
}