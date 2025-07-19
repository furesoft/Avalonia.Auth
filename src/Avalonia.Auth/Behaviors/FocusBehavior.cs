using Avalonia.Controls;
using Avalonia.Xaml.Interactivity;

namespace Avalonia.Auth.Behaviors;

public class FocusBehavior : Behavior<Control>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject!.AttachedToVisualTree += AssociatedObject_AttachedToVisualTree;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject!.AttachedToVisualTree -= AssociatedObject_AttachedToVisualTree;
    }

    private void AssociatedObject_AttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        AssociatedObject!.Focus();
    }
}