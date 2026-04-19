namespace Avalonia.Auth;

public interface IOptions
{
    void Load(AuthProvider provider);
}