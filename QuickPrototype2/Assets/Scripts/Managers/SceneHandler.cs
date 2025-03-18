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
        actionMap.Add("/scene/bedroom", SetSceneZero);
        actionMap.Add("/scene/beach", SetSceneOne);
        actionMap.Add("/scene/distro", SetSceneTwo);
        actionMap.Add("/scene/four", SetSceneThree);
    }

    public void SetSceneZero()
    {
        SceneManager.LoadScene(0);
    }
    public void SetSceneOne()
    {
        SceneManager.LoadScene(1);
    }
    public void SetSceneTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void SetSceneThree()
    {
        SceneManager.LoadScene(3);
    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
