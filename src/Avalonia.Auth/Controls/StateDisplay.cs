using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;

namespace Avalonia.Auth.Controls;

public class StateDisplay : ContentControl, INotifyPropertyChanged
{
    public static readonly DirectProperty<StateDisplay, AuthProviderButtonState> StateProperty =
        AvaloniaProperty.RegisterDirect<StateDisplay, AuthProviderButtonState>(
            nameof(State),
            o => o.State,
            (o, v) => o.State = v,
            AuthProviderButtonState.Normal);

    public static readonly DirectProperty<StateDisplay, bool> IsNormalProperty =
        AvaloniaProperty.RegisterDirect<StateDisplay, bool>(
            nameof(IsNormal),
            o => o.IsNormal,
            (o, v) => o.IsNormal = v,
            true);

    public static readonly DirectProperty<StateDisplay, bool> IsLoadingProperty =
        AvaloniaProperty.RegisterDirect<StateDisplay, bool>(
            nameof(IsLoading),
            o => o.IsLoading,
            (o, v) => o.IsLoading = v);

    public static readonly DirectProperty<StateDisplay, bool> IsErrorProperty =
        AvaloniaProperty.RegisterDirect<StateDisplay, bool>(
            nameof(IsError),
            o => o.IsError,
            (o, v) => o.IsError = v);

    private AuthProviderButtonState _state = AuthProviderButtonState.Normal;
    private bool _isNormal = true;
    private bool _isLoading;
    private bool _isError;
    private bool _isSuccess;

    public event PropertyChangedEventHandler? PropertyChanged;

    public AuthProviderButtonState State
    {
        get => _state;
        set
        {
            if (_state != value)
            {
                SetAndRaise(StateProperty, ref _state, value);
                OnPropertyChanged(nameof(State));
                IsNormal = value == AuthProviderButtonState.Normal;
                IsLoading = value == AuthProviderButtonState.Loading;
                IsError = value == AuthProviderButtonState.Error;
            }
        }
    }

    public bool IsNormal
    {
        get => _isNormal;
        set
        {
            if (_isNormal != value)
            {
                SetAndRaise(IsNormalProperty, ref _isNormal, value);
                OnPropertyChanged(nameof(IsNormal));
            }
        }
    }

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (_isLoading != value)
            {
                SetAndRaise(IsLoadingProperty, ref _isLoading, value);
                OnPropertyChanged(nameof(IsLoading));
            }
        }
    }

    public bool IsError
    {
        get => _isError;
        set
        {
            if (_isError != value)
            {
                SetAndRaise(IsErrorProperty, ref _isError, value);
                OnPropertyChanged(nameof(IsError));
            }
        }
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}