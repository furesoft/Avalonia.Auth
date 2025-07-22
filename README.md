# Avalonia.Auth

Avalonia.Auth is a flexible and modern authentication library for Avalonia UI applications. It provides reusable UI components and easy integration of OAuth providers such as Google, GitHub, and Hello.

[![CodeFactor](https://www.codefactor.io/repository/github/furesoft/Avalonia.Auth/badge)](https://www.codefactor.io/repository/github/furesoft/Avalonia.Auth)
![NuGet Version](https://img.shields.io/nuget/v/Avalonia.Auth)
![NuGet Downloads](https://img.shields.io/nuget/dt/Avalonia.Auth)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
![Discord](https://img.shields.io/discord/455738571186241536)
![Libraries.io SourceRank](https://img.shields.io/librariesio/sourcerank/nuget/Avalonia.Auth)
[![](https://tokei.rs/b1/github/furesoft/Avalonia.Auth)](https://github.com/furesoft/Avalonia.Auth)

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

Each provider can define its own icon (PNG) and colors.

## Sample Application

A sample application demonstrating usage can be found in the `Sample` folder.

## License

This project is licensed under the GNU General Public License v3.0 (GPL-3.0).

---

## Providers supported
- Google
- Helló
- Github
- Discord

[ ] Facebook
[ ] Gitlab
[ ] LinkedIn
[ ] Microsoft
[ ] Reddit
[ ] Twitch
