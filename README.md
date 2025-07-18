# Avalonia.Auth

Avalonia.Auth is a flexible and modern authentication library for Avalonia UI applications. It provides reusable UI components and easy integration of OAuth providers like Google and GitHub.

## Features

- **AuthProviderButton**: Beautiful, customizable button for various authentication providers
- **Provider-specific colors & icons**
- **Easy integration into Avalonia projects**
- **Extensible for additional OAuth providers**

## Example

```xml
<controls:AuthProviderButton
    Title="Sign in with Google"
    Icon="avares://Sample/Assets/google.png"
    ProviderName="Google"
    Background="#fbbc05" />

<controls:AuthProviderButton
    Title="Sign in with Github"
    Icon="avares://Sample/Assets/github.png"
    ProviderName="Github"
    Background="#24292e" />
```

## Installation

1. Reference the package:
   - Via NuGet: `Avalonia.Auth`
2. Add the namespace in your XAML:
   ```xml
   xmlns:controls="clr-namespace:Avalonia.Auth.Controls;assembly=Avalonia.Auth"
   ```

## Extending

You can add your own providers by implementing `IAuthProvider` and customizing the button as needed.

## Sample

A sample application is included in the `Sample` folder to demonstrate usage.

## License

GPL-3 License

---

**Avalonia.Auth** – Simple and beautiful authentication for Avalonia UI!
