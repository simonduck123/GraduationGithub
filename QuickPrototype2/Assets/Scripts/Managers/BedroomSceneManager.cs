using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomSceneManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //Fridge
        actionMap.Add("/fridge/open", FindObjectOfType<FridgeController>().OpenFridge);
        actionMap.Add("/fridge/close", FindObjectOfType<FridgeController>().CloseFridge);
        //Can
        actionMap.Add("/can/appear", FindObjectOfType<CanController>().MakeCanAppear);
        actionMap.Add("/can/disappear", FindObjectOfType<CanController>().MakeCanDisappear);
        //Computer
        actionMap.Add("/computer/on", FindObjectOfType<ComputerController>().TurnOnComputer);
        actionMap.Add("/computer/off", FindObjectOfType<ComputerController>().TurnOffComputer);
        //Door
        actionMap.Add("/door/open", FindObjectOfType<DoorController>().OpenDoor);
        actionMap.Add("/door/close", FindObjectOfType<DoorController>().CloseDoor);
        actionMap.Add("/door/knock", FindObjectOfType<DoorController>().PlayKnockSound);
        actionMap.Add("/door/loudknock", FindObjectOfType<DoorController>().PlayLoudKnockSound);
        //Dad
        actionMap.Add("/dad/walk", FindObjectOfType<DadController>().WalkInside);
        actionMap.Add("/dad/reset", FindObjectOfType<DadController>().ResetDad);
        actionMap.Add("/dad/throw", FindObjectOfType<DadController>().ThrowKevin);
        actionMap.Add("/dad/dialogue", FindObjectOfType<DadController>().Dialogue);
        actionMap.Add("/dad/pcoff", FindObjectOfType<DadController>().TurnPCOff);
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
