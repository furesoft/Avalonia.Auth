using Avalonia.Auth.Controls.Modal.ViewModels;
using Avalonia.Auth.Core;
using Avalonia.Controls;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.Auth.Controls.Modal;

internal static class DialogHost
{
    private static ContentDialog? _host;

    public static void Close()
    {
        if (_host != null) _host.IsOpened = false;
    }

    public static bool GetIsHost(ContentDialog target)
    {
        return ReferenceEquals(_host, target);
    }

    public static void Open(object content)
    {
        Dispatcher.UIThread.Invoke(() =>
        {
            if (_host == null) return;

            _host.DialogContent = content;
            _host.IsOpened = true;
        });
    }

    public static void Open(Control content, BaseViewModel viewModel)
    {
        viewModel.Load();

        Dispatcher.UIThread.Invoke(() =>
        {
            content.DataContext = viewModel;
            Open(content);
        });
    }

    public static void SetIsHost(ContentDialog target, bool value)
    {
        if (value) _host = target;
    }

    public static Task<bool> ShowAsync(string title, Control content)
    {
        TaskCompletionSource<bool> tcs = new();

        var vm = new ShowDialogModalViewModel
        {
            Title = title,
            Content = content,
            AcceptCommand = new RelayCommand(() =>
            {
                Close();
                tcs.TrySetResult(true);
            }),
            CancelCommand = new RelayCommand(() =>
            {
                Close();
                tcs.TrySetResult(false);
            })
        };

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            if (content.DataContext is BaseViewModel dvm) dvm.Load();

            Open(new ShowDialogModal(), vm);
        });

        return tcs.Task;
    }

    public static Task<bool> ShowAsync(string message)
    {
        var tb = new TextBlock
        {
            MaxWidth = 100,
            TextAlignment = Media.TextAlignment.Left,
            TextWrapping = Media.TextWrapping.Wrap,
            Text = message
        };

        return ShowAsync("Information", tb);
    }
}