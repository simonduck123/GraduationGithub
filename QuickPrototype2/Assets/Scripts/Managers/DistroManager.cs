using System.Collections.Generic;
using UnityEngine;

public class DistroManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;
    public BullAnimationController bullAnimationController;
    public DistroTransitionController distroTransitionController;
    public SetBullAnimations parentBullController;

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //animations
        actionMap.Add("/distro/bull/idle", bullAnimationController.BullIdle);
        actionMap.Add("/distro/bull/walk", bullAnimationController.BullWalk);
        actionMap.Add("/distro/bull/laugh", bullAnimationController.BullLaugh);
        actionMap.Add("/distro/bull/yell", bullAnimationController.BullYell);
        actionMap.Add("/distro/bull/roar", bullAnimationController.BullRoar);
        //transition
        actionMap.Add("/distro/transition/do", distroTransitionController.DoTransition);
        //bull
        actionMap.Add("/distro/bull/do", parentBullController.DoTransition);
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
