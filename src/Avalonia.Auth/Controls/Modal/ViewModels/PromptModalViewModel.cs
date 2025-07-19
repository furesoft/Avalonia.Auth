using System.Windows.Input;
using Avalonia.Auth.Core;

namespace Avalonia.Auth.Controls.Modal.ViewModels;

public class PromptModalViewModel : BaseViewModel
{
    private string _header;
    private string _input;
    private string _watermark;
    public ICommand AcceptCommand { get; set; }
    public ICommand CancelCommand { get; set; }

    public string Header
    {
        get => _header;
        set => SetProperty(ref _header, value);
    }

    public string Input
    {
        get => _input;
        set => SetProperty(ref _input, value);
    }

    public string Watermark
    {
        get => _watermark;
        set => SetProperty(ref _watermark, value);
    }
}