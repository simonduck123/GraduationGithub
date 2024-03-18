using UnityEngine;
using extOSC;

public class OSCManager : MonoBehaviour
{
    public int ReceivePort = 7000;
    public BedroomSceneManager bedroomSceneManager;  // Assign in the Inspector
    public ParkSceneManager parkSceneManager;
    public MultipleDimensionSceneManager multiDimensionSceneManager;
    public NewParkManager NewParkManager;
    public OSCReceiver receiver;
    public OSCTransmitter transmitter;

    void Start()
    {
        receiver.LocalPort = ReceivePort;
        #region Bedroom
        //Fridge
        receiver.Bind("/bedroom/fridge/open", OpenFridge);
        receiver.Bind("/bedroom/fridge/close", CloseFridge);
        //Can
        receiver.Bind("/bedroom/can/appear", MakeCanAppear);
        receiver.Bind("/bedroom/can/disappear", MakeCanDisappear);
        //Computer
        receiver.Bind("/bedroom/computer/on", ComputerOn);
        receiver.Bind("/bedroom/computer/off", ComputerOff);
        //Door
        receiver.Bind("/bedroom/door/open", OpenDoor);
        receiver.Bind("/bedroom/door/close", CloseDoor);
        receiver.Bind("/bedroom/door/knock", PlayKnockSound);
        receiver.Bind("/bedroom/door/loudknock", PlayLoudKnockSound);
        //Dad
        receiver.Bind("/bedroom/dad/walk", WalkInside);
        receiver.Bind("/bedroom/dad/reset", ResetDad);
        receiver.Bind("/bedroom/dad/throw", ThrowKevin);
        //Dialogue
        receiver.Bind("/bedroom/dialogue/show", ShowDialogue);
        receiver.Bind("/bedroom/dialogue/hide", HideDialogue);
        receiver.Bind("/bedroom/dialogue/next", DialogueNext);
        receiver.Bind("/bedroom/dialogue/previous", DialoguePrevious);
        //Transition
        receiver.Bind("/bedroom/transition/appear", DoBedroomTransition);
        receiver.Bind("/bedroom/transition/disappear", UndoBedroomTransition);
        /*
        //Cameras
        receiver.Bind("/bedroom/camera/one", CamOne);
        receiver.Bind("/bedroom/camera/two", CamTwo);
        receiver.Bind("/bedroom/camera/three", CamThree);
        receiver.Bind("/bedroom/camera/four", CamFour);
        */
        #endregion
        #region Park
        //Flock
        receiver.Bind("/park/flock/on", TurnOffFlock);
        receiver.Bind("/park/flock/off", TurnOnFlock);
        //Lara
        receiver.Bind("/park/lara/enter", LaraEnter);
        receiver.Bind("/park/lara/reset", LaraResetPos);
        receiver.Bind("/park/lara/dialogue", LaraDialogueOne);
        receiver.Bind("/park/lara/dialogue2", LaraDialogueTwo);
        //Table
        receiver.Bind("/park/table/appear", TableAppear);
        receiver.Bind("/park/table/disappear", TableDisappear);
        //Transition
        receiver.Bind("/park/transition/on", DoParkTransition);
        receiver.Bind("/park/transition/off", UndoParkTransition);
        //Orb
        receiver.Bind("/park/orb/on", OrbAppear);
        receiver.Bind("/park/orb/off", OrbDisappear);
        #endregion
        #region Dimension
        //RightDoor
        receiver.Bind("/dimension/rightdoor/mountain/open", OpenMountainDoor);
        receiver.Bind("/dimension/rightdoor/close", CloseDimensionDoor);
        receiver.Bind("/dimension/rightdoor/park/open", OpenParkDoor);
        //LeftDoor
        receiver.Bind("/dimension/leftdoor/open", OpenLeftDoor);
        receiver.Bind("/dimension/leftdoor/close", CloseLeftDoor);
        //Transition
        receiver.Bind("/dimension/transition/do", DoDimensionTransition);
        receiver.Bind("/dimension/transition/undo", UndoDimensionTransition);

        #endregion
        #region NewPark
        //Mom
        receiver.Bind("/newpark/lara/appear", NewParkLaraAppear);
        receiver.Bind("/newpark/lara/disappear", NewParkLaraDisappear);
        //Aunt
        receiver.Bind("/newpark/aunt/appear", NewParkAuntAppear);
        receiver.Bind("/newpark/aunt/disappear", NewParkAuntDisappear);

        #endregion
    }
    #region Bedroom Functions
    //Camera
    /*
    private void CamOne(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/camera/one");
    }
    private void CamTwo(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/camera/two");
    }
    private void CamThree(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/camera/three");
    }
    private void CamFour(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/camera/four");
    }
    */
    //Fridge
    private void OpenFridge(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/camera/one");
    }

