using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Auth.Controls.Modal;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Splat;

namespace Avalonia.Auth.Controls;

public class AuthContext : TemplatedControl
{
    public static readonly StyledProperty<ObservableCollection<AuthProvider>> ProvidersProperty =
        AvaloniaProperty.Register<AuthProviderButton, ObservableCollection<AuthProvider>>(nameof(Providers));

    public static readonly StyledProperty<AuthOptions> OptionsProperty =
        AvaloniaProperty.Register<AuthContext, AuthOptions>(nameof(AuthOptions));

    public static readonly StyledProperty<ItemsPanelTemplate> ItemsPanelProperty =
        AvaloniaProperty.Register<AuthContext, ItemsPanelTemplate>(nameof(ItemsPanel));

    public static readonly StyledProperty<bool> MinimalModeProperty =
        AvaloniaProperty.Register<AuthContext, bool>(nameof(MinimalMode));

    public static readonly StyledProperty<ICommand> RegisterCommandProperty =
        AvaloniaProperty.Register<AuthContext, ICommand>(nameof(RegisterCommand));

    public static readonly StyledProperty<ICommand> ForgotPasswordCommandProperty =
        AvaloniaProperty.Register<AuthContext, ICommand>(nameof(ForgotPasswordCommand));

    public static readonly StyledProperty<ICommand> AuthenticatedCommandProperty =
        AvaloniaProperty.Register<AuthContext, ICommand>(nameof(AuthenticatedCommand));

    public static readonly StyledProperty<IImage> LogoProperty =
        AvaloniaProperty.Register<AuthContext, IImage>(nameof(Logo));

    public IImage Logo
    {
        get => GetValue(LogoProperty);
        set => SetValue(LogoProperty, value);
    }

    public ICommand AuthenticatedCommand
    {
        get => GetValue(AuthenticatedCommandProperty);
        set => SetValue(AuthenticatedCommandProperty, value);
    }

    public ICommand ForgotPasswordCommand
    {
        get => GetValue(ForgotPasswordCommandProperty);
        set => SetValue(ForgotPasswordCommandProperty, value);
    }

    public ICommand RegisterCommand
    {
        get => GetValue(RegisterCommandProperty);
        set => SetValue(RegisterCommandProperty, value);
    }

    public bool MinimalMode
    {
        get => GetValue(MinimalModeProperty);
        set => SetValue(MinimalModeProperty, value);
    }

    public AuthContext()
    {
        Options = Locator.Current.GetService<AuthOptions>()!;
        Providers = new ObservableCollection<AuthProvider>(Options.Providers);
    }

    public ItemsPanelTemplate ItemsPanel
    {
        get => GetValue(ItemsPanelProperty);
        set => SetValue(ItemsPanelProperty, value);
    }

    public AuthOptions Options
    {
        get => GetValue(OptionsProperty);
        set => SetValue(OptionsProperty, value);
    }

    public ObservableCollection<AuthProvider> Providers
    {
        get => GetValue(ProvidersProperty);
        set => SetValue(ProvidersProperty, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        foreach (var authProvider in Providers)
        {
            authProvider.Context = this;
        }

        var loginButton = e.NameScope.Find<Button>("PART_LoginButton");
        loginButton!.Click += async (s, p) =>
        {
            var usernameBox = e.NameScope.Find<TextBox>("PART_UsernameBox");
            var passwordBox = e.NameScope.Find<TextBox>("PART_PasswordBox");
            var result = await Options.UsernamePasswordProvider!.AuthenticateAsync(usernameBox!.Text!, passwordBox!.Text!);

            if (result)
            {
                AuthenticatedCommand?.Execute(null);
                return;
            }

            await DialogHost.ShowAsync("Invalid credentials");
        };
    }
}