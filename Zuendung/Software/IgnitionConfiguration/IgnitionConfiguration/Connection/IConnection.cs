using RJCP.IO.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgnitionConfiguration.Connection;

public interface IConnection
{
    SerialPortStream SerialPortStream { get; }
    public bool Connect();
    public bool Close();
    public void Write(char[] data);
    public bool IsConnected { get; }
}
