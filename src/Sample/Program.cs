using Avalonia;
using System;
using Avalonia.Auth;
using Avalonia.Auth.Browser;
using Avalonia.Auth.Embedded;
using Avalonia.Auth.Provider.Auth0;
using Avalonia.Auth.Provider.Discord;
using Avalonia.Auth.Provider.Github;
using Avalonia.Auth.Provider.Google;
using Avalonia.Auth.Provider.Hello;
using Avalonia.Auth.Provider.Microsoft;
using Avalonia.Auth.Provider.WorldID;
using Avalonia.WebView.Desktop;

namespace Sample;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithAuth(_ =>
            {
                _.ShowRegisterLink = false;

                _.UseCredentialProvider<Auth0CredentialsProvider>(_ =>
                {
                    _.Domain = "anders-software.eu.auth0.com";
                    _.ClientId = "T9PvTJOweIk0HraP0TOW0B4I0RwmvkjS";
                });

                _.AddProvider<Auth0Provider>();
                _.AddProvider<GoogleProvider>();
                _.AddProvider<GithubProvider>();
                _.AddProvider<DiscordProvider>();
                _.AddProvider<HelloProvider>();
                _.AddProvider<WorldIdProvider>();
                _.AddProvider<MicrosoftProvider>();

                _.UseBrowserAuth();
            })
            .WithInterFont()
            .UseDesktopWebView()
            .LogToTrace();
}