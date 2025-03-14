using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneHandler : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;

    private void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        actionMap.Add("/reset", ResetScene);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Test");
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
