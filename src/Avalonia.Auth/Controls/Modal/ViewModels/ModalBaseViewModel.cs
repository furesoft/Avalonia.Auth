using System.Windows.Input;
using Avalonia.Auth.Core;

namespace Avalonia.Auth.Controls.Modal.ViewModels;

public class ModalBaseViewModel : BaseViewModel
{
    public ICommand AcceptCommand { get; set; }
    public ICommand CancelCommand { get; set; }
}