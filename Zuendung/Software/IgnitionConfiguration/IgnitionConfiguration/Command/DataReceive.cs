using IgnitionConfiguration.Connection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IgnitionConfiguration.Command;

public class DataReceive
{
    private readonly IConnection _connection;
    private readonly ViewModel _viewModel;
    private CancellationToken _cancellationToken;
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    public DataReceive(ViewModel viewModel, IConnection connection)
    {
        _connection = connection;
        _viewModel = viewModel;
        _cancellationToken = new();
        _cancellationToken.ThrowIfCancellationRequested();

        _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(_cancellationToken);
        Task.Run(SerialPortStreamDataReceived);

    }

    ~DataReceive() 
    {
        _cancellationTokenSource.Cancel();
    }

    private async Task SerialPortStreamDataReceived()
    {
        try
        {
            int bytesToRead = 0;
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                if((bytesToRead = _connection.SerialPortStream.BytesToRead) == 7)
                {
                    byte[] data = new byte[bytesToRead];
                    _connection.SerialPortStream.Read(data, 0, bytesToRead);
                    _viewModel.SelectedRelayInverted = data[0] == 0 ? "false" : "true";
                    _viewModel.ISet = (((data[1]) << 8) + data[2]).ToString();
                    _viewModel.IgnitionOffValue = (((data[3]) << 8) + data[4]).ToString();
                    _viewModel.IgnitionOnValue = (((data[5]) << 8) + data[6]).ToString();
                    _connection.SerialPortStream.Flush();
                }
                else if((bytesToRead = _connection.SerialPortStream.BytesToRead) > 1)
                {
                    byte[] data = new byte[bytesToRead];
                    _connection.SerialPortStream.Read(data, 0, bytesToRead);
                }

                await Task.Delay(10);
            }
        }
        catch
        {
            _connection.Close();
            Debug.WriteLine("Canceled");
        }

    }
}
