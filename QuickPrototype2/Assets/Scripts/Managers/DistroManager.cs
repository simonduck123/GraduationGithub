using System.Collections.Generic;
using UnityEngine;

public class DistroManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;
    public BullAnimationController BullAnimationController;

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //animations
        actionMap.Add("/distro/bull/idle", BullAnimationController.BullIdle);
        actionMap.Add("/distro/bull/walk", BullAnimationController.BullWalk);
        actionMap.Add("/distro/bull/laugh", BullAnimationController.BullLaugh);
        actionMap.Add("/distro/bull/yell", BullAnimationController.BullYell);
        actionMap.Add("/distro/bull/roar", BullAnimationController.BullRoar);
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
