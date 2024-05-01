using System.Windows.Input;

namespace IgnitionConfiguration.Command;

public abstract class CommandBase : ICommand
{
    public event EventHandler? CanExecuteChanged;
    private readonly bool _canExecute = true;

    public bool CanExecute(object? parameter)
    {
        return _canExecute;
    }

    public abstract void Execute(object? parameter);

    protected virtual void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
