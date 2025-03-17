using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomSceneManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;
    public FridgeController fridgeController;
    public CanController canController;
    public ComputerController computerController;
    public DoorController doorController;
    //public DadController dadController;
    public BedroomTransitionController bedroomTransitionController;
    //public DialogueManager dialogueManager;
    //public CameraManager cameraManager;
    //public DadControllerParent dadControllerParent;
    public MomController momController;
    public MomParentController momParentController;
    public RumbleController rumbleController;
    public LampController lampController, bedLampController;
    public BedroomCameraController bedroomCameraController;
    public LightController lightController;
    public VideoSwitcher videoSwitcher;

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //lights
        actionMap.Add("/bedroom/lights/do", lightController.DoLights);
        //New Camera
        actionMap.Add("/bedroom/cam/start", bedroomCameraController.StartGameAnimation);
        actionMap.Add("/reset", bedroomCameraController.ResetBedroomScene);
        //Fridge
        actionMap.Add("/bedroom/fridge/open", fridgeController.OpenFridge);
        actionMap.Add("/bedroom/fridge/close", fridgeController.CloseFridge);
        //Can
        actionMap.Add("/bedroom/can/appear", canController.MakeCanAppear);
        actionMap.Add("/bedroom/can/disappear", canController.MakeCanDisappear);
        //Computer
        actionMap.Add("/bedroom/computer/on", computerController.PlayVideo);
        actionMap.Add("/bedroom/computer/off", computerController.StopVideoPlayer);
        //Door
        actionMap.Add("/bedroom/door/open", doorController.Open);
        actionMap.Add("/bedroom/door/close", doorController.Close);
        actionMap.Add("/bedroom/door/knock", doorController.Knock);
        actionMap.Add("/bedroom/door/loudknock", doorController.LoudKnock);
        //Mom
        actionMap.Add("/bedroom/mom/walk", momController.Walk);
        actionMap.Add("/bedroom/mom/talk", momController.Talk);
        actionMap.Add("/bedroom/mom/standTalk", momController.StandTalk);
        actionMap.Add("/bedroom/mom/talkPhone", momController.TalkPhone);
        actionMap.Add("/bedroom/mom/idle", momController.Idle);
        actionMap.Add("/bedroom/mom/textWalk", momController.TextWalk);
        actionMap.Add("/bedroom/mom/reset", momParentController.ResetMom);
        actionMap.Add("/bedroom/mom/moveOne", momParentController.MoveOne);
        actionMap.Add("/bedroom/mom/moveToPC", momParentController.MoveTwo);

        //Transition
        actionMap.Add("/bedroom/transition/do", bedroomTransitionController.DoTransition);
        //actionMap.Add("/bedroom/transition/park", bedroomTransitionManager.ParkTransition);
        //Lamp
        actionMap.Add("/bedroom/lamp/on", lampController.TurnOnLamp);
        actionMap.Add("/bedroom/lamp/off", lampController.TurnOffLamp);
        //Lamp bed
        actionMap.Add("/bedroom/bed/lamp/on", bedLampController.TurnOnLamp);
        actionMap.Add("/bedroom/bed/lamp/off", bedLampController.TurnOffLamp);
        //RumbleEffect
        actionMap.Add("/effect/rumble/on", rumbleController.PlayRumble);
        //videoSwap
        actionMap.Add("/bedroom/video/next", videoSwitcher.SwapVideo);

    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
