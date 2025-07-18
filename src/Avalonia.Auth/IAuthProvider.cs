namespace Avalonia.Auth;

public interface IAuthProvider
{
    string Name { get; }
    void Authenticate();
}