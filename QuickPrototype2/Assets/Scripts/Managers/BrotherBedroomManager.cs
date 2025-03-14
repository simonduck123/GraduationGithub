using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherBedroomManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;
    public BrotherParentController brotherParentController;
    public TimelineManagerBrother timelineManagerBrother;

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //Brother
        actionMap.Add("/brotherRoom/brother/slam", brotherParentController.BrotherSlam);
        actionMap.Add("/brotherRoom/brother/standToFight", brotherParentController.BrotherStandToFight);
        actionMap.Add("/brotherRoom/brother/idleFight", brotherParentController.BrotherIdleFight);
        actionMap.Add("/brotherRoom/brother/fightToStand", brotherParentController.BrotherFightToStand);
        actionMap.Add("/brotherRoom/brother/walk", brotherParentController.BrotherWalk);
        actionMap.Add("/brotherRoom/brother/getHit", brotherParentController.BrotherGetHit);
        actionMap.Add("/brotherRoom/brother/nod", brotherParentController.BrotherNod);
        actionMap.Add("/brotherRoom/brother/rightHook", brotherParentController.BrotherRightHook);
        actionMap.Add("/brotherRoom/brother/zombiePunch", brotherParentController.BrotherZombiePunch);
        //transition
        actionMap.Add("/brotherRoom/transition/do", timelineManagerBrother.PlayTimeline);
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
