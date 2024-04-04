using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleDimensionSceneManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;
    public RightDoorController rightDoorController;
    public LeftDoorController leftDoorController;
    public TransitionDimensionController transitionDimensionController;
    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //RightDoor
        //actionMap.Add("/dimension/rightdoor/mountain/open", rightDoorController.OpenMountainDoor);
        actionMap.Add("/dimension/rightdoor/close", rightDoorController.CloseDoor);
        //actionMap.Add("/dimension/rightdoor/park/open", rightDoorController.OpenParkDoor);
        //LeftDoor
        actionMap.Add("/dimension/leftdoor/open", leftDoorController.OpenDoor);
        actionMap.Add("/dimension/leftdoor/close", leftDoorController.CloseDoor);
        //Transition
        actionMap.Add("/dimension/transition/do", transitionDimensionController.DoTransition);
        actionMap.Add("/dimension/transition/undo", transitionDimensionController.UndoTransition);
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
