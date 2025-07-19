namespace Avalonia.Auth;

public interface IUsernamePasswordProvider
{
    Task<bool> AuthenticateAsync(string username, string password);
}