    private void CloseFridge(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/fridge/close");
    }

    //Can
    private void MakeCanAppear(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/can/appear");
    }

    private void MakeCanDisappear(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/can/disappear");
    }

    //Computer
    private void ComputerOn(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/computer/on");
    }

    private void ComputerOff(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/computer/off");
    }

    //Door
    private void OpenDoor(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/door/open");
    }

    private void CloseDoor(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/door/close");
    }

    private void PlayKnockSound(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/door/knock");
    }

    private void PlayLoudKnockSound(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/door/loudknock");
    }

    //Dad
    private void WalkInside(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/dad/walk");
    }

    private void ResetDad(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/dad/reset");
    }

    private void ThrowKevin(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/dad/throw");
    }

    //Dialogue
    private void DialogueNext(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/dialogue/next");
    }

    private void DialoguePrevious(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/dialogue/previous");
    }

    private void ShowDialogue(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/dialogue/show");
    }

    private void HideDialogue(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/dialogue/hide");
    }

    //Transition
    private void DoBedroomTransition(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/transition/appear");
    }
    private void UndoBedroomTransition(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/transition/disappear");
    }
    #endregion
    #region Park Functions
    //Flock
    private void TurnOffFlock(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/flock/off");
    }
    private void TurnOnFlock(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/flock/on");
    }
    //Lara
    private void LaraEnter(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/lara/enter");
    }
    private void LaraResetPos(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/lara/reset");
    }
    private void LaraDialogueOne(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/lara/dialogue");
    }
    private void LaraDialogueTwo(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/lara/dialogue2");
    }
    //Table
    private void TableAppear(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/table/appear");
    }
    private void TableDisappear(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/table/disappear");
    }
    //Transition
    private void DoParkTransition(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/transition/on");
    }
    private void UndoParkTransition(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/transition/off");
    }
    //Orb
    private void OrbAppear(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/orb/on");
    }
    private void OrbDisappear(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/orb/off");
    }
    #endregion
    #region Dimension Functions
    //RightDoor
    private void OpenMountainDoor(OSCMessage message)
    {
        multiDimensionSceneManager.HandleAction("/dimension/rightdoor/mountain/open");
    }
    private void CloseDimensionDoor(OSCMessage message)
    {
        multiDimensionSceneManager.HandleAction("/dimension/rightdoor/close");
    }
    private void OpenParkDoor(OSCMessage message)
    {
        multiDimensionSceneManager.HandleAction("/dimension/rightdoor/park/open");
    }
    //LeftDoor
    private void OpenLeftDoor(OSCMessage message)
    {
        multiDimensionSceneManager.HandleAction("/dimension/leftdoor/open");
    }
    private void CloseLeftDoor(OSCMessage message)
    {
        multiDimensionSceneManager.HandleAction("/dimension/leftdoor/close");
    }
    //Transition
    private void DoDimensionTransition(OSCMessage message)
    {
        multiDimensionSceneManager.HandleAction("/dimension/transition/do");
    }
    private void UndoDimensionTransition(OSCMessage message)
    {
        multiDimensionSceneManager.HandleAction("/dimension/transition/undo");
    }
    #endregion
    #region New Park Functions
    //Mom
    private void NewParkLaraAppear(OSCMessage message)
    {
        NewParkManager.HandleAction("/newpark/lara/appear");
    }
    private void NewParkLaraDisappear(OSCMessage message)
    {
        NewParkManager.HandleAction("/newpark/lara/disappear");
    }
    //Aunt
    private void NewParkAuntAppear(OSCMessage message)
    {
        NewParkManager.HandleAction("/newpark/aunt/appear");
    }
    private void NewParkAuntDisappear(OSCMessage message)
    {
        NewParkManager.HandleAction("/newpark/aunt/disappear");
    }
    #endregion
}
