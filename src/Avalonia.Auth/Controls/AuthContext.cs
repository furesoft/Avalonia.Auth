using System.Collections.ObjectModel;
using Avalonia.Controls.Primitives;
using Splat;

namespace Avalonia.Auth.Controls;

public class AuthContext : TemplatedControl
{
    public static readonly StyledProperty<ObservableCollection<AuthProvider>> ProvidersProperty =
        AvaloniaProperty.Register<AuthProviderButton, ObservableCollection<AuthProvider>>(nameof(Providers));

    public ObservableCollection<AuthProvider> Providers
    {
        get => GetValue(ProvidersProperty);
        set => SetValue(ProvidersProperty, value);
    }

    public AuthContext()
    {
        var providers = Locator.Current.GetServices<AuthProvider>();
        Providers = new ObservableCollection<AuthProvider>(providers);
    }

}