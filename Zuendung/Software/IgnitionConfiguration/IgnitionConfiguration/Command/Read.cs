using IgnitionConfiguration.Connection;
using System.Windows;

namespace IgnitionConfiguration.Command;

public class Read : CommandBase
{
    private readonly IConnection _connection;
    private readonly ViewModel _viewModel1;
    public Read(ViewModel viewModel, IConnection connection)
    {
        _connection = connection;
        _viewModel1 = viewModel;
    }

    public override void Execute(object? parameter)
    {
        if (!_connection.IsConnected)
        {
            MessageBox.Show("not connected");
            return;
        }

        _connection.Write(['#', '!', '0', '0', '0']);
    }
}
