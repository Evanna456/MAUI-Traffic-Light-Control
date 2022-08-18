using System;
using MAUI_Traffic_Light_Control.Helpers.Network.Bluetooth;

namespace MAUI_Traffic_Light_Control;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void turnOnTrafficLight(object sender, EventArgs e)
	{
        const string ArduinoBluetoothTransceiverName = "HC-05";
        var connector = DependencyService.Get<IBluetoothConnector>();
        var ConnectedDevices = connector.GetConnectedDevices();
        var arduino = ConnectedDevices.FirstOrDefault(d => d == ArduinoBluetoothTransceiverName);
        connector.Connect(arduino);
    }
}

