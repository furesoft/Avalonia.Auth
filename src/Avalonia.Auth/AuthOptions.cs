namespace Avalonia.Auth;

public class AuthOptions
{
    public string Title { get; set; } = "Login";
    public bool EnableUsernamePassword { get; set; } = true;
    public bool ShowForgotPasswordLink { get; set; } = true;
    public bool ShowRegisterLink { get; set; } = true;
}