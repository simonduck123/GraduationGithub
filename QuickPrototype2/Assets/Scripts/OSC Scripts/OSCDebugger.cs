using UnityEngine;
using extOSC;

public class OSCDebugger : MonoBehaviour
{
    public OSCReceiver oscReceiver; // Assign in Inspector
    public string oscAddress = "/test"; // Change this to match your OSC message

    private void Start()
    {
        if (oscReceiver == null)
        {
            Debug.LogError("OSC Receiver is not assigned!");
            return;
        }

        // Bind to the OSC address
        oscReceiver.Bind(oscAddress, OnOSCMessageReceived);
        Debug.Log($"Listening for OSC messages on: {oscAddress}");
    }

    private void OnOSCMessageReceived(OSCMessage message)
    {
        Debug.Log($"Received OSC message: {message.Address}");

        foreach (var value in message.Values)
        {
            Debug.Log($"Value: {value}");
        }
    }
}
