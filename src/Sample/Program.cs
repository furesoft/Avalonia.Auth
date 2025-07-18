using Avalonia;
using System;
using Avalonia.Auth;
using Avalonia.Media;

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
            .ConfigureAuth(_ =>
            {
                _.Title = "Login";
                _.ShowRegisterLink = false;
            })
            .UseAuthProvider<GoogleProvider>()
            .UseAuthProvider<GithubProvider>()
            .WithInterFont()
            .LogToTrace();
}

internal class GoogleProvider : AuthProvider
{
    public override string Name => "Google";
    public override Color Background => Color.Parse("#ffffff");
    public override Color Foreground => Color.Parse("#3c4043");

    public override IImage? Icon { get; } = GetIcon("avares://Sample/Assets/google.png");

    public override void Authenticate()
    {
        throw new NotImplementedException();
    }
}

internal class GithubProvider : AuthProvider
{
    public override string Name => "Github";
    public override Color Background => Color.Parse("#24292e");
    public override Color Foreground => Color.Parse("#ffffff");
    public override IImage? Icon { get; } = GetIcon("avares://Sample/Assets/github.png");
    public override void Authenticate()
    {
        throw new NotImplementedException();
    }
}