using System.Collections.Generic;
using UnityEngine;

public class DistroManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;
    public DistroTransController distroTransController;

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //transition
        actionMap.Add("/distro/transition/do", distroTransController.DoTransition);
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
