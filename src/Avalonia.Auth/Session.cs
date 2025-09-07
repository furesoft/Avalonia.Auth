using System.Security.Principal;
using Avalonia.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Auth;

public partial class Session : ObservableObject
{
    [ObservableProperty]
    private IPrincipal? _principal;

    public Binding CreateBinding(string path)
    {
        return new Binding(path)
        {
            Source = this
        };
    }
}