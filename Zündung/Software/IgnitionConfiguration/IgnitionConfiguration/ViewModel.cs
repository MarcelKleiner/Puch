using IgnitionConfiguration.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace IgnitionConfiguration;

public class ViewModel : ViewModelBase
{
    public ViewModel()
    {
        Connect = new Connect();
        Write = new Write();
        Read = new Read();
    }

    public ICommand Connect { get; }
    public ICommand Write { get; }
    public ICommand Read { get; }

    public ObservableCollection<string> ComPorts { get; } = [];
    public ObservableCollection<string> RelayInvertedItems { get; } = ["False", "True"];

    private bool _isComPortOpen;
    public bool IsComPortOpen
    {
        get { return _isComPortOpen; }
        set { _isComPortOpen = value; OnPropertyChanged(nameof(IsComPortOpen)); }
    }

    private string _selectedComPort = "";
    public string SelectedComPort
    {
        get => _selectedComPort;
        set { _selectedComPort = value; OnPropertyChanged(nameof(SelectedComPort)); }
    }

    private string _selectedRelayInverted = "False";
    public string SelectedRelayInverted
    {
        get { return _selectedRelayInverted; }
        set { _selectedRelayInverted = value; OnPropertyChanged(nameof(SelectedRelayInverted)); }
    }



    private string _ISet = "";
    public string ISet
    {
        get => _ISet;
        set { _ISet = value; OnPropertyChanged(nameof(ISet)); }
    }

    private string _IgnitionOnValue = "";
    public string IgnitionOnValue
    {
        get => _IgnitionOnValue;
        set { _IgnitionOnValue = value; OnPropertyChanged(nameof(IgnitionOnValue)); }
    }

    private string _IgnitionOffValue = "";
    public string IgnitionOffValue
    {
        get => _IgnitionOffValue;
        set { _IgnitionOffValue = value; OnPropertyChanged(nameof(IgnitionOffValue)); }
    }

    private void InitComPorts()
    {
        SerialPortStream serialPortStream = new();
    }
}
