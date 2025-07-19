using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Splat;

namespace Avalonia.Auth.Core;

public abstract class BaseViewModel : ObservableObject
{
    public event Action OnRequestClose;

    public bool IsLoaded { get; set; }

    public static void ApplyViewModel<T>(Control control, T vm)
        where T : BaseViewModel
    {
        if (control is Window win)
        {
            vm.OnRequestClose += () =>
            {
                win.Close();
            };
        }

        vm.Load();

        if (!Design.IsDesignMode)
        {
            control.DataContext = vm;
        }
    }
    public static void ApplyViewModel<T>(Control control)
        where T : BaseViewModel
    {
        var vm = (T?)Locator.Current.GetService(typeof(T));

        ApplyViewModel<T>(control, vm);
    }

    public void Load()
    {
        if (!IsLoaded)
        {
            IsLoaded = true;

            OnLoad();
        }
    }

    protected virtual void OnLoad()
    {
    }

    protected void RequestClose()
    {
        OnRequestClose?.Invoke();
    }
}