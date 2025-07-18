using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Sample;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    public partial bool IsAuthenticated { get; set; }

    [RelayCommand]
    private void Authenticated()
    {
        IsAuthenticated = true;
    }
}