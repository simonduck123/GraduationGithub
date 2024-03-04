using UnityEngine;
using extOSC;

public class OSCManager : MonoBehaviour
{
    public int ReceivePort = 7000;
    public BedroomSceneManager bedroomSceneManager;  // Assign in the Inspector

    void Start()
    {
        var receiver = gameObject.AddComponent<OSCReceiver>();
        receiver.LocalPort = ReceivePort;
        //Fridge
        receiver.Bind("/fridge/open", OpenFridge);
        receiver.Bind("/fridge/close", CloseFridge);
        //Can
        receiver.Bind("/can/appear", MakeCanAppear);
        receiver.Bind("/can/disappear", MakeCanDisappear);
        //Computer
        receiver.Bind("/computer/on", ComputerOn);
        receiver.Bind("/computer/off", ComputerOff);
        //Door
        receiver.Bind("/door/open", OpenDoor);
        receiver.Bind("/door/close", CloseDoor);
        receiver.Bind("/door/knock", PlayKnockSound);
        receiver.Bind("/door/loudknock", PlayLoudKnockSound);
        //Dad
        receiver.Bind("/dad/walk", WalkInside);
        receiver.Bind("/dad/reset", ResetDad);
        receiver.Bind("/dad/throw", ThrowKevin);
        receiver.Bind("/dad/dialogue", Dialogue);
        receiver.Bind("/dad/pcoff", TurnPCOff);
    }

    //Fridge
    private void OpenFridge(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/fridge/open");
    }

    private void CloseFridge(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/fridge/close");
    }

    //Can
    private void MakeCanAppear(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/can/appear");
    }

    private void MakeCanDisappear(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/can/disappear");
    }

    //Computer
    private void ComputerOn(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/computer/on");
    }

    private void ComputerOff(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/computer/off");
    }

    //Door
    private void OpenDoor(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/door/open");
    }

    private void CloseDoor(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/door/close");
    }

    private void PlayKnockSound(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/door/knock");
    }

    private void PlayLoudKnockSound(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/door/loudknock");
    }

    //Dad
    private void WalkInside(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/dad/walk");
    }

    private void ResetDad(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/dad/reset");
    }

    private void ThrowKevin(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/dad/throw");
    }

    private void Dialogue(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/dad/dialogue");
    }

    private void TurnPCOff(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/dad/pcoff");
    }
}
