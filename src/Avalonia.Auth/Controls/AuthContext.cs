using System.Collections.ObjectModel;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml.Templates;
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

    public bool MinimalMode
    {
        get => GetValue(MinimalModeProperty);
        set => SetValue(MinimalModeProperty, value);
    }

    public AuthContext()
    {
        Options = Locator.Current.GetService<AuthOptions>()!;
        MinimalMode = Options.MinimalMode;
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
}