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

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
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
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
