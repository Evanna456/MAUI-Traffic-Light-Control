using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Hardware.Usb;
using Java.Util;
using MAUI_Traffic_Light_Control.Platforms.Android.Bluetooth;
using MAUI_Traffic_Light_Control.Helpers.Network.Bluetooth;
using Android.Runtime;

[assembly: Dependency(typeof(BluetoothConnector))]
namespace MAUI_Traffic_Light_Control.Platforms.Android.Bluetooth
{
    public class BluetoothConnector : IBluetoothConnector
    {
        /// <summary>
        /// The standard UDID for SSP
        /// </summary>
        string SspUdid = "00001101-0000-1000-8000-00805f9b34fb";
        BluetoothAdapter _adapter;

        /// <inheritdoc />

        public List<string> GetConnectedDevices()
        {
            MainActivity Act = new MainActivity();

            var _bluetoothManager = Act.BluetoothM();

            _adapter = _bluetoothManager.Adapter;

            if (_adapter == null) {
                throw new Exception("No Bluetooth adapter found.");
            }

            if (_adapter.IsEnabled == true)
            {
                if (_adapter.BondedDevices.Count > 0)
                {
                    return _adapter.BondedDevices.Select(d => d.Name).ToList();
                }
            }
            else
            {
                Console.Write("Bluetooth is not enabled on device");
            }
            return new List<string>();
        }

        /// <inheritdoc />
        public void Connect(string deviceName)
        {
            var device = _adapter.BondedDevices.FirstOrDefault(d => d.Name == deviceName);
            var _socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString(SspUdid));
            _socket.Connect();
            if(_socket.IsConnected == true) { 
            byte[] message = Encoding.ASCII.GetBytes("On");
            _socket.OutputStream.WriteAsync(message, 0, message.Length);
            }
        }
    }
}
