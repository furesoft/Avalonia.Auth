using System.Threading.Tasks;
using Avalonia.Auth;

namespace Sample;

public class SampleCredentialsProvider : ICredentialsProvider
{
    public Task<bool> AuthenticateAsync(string username, string password)
    {
        return Task.FromResult(username == "user" && password == "password");
    }
}