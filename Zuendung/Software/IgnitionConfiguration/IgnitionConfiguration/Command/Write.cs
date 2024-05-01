using IgnitionConfiguration.Connection;
using System.Windows.Input;

namespace IgnitionConfiguration.Command;

internal class Write : CommandBase
{
    private readonly IConnection _connection;
    private readonly ViewModel _viewModel1;
    public Write(ViewModel viewModel, IConnection connection)
    {
        _connection = connection;
        _viewModel1 = viewModel;    
    }

    public override void Execute(object? parameter)
    {
        Mouse.OverrideCursor = Cursors.Wait;
        Task.Run(WriteData);
        Mouse.OverrideCursor = null;
    }

    private async Task WriteData()
    {
        await Task.Delay(200);

        ushort relayInverted = _viewModel1.SelectedRelayInverted == "true" ? (ushort)1 : (ushort)0;
        _connection.Write(ToByteArray(relayInverted, '1'));
        await Task.Delay(300);
        ushort iSet = Convert.ToUInt16(_viewModel1.ISet);
        _connection.Write(ToByteArray(iSet, '2'));
        await Task.Delay(300);
        ushort fetOff = Convert.ToUInt16(_viewModel1.IgnitionOffValue);
        _connection.Write(ToByteArray(fetOff, '3'));
        await Task.Delay(300);
        ushort fetOn = Convert.ToUInt16(_viewModel1.IgnitionOnValue);
        _connection.Write(ToByteArray(fetOn, '4'));
        await Task.Delay(300);
        ushort save = 0;
        _connection.Write(ToByteArray(save, '5'));

    }


    private char[] ToByteArray(ushort data, char address)
    {
        char[] result = ['#', '!', address, (char)(data >> 8), (char)(data & 0xFF)];
        Task.Delay(100);
        return result;
    }


}
