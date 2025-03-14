using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDisturbManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;

    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
