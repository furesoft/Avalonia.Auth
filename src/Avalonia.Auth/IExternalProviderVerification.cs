using Avalonia.Auth.OAuth;

namespace Avalonia.Auth;

public interface IExternalProviderVerification
{
    Task<bool> Open(OAuthOptions ooptions);
}