using UnityEngine;
using extOSC;

public class NewOSCManager : MonoBehaviour
{
    public int ReceivePort = 7002;
    public OSCReceiver receiver;
    public OSCTransmitter transmitter;

    //Managers
    public DoNotDisturbManager doNotDisturbManager;

    void Start()
    {
        receiver.LocalPort = ReceivePort;
    }
}
