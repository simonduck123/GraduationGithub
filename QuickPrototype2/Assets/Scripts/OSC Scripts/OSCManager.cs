using UnityEngine;
using extOSC;

public class OSCManager : MonoBehaviour
{
    public int ReceivePort = 7001;
    public BedroomSceneManager bedroomSceneManager; 
    public ParkSceneManager parkSceneManager;
    public MultipleDimensionSceneManager multiDimensionSceneManager;
    public NewParkManager NewParkManager;
    public OSCReceiver receiver;
    public OSCTransmitter transmitter;

    void Start()
    {
        receiver.LocalPort = ReceivePort;
        #region Effects
        //Rumble
        receiver.Bind("/effect/rumble/on", StartRumble);
        #endregion
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
        
        receiver.Bind("/bedroom/mom/walk", Walk);
        receiver.Bind("/bedroom/mom/reset", MomReset);
        receiver.Bind("/bedroom/mom/talk", Talk);
        receiver.Bind("/bedroom/mom/standTalk", StandTalk);
        receiver.Bind("/bedroom/mom/textWalk", TextWalk);
        receiver.Bind("/bedroom/mom/idle", Idle);
        receiver.Bind("/bedroom/mom/talkPhone", TalkPhone);

        receiver.Bind("/bedroom/mom/moveOne", MoveOne);
        receiver.Bind("/bedroom/mom/moveToPC", MoveTwo);

        //Transition
        receiver.Bind("/bedroom/transition/do", DoBedroomTransition);
        receiver.Bind("/bedroom/transition/park", ParkTransition);
        //Lamp
        receiver.Bind("/bedroom/lamp/on", LampOn);
        receiver.Bind("/bedroom/lamp/off", LampOff);

        //NewCamera
        receiver.Bind("/bedroom/cam/start", DoStartTransition);
        #endregion
        #region Park
        //Flock
        receiver.Bind("/park/flock/on", TurnOnFlock);
        receiver.Bind("/park/flock/off", TurnOffFlock);
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
        //Fire Door
        receiver.Bind("/park/door/fire/open", FireDoorOpen);
        receiver.Bind("/park/door/fire/close", FireDoorClose);
        //Ice Door
        receiver.Bind("/park/door/ice/open", IceDoorOpen);
        receiver.Bind("/park/door/ice/close", IceDoorClose);
        //Mom
        receiver.Bind("/mom/animation/idle", PlayMomIdleAnim);
        receiver.Bind("/mom/animation/talk", PlayMomTalkAnim);
        receiver.Bind("/mom/animation/standTalk", PlayMomStandTalkAnim);
        receiver.Bind("/mom/animation/talkPhone", PlayMomTalkPhoneAnim);
        receiver.Bind("/mom/animation/textWalk", PlayMomTextWalkAnim);
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
    #region Effects Functions
    //Rumble
    private void StartRumble(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/effect/rumble/on");
    }
    #endregion
    #region Bedroom Functions
    //New Camera

    private void DoStartTransition(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/cam/start");
    }

    //Lamp
    private void LampOn(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/lamp/on");
    }

    private void LampOff(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/lamp/off");
    }
    //Fridge
    private void OpenFridge(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/fridge/open");
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

    //Mom
    private void Walk(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/mom/walk");
    }

    private void TextWalk(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/mom/textWalk");
    }

    private void Talk(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/mom/talk");
    }

    private void TalkPhone(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/mom/talkPhone");
    }

    private void StandTalk(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/mom/standTalk");
    }

    private void Idle(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/mom/idle");
    }

    private void MoveOne(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/mom/moveOne");
    }

    private void MoveTwo(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/mom/moveToPC");
    }

    private void MomReset(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/mom/reset");
    }

    //Transition
    private void DoBedroomTransition(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/transition/do");
    }
    private void ParkTransition(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/transition/park");
    }
    #endregion
    #region Park Functions
    //Mom
    private void PlayMomIdleAnim(OSCMessage message)
    {
        parkSceneManager.HandleAction("/mom/animation/idle");
    }
    private void PlayMomTalkAnim(OSCMessage message)
    {
        parkSceneManager.HandleAction("/mom/animation/talk");
    }
    private void PlayMomStandTalkAnim(OSCMessage message)
    {
        parkSceneManager.HandleAction("/mom/animation/standTalk");
    }
    private void PlayMomTalkPhoneAnim(OSCMessage message)
    {
        parkSceneManager.HandleAction("/mom/animation/talkPhone");
    }
    private void PlayMomTextWalkAnim(OSCMessage message)
    {
        parkSceneManager.HandleAction("/mom/animation/textWalk");
    }
    //Fire Door
    private void FireDoorOpen(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/door/fire/open");
    }
    private void FireDoorClose(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/door/fire/close");
    }
    //Ice Door
    private void IceDoorOpen(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/door/ice/open");
    }
    private void IceDoorClose(OSCMessage message)
    {
        parkSceneManager.HandleAction("/park/door/ice/close");
    }
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
