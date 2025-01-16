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
    public DadController dadController;
    public BedroomTransitionManager bedroomTransitionManager;
    public DialogueManager dialogueManager;
    public CameraManager cameraManager;
    public DadControllerParent dadControllerParent;
    public RumbleController rumbleController;
    public LampController lampController;
    public BedroomCameraController bedroomCameraController;

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //New Camera
        actionMap.Add("/bedroom/cam/start", bedroomCameraController.StartGameAnimation);
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
        //Dad
        actionMap.Add("/bedroom/dad/walk", dadController.Walk);
        actionMap.Add("/bedroom/dad/talk", dadController.Talk);
        actionMap.Add("/bedroom/dad/wave", dadController.Wave);
        actionMap.Add("/bedroom/dad/dance", dadController.Dance);
        actionMap.Add("/bedroom/dad/idle", dadController.Idle);
        actionMap.Add("/bedroom/dad/reset", dadControllerParent.ResetDad);
        actionMap.Add("/bedroom/dad/moveOne", dadControllerParent.MoveOne);
        actionMap.Add("/bedroom/dad/moveToPC", dadControllerParent.MoveTwo);
        //Dialogue
        actionMap.Add("/bedroom/dialogue/next", dialogueManager.NextDialogue);
        actionMap.Add("/bedroom/dialogue/previous", dialogueManager.PreviousDialogue);
        actionMap.Add("/bedroom/dialogue/show", dialogueManager.ShowDialogue);
        actionMap.Add("/bedroom/dialogue/hide", dialogueManager.HideDialogue);
        //Transition
        actionMap.Add("/bedroom/transition/do", bedroomTransitionManager.DoTransition);
        actionMap.Add("/bedroom/transition/park", bedroomTransitionManager.ParkTransition);
        //Lamp
        actionMap.Add("/bedroom/lamp/on", lampController.TurnOnLamp);
        actionMap.Add("/bedroom/lamp/off", lampController.TurnOffLamp);
        //RumbleEffect
        actionMap.Add("/effect/rumble/on", rumbleController.PlayRumble);
        /*
        //Camera
        actionMap.Add("/bedroom/camera/one", cameraManager.ShowCameraOne);
        actionMap.Add("/bedroom/camera/two", cameraManager.ShowCameraTwo);
        actionMap.Add("/bedroom/camera/three", cameraManager.ShowCameraThree);
        actionMap.Add("/bedroom/camera/four", cameraManager.ShowCameraFour);
        */
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
