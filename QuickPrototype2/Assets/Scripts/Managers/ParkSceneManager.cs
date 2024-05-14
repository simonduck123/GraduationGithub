using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkSceneManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;
    public FlockController flockController;
    public LaraCroftController laraCroftController;
    public TableController tableController;
    public ParkTransitionController parkTransitionController;
    public OrbController orbController;
    public LeftDoorController leftDoorController;
    public RightDoorController rightDoorController;
    public MomController momController;

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //Mom
        actionMap.Add("/mom/animation/idle", momController.Idle);
        actionMap.Add("/mom/animation/talk", momController.Talk);
        actionMap.Add("/mom/animation/standTalk", momController.StandTalk);
        actionMap.Add("/mom/animation/talkPhone", momController.TalkPhone);
        actionMap.Add("/mom/animation/textWalk", momController.TextWalk);
        /*
        //Bird Flock
        actionMap.Add("/park/flock/on", flockController.TurnOnFlock);
        actionMap.Add("/park/flock/off", flockController.TurnOffFlock);
        //Lara Croft
        actionMap.Add("/park/lara/enter", laraCroftController.LaraEnter);
        actionMap.Add("/park/lara/reset", laraCroftController.LaraResetPos);
        actionMap.Add("/park/lara/dialogue", laraCroftController.LaraDialogueOne);
        actionMap.Add("/park/lara/dialogue2", laraCroftController.LaraDialogueTwo);
        //Table
        actionMap.Add("/park/table/appear", tableController.TableAppear);
        actionMap.Add("/park/table/disappear", tableController.TableDisappear);
        //Transition
        //actionMap.Add("/park/transition/on", parkTransitionController.DoTransition);
        //actionMap.Add("/park/transition/off", parkTransitionController.UndoTransition);
        //Orb
        actionMap.Add("/park/orb/on", orbController.OrbAppear);
        actionMap.Add("/park/orb/off", orbController.OrbDisappear);
        //Fire Door
        actionMap.Add("/park/door/fire/open", leftDoorController.OpenDoor);
        actionMap.Add("/park/door/fire/close", leftDoorController.CloseDoor);
        //Ice Door
        actionMap.Add("/park/door/ice/open", rightDoorController.OpenDoor);
        actionMap.Add("/park/door/ice/close", rightDoorController.CloseDoor);
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
