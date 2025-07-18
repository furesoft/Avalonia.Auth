# Avalonia.Auth

Avalonia.Auth is a flexible and modern authentication library for Avalonia UI applications. It provides reusable UI components and easy integration of OAuth providers like Google and GitHub.

## Features

- **AuthContext**: Modern, customizable authentication context for various providers
- **Provider-specific colors & icons**
- **Easy integration into Avalonia projects**
- **Extensible for additional OAuth providers**

## Example

```xml
<controls:AuthContext />
```

All available providers registered in the Splat IoC container and implementing `AuthProvider` will be shown automatically.

## Installation

1. Reference the package:
   - Via NuGet: `Avalonia.Auth`
2. Add the namespace in your XAML:
   ```xml
   xmlns:controls="clr-namespace:Avalonia.Auth.Controls;assembly=Avalonia.Auth"
   ```

## Extending

You can add your own providers by implementing `AuthProvider` and registering them in the Splat IoC container.

## Sample

A sample application is included in the `Sample` folder to demonstrate usage.

## License

This project is licensed under the GNU General Public License v3.0 (GPL-3.0).

---

**Avalonia.Auth** – Simple and beautiful authentication for Avalonia UI!
