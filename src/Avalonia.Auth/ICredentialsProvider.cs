namespace Avalonia.Auth;

public interface ICredentialsProvider
{
    Task<bool> AuthenticateAsync(string username, string password);
}