using RJCP.IO.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgnitionConfiguration.Connection
{
    class UsbConnection : IConnection
    {
        private readonly SerialPortStream _stream;
        public UsbConnection()
        {
            _stream = new SerialPortStream();
        }

        public SerialPortStream SerialPortStream => _stream;

        public bool IsConnected => _stream.IsOpen;

        public bool Close()
        {
            if(_stream != null && _stream.IsOpen)
            {
                _stream.Close();
                _stream.Dispose();
                return true;
            }
            return false;
        }

        public bool Connect()
        {
            if(_stream == null || _stream.IsOpen)
                return false;
            try
            {
                _stream.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Write(char[] data)
        {
            if (data.Length != 5)
                return;

            _stream.Write(data, 0, data.Length);
        }
    }
}
