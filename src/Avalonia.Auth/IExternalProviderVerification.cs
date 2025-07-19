namespace Avalonia.Auth;

public interface IExternalProviderVerification
{
    Task<bool> Open(string url);
}