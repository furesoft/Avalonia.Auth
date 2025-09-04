# Avalonia.Auth

[![CodeFactor](https://www.codefactor.io/repository/github/furesoft/Avalonia.Auth/badge)](https://www.codefactor.io/repository/github/furesoft/Avalonia.Auth)
![NuGet Version](https://img.shields.io/nuget/v/Avalonia.Auth)
![NuGet Downloads](https://img.shields.io/nuget/dt/Avalonia.Auth)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![Discord](https://img.shields.io/discord/455738571186241536)
![Libraries.io SourceRank](https://img.shields.io/librariesio/sourcerank/nuget/Avalonia.Auth)
[![](https://tokei.rs/b1/github/furesoft/Avalonia.Auth)](https://github.com/furesoft/Avalonia.Auth)

Avalonia.Auth is a flexible and modern authentication library for Avalonia UI applications. It provides reusable UI components and easy integration of OAuth providers such as Google, GitHub, and Hello.

## Features

- **AuthContext**: Customizable authentication context for different providers
- **Provider-specific colors & icons**
- **Easy integration into Avalonia projects**
- **Extensible for additional OAuth providers**
- **Sample providers for Google, GitHub, and Hello included**

## Installation

1. Install the NuGet packages:
   ```shell
   dotnet add package Avalonia.Auth
   dotnet add package Avalonia.Auth.BrowserAuth
   ```

2. Install Providers
   ```shell
   dotnet add package Avalonia.Auth.Github
   ```

3. Configure in Program.cs in BuildAvaloniaApp()
   ```csharp
   .WithAuth(_ =>
   {
       _.AddProvider<GithubProvider>();
       _.UseBrowserAuth();
   })
   ```
4. Add the AuthContext to your Window:
   ```xml
   xmlns:controls="http://furesoft.de/schemas/auth"
   ```

   ```xml
   <controls:AuthContext />
   ```

All providers that implement `AuthProvider` will be automatically displayed, when they are configured.

| :warning: Important           |
|:----------------------------|
| If no UsernamePasswordProvider is configured the username and password fields are hidden.  For Authentication an external Auth provider has to be registered (BrowserAuth or EmbeddedAuth) |

## Sample Application

A sample application demonstrating usage can be found in the `Sample` folder.

<img width="452" height="396" alt="image" src="https://github.com/user-attachments/assets/d27e47c5-9c8f-4bb3-9be6-663c42cbce93" />


## Providers supported
- Google
- Helló
- Github
- Discord
- WorldID
