using UnityEngine;
using extOSC;

public class osctest : MonoBehaviour
{
    public OSCReceiver receiver;

    void Start()
    {
        receiver.Bind("/button/click", OnButtonClick);
    }

    void OnButtonClick(OSCMessage message)
    {

    }
}
