namespace Avalonia.Auth.Controls.Modal.ViewModels;

public class ShowDialogModalViewModel : ModalBaseViewModel
{
    private object _content;
    private string _title;

    public object Content
    {
        get => _content;
        set => SetProperty(ref _content, value);
    }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
}