using UnityEngine;
using extOSC;

public class OSCManager : MonoBehaviour
{
    public int ReceivePort = 7001;
    public BedroomSceneManager bedroomSceneManager;
    public ParkSceneManager parkSceneManager;
    public MultipleDimensionSceneManager multiDimensionSceneManager;
    public NewParkManager NewParkManager;
    public BeachManager beachManager;
    public BrotherBedroomManager brotherBedroomManager;
    public DistroManager distroManager;
    public SceneHandler sceneHandler;
    public OSCReceiver receiver;
    public OSCTransmitter transmitter;

    void Start()
    {
        receiver.LocalPort = ReceivePort;
        #region SceneHandler
        //scene
        receiver.Bind("/scene/bedroom", SwitchSceneOne);
        receiver.Bind("/scene/beach", SwitchSceneTwo);
        receiver.Bind("/scene/distro", SwitchSceneThree);
        //receiver.Bind("/scene/four", SwitchSceneFour);
        #endregion
        #region Bedroom
        receiver.Bind("/reset", ResetScene);
        //Lights

        receiver.Bind("/bedroom/lights/do", LightsDo); ;
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
        receiver.Bind("/bedroom/lamp/do", LampOn);
        //Bed Lamp
        receiver.Bind("/bedroom/bed/lamp/do", BedLampOn);
        //NewCamera
        receiver.Bind("/bedroom/cam/start", DoStartTransition);
        //video
        receiver.Bind("/bedroom/video/next", NextVideo);
        //curtain
        receiver.Bind("/bedroom/curtain/do", CurtainDo);
        #endregion
        #region Beach
        //Timeline Start
        receiver.Bind("/beach/cam/start", PlayTimelineOne);
        receiver.Bind("/beach/cam/restart", RestartTimelineOne);
        receiver.Bind("/beach/cam/pause", PauseTimelineOne);
        receiver.Bind("/beach/cam/skip", SkipTimelineOne);
        receiver.Bind("/beach/sunset/do", SunsetDo);
        #endregion
        #region Distro
        //animation
        receiver.Bind("/distro/bull/idle", BullIdle);
        receiver.Bind("/distro/bull/walk", BullWalk);
        receiver.Bind("/distro/bull/laugh", BullLaugh);
        receiver.Bind("/distro/bull/yell", BullYell);
        receiver.Bind("/distro/bull/roar", BullRoar);
        //transition
        receiver.Bind("/distro/transition/do", TransitionDistro);
        //bullMove
        receiver.Bind("/distro/bull/do", BullMove);
        #endregion
        #region Brother Bedroom
        //Brother
        receiver.Bind("/brotherRoom/brother/slam", BrotherSlam);
        receiver.Bind("/brotherRoom/brother/standToFight", BrotherStandToFight);
        receiver.Bind("/brotherRoom/brother/idleFight", BrotherIdleFight);
        receiver.Bind("/brotherRoom/brother/fightToStand", BrotherFightToStand);
        receiver.Bind("/brotherRoom/brother/walk", BrotherWalk);
        receiver.Bind("/brotherRoom/brother/getHit", BrotherGetHit);
        receiver.Bind("/brotherRoom/brother/nod", BrotherNod);
        receiver.Bind("/brotherRoom/brother/rightHook", BrotherRightHook);
        receiver.Bind("/brotherRoom/brother/zombiePunch", BrotherZombiePunch);
        //transition
        receiver.Bind("/brotherRoom/transition/do", TransitionDoBrotherRoom);
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
    #region Scene Functions
    //Scene
    private void SwitchSceneOne(OSCMessage message)
    {
        sceneHandler.HandleAction("/scene/bedroom");
    }
    private void SwitchSceneTwo(OSCMessage message)
    {
        sceneHandler.HandleAction("/scene/beach");
    }
    private void SwitchSceneThree(OSCMessage message)
    {
        sceneHandler.HandleAction("/scene/distro");
    }
    private void SwitchSceneFour(OSCMessage message)
    {
        sceneHandler.HandleAction("/scene/four");
    }
    #endregion
    #region Bedroom Functions
    //Curtain
    private void CurtainDo(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/curtain/do");
    }
    //video
    private void NextVideo(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/video/next");
    }
    //lights

    private void LightsDo(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/lights/do");
    }

    //New Camera


    private void ResetScene(OSCMessage message)
    {
        sceneHandler.HandleAction("/reset");
    }

    private void DoStartTransition(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/cam/start");
    }

    //Lamp
    private void LampOn(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/lamp/do");
    }
    //Lamp Bed
    private void BedLampOn(OSCMessage message)
    {
        bedroomSceneManager.HandleAction("/bedroom/bed/lamp/do");
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
    #region Beach Functions
    private void PlayTimelineOne(OSCMessage message)
    {
        beachManager.HandleAction("/beach/cam/start");
    }
    private void RestartTimelineOne(OSCMessage message)
    {
        beachManager.HandleAction("/beach/cam/restart");
    }
    private void PauseTimelineOne(OSCMessage message)
    {
        beachManager.HandleAction("/beach/cam/pause");
    }
    private void SkipTimelineOne(OSCMessage message)
    {
        beachManager.HandleAction("/beach/cam/skip");
    }
    private void SunsetDo(OSCMessage message)
    {
        beachManager.HandleAction("/beach/sunset/do");
    }
    #endregion
    #region Distro Functions
    //bullMove
    private void BullMove(OSCMessage message)
    {
        distroManager.HandleAction("/distro/bull/do");
    }
    //Transition
    private void TransitionDistro(OSCMessage message)
    {
        distroManager.HandleAction("/distro/transition/do");
    }
    //animation
    private void BullIdle(OSCMessage message)
    {
        distroManager.HandleAction("/distro/bull/idle");
    }
    private void BullWalk(OSCMessage message)
    {
        distroManager.HandleAction("/distro/bull/walk");
    }
    private void BullLaugh(OSCMessage message)
    {
        distroManager.HandleAction("/distro/bull/laugh");
    }
    private void BullYell(OSCMessage message)
    {
        distroManager.HandleAction("/distro/bull/yell");
    }
    private void BullRoar(OSCMessage message)
    {
        distroManager.HandleAction("/distro/bull/roar");
    }
    #endregion
    #region BrotherRoom Functions
    //transition
    private void TransitionDoBrotherRoom(OSCMessage message)
    {
        brotherBedroomManager.HandleAction("/brotherRoom/transition/do");
    }
    private void BrotherSlam(OSCMessage message)
    {
        brotherBedroomManager.HandleAction("/brotherRoom/brother/slam");
    }
    private void BrotherStandToFight(OSCMessage message)
    {
        brotherBedroomManager.HandleAction("/brotherRoom/brother/standToFight");
    }
    private void BrotherIdleFight(OSCMessage message)
    {
        brotherBedroomManager.HandleAction("/brotherRoom/brother/idleFight");
    }
    private void BrotherFightToStand(OSCMessage message)
    {
        brotherBedroomManager.HandleAction("/brotherRoom/brother/fightToStand");
    }
    private void BrotherWalk(OSCMessage message)
    {
        brotherBedroomManager.HandleAction("/brotherRoom/brother/walk");
    }
    private void BrotherGetHit(OSCMessage message)
    {
        brotherBedroomManager.HandleAction("/brotherRoom/brother/getHit");
    }
    private void BrotherNod(OSCMessage message)
    {
        brotherBedroomManager.HandleAction("/brotherRoom/brother/nod");
    }
    private void BrotherRightHook(OSCMessage message)
    {
        brotherBedroomManager.HandleAction("/brotherRoom/brother/rightHook");
    }
    private void BrotherZombiePunch(OSCMessage message)
    {
        brotherBedroomManager.HandleAction("/brotherRoom/brother/zombiePunch");
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
