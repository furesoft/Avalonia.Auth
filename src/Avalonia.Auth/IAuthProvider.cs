using Avalonia.Media;

namespace Avalonia.Auth;

public abstract class AuthProvider
{
    public virtual string Name { get; }
    public virtual Color Background { get; } = Colors.Gray;
    public virtual Color Foreground { get; } = Colors.White;
    public virtual void Authenticate() {}
}