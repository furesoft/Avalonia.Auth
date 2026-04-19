# Avalonia.Auth Agent Guide

## Architecture Overview
Avalonia.Auth is a modular authentication library for Avalonia UI applications. Core components:
- **AuthProvider**: Base class for authentication providers (OAuth, credentials)
- **OAuthProvider<TOptions>**: Generic OAuth implementation using Duende.IdentityModel.OidcClient
- **AuthContext**: Main UI control displaying provider buttons and credential fields
- **Session**: MVVM-compatible holder for authenticated user principal
- **BrowserVerification**: Handles OAuth flow via system browser

Data flows: Provider.Authenticate() → BrowserVerification.Open() → OidcClient → Session.Principal update → AuthenticatedCommand execution.

## Key Workflows
- **Build**: `dotnet build` in solution root builds all projects and generates NuGet packages
- **Run Sample**: `cd Sample; dotnet run` to test authentication flows
- **Add Provider**: Create new project in `Providers/` following existing pattern (e.g., `Avalonia.Auth.Provider.Google`)

## Project Conventions
- **Provider Structure**: Each OAuth provider lives in `Providers/Avalonia.Auth.Provider.{Name}/` with:
  - `{Name}Provider.cs`: Inherits `OAuthProvider<{Name}Options>`, sets Label, Background/Foreground colors, Icon
  - `{Name}Options.cs`: Inherits `OAuthOptions`, configures Authority, Scope, ClientId, ClientSecret
  - `Assets/`: Contains provider icon as SVG (e.g., `avares://Avalonia.Auth.Provider.Google/Assets/google.svg`)
- **Icon Loading**: Use `GetIcon("avares://.../Assets/icon.svg")` in `GetIconInternal()`; SVG fills with Foreground color
- **Configuration**: Register providers in `BuildAvaloniaApp().WithAuth(_ => _.AddProvider<{Name}Provider>())`
- **Styling**: Provider buttons use Background/Foreground from provider; AuthContext supports MinimalMode for compact display
- **Claims Binding**: Use markup extensions like `<TextBlock Text="{auth:Claim name}"/>` or `<Border IsVisible="{auth:HasClaim admin}"/>`
- **Dependencies**: Uses Splat for DI; register options/services via `Locator.CurrentMutable`

## Integration Patterns
- **External Auth**: OAuth providers delegate to `BrowserVerification` using `WebAuthenticationBroker.AuthenticateAsync()`
- **Credential Auth**: Implement `ICredentialsProvider` for username/password; enable via `UseCredentialProvider<T>()`
- **Session Binding**: Bind UI to session via `Session.CreateBinding("Principal.Identity.Name")`
- **Error Handling**: Provider buttons show loading/error states; exceptions from `Authenticate()` set ErrorMessage

## Examples
**Adding a new OAuth provider** (e.g., GitLab):
```csharp
// GitLabProvider.cs
public class GitLabProvider : OAuthProvider<GitLabOptions> {
    public override string Label => "Login with GitLab";
    public override Color Background => Colors.Orange;
    protected override IImage? GetIconInternal() => GetIcon("avares://Avalonia.Auth.Provider.GitLab/Assets/gitlab.svg");
}

// GitLabOptions.cs
public class GitLabOptions : OAuthOptions {
    public GitLabOptions() {
        Authority = "https://gitlab.com/";
        Scope = "read_user";
        // Set ClientId/ClientSecret in config
    }
}
```

**Using in XAML**:
```xml
<controls:AuthContext AuthenticatedCommand="{Binding OnAuthenticated}" MinimalMode="True"/>
<TextBlock Text="{auth:Claim name}" Visibility="{auth:HasRole admin, Converter={x:Static BoolConverters.And}}"/>
```</content>
<parameter name="filePath">D:\Avalonia.Auth\src\AGENTS.md
