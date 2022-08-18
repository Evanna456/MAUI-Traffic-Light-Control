using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Traffic_Light_Control.Helpers.Network.Bluetooth
{
    public interface IBluetoothConnector
    {
        List<string> GetConnectedDevices();
        void Connect(string deviceName);
    }
}
