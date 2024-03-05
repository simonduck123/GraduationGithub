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
    public BedroomTransitionController bedroomTransitionController;

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //Fridge
        actionMap.Add("/bedroom/fridge/open", fridgeController.OpenFridge);
        actionMap.Add("/bedroom/fridge/close", fridgeController.CloseFridge);
        //Can
        actionMap.Add("/bedroom/can/appear", canController.MakeCanAppear);
        actionMap.Add("/bedroom/can/disappear", canController.MakeCanDisappear);
        //Computer
        actionMap.Add("/bedroom/computer/on", computerController.TurnOnComputer);
        actionMap.Add("/bedroom/computer/off", computerController.TurnOffComputer);
        //Door
        actionMap.Add("/bedroom/door/open", doorController.OpenDoor);
        actionMap.Add("/bedroom/door/close", doorController.CloseDoor);
        actionMap.Add("/bedroom/door/knock", doorController.PlayKnockSound);
        actionMap.Add("/bedroom/door/loudknock", doorController.PlayLoudKnockSound);
        //Dad
        actionMap.Add("/bedroom/dad/walk", dadController.WalkInside);
        actionMap.Add("/bedroom/dad/reset", dadController.ResetDad);
        actionMap.Add("/bedroom/dad/throw", dadController.ThrowKevin);
        actionMap.Add("/bedroom/dad/dialogue", dadController.Dialogue);
        actionMap.Add("/bedroom/dad/pcoff", dadController.TurnPCOff);
        //Transition
        actionMap.Add("/bedroom/transition/appear", bedroomTransitionController.DoTransition);
        actionMap.Add("/bedroom/transition/disappear", bedroomTransitionController.UndoTransition);
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
