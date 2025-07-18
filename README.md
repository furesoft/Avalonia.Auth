# Avalonia.Auth

Avalonia.Auth is a flexible and modern authentication library for Avalonia UI applications. It provides reusable UI components and easy integration of OAuth providers such as Google, GitHub, and Hello.

## Features

- **AuthContext**: Customizable authentication context for different providers
- **Provider-specific colors & icons**
- **Easy integration into Avalonia projects**
- **Extensible for additional OAuth providers**
- **Sample providers for Google, GitHub, and Hello included**

## Installation

1. Install the NuGet package:
   ```shell
   dotnet add package Avalonia.Auth
   ```
2. Add the namespace in your XAML file:
   ```xml
   xmlns:controls="clr-namespace:Avalonia.Auth.Controls;assembly=Avalonia.Auth"
   ```

## Example

```xml
<controls:AuthContext />
```

All providers that implement `AuthProvider` will be automatically displayed.


## Assets & Styles

Each provider can define its own icon (PNG) and colors. You can find the default styles in the `Styles` folder.

## Sample Application

A sample application demonstrating usage can be found in the `Sample` folder.

## License

This project is licensed under the GNU General Public License v3.0 (GPL-3.0).

---

**Avalonia.Auth** – Modern and beautiful authentication for Avalonia UI!
