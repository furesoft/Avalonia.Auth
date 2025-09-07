using Avalonia;
using System;
using Avalonia.Auth;
using Avalonia.Auth.Browser;
using Avalonia.Auth.Discord;
using Avalonia.Auth.Embedded;
using Avalonia.Auth.Github;
using Avalonia.Auth.Google;
using Avalonia.Auth.Hello;
using Avalonia.Auth.WorldID;
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

                _.UseUsernamePasswordProvider<SampleUsernamePasswordProvider>();

                _.AddProvider<GoogleProvider>();
                _.AddProvider<GithubProvider>();
                _.AddProvider<DiscordProvider>();
                _.AddProvider<HelloProvider>();
                _.AddProvider<WorldIdProvider>();

                _.UseEmbeddedAuth();
            })
            .WithInterFont()
            .UseDesktopWebView()
            .LogToTrace();
}