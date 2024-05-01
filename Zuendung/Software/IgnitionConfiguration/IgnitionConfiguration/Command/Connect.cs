using IgnitionConfiguration.Connection;

namespace IgnitionConfiguration.Command;

public class Connect : CommandBase
{
    private readonly ViewModel _viewModel;
    private readonly IConnection _connection;
    private bool _isConnected = false;
    public Connect(ViewModel viewModel, IConnection connection)
    {
        _viewModel = viewModel;
        _connection = connection;
    }


    public override void Execute(object? parameter)
    {
        if (!_isConnected)
        {
            Open();
            _viewModel.ConnectionButtonString = "Verbunden";
            _isConnected = true;
        }
        else
        {
            Close();
            _viewModel.ConnectionButtonString = "Verbinden";
        }
    }

    private bool Open()
    {
        _connection.SerialPortStream.BaudRate = 115200;
        _connection.SerialPortStream.PortName = _viewModel.SelectedComPort;
        return _connection.Connect();
    }

    private bool Close()
    {
        return _connection.Close();
    }
}
