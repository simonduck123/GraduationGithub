using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParkManager : MonoBehaviour
{
    private Dictionary<string, System.Action> actionMap;
    public NewParkLaraController newParkLaraController;
    public NewParkAuntController newParkAuntController;


    void Start()
    {
        actionMap = new Dictionary<string, System.Action>();
        //Mom
        actionMap.Add("/newpark/lara/appear", newParkLaraController.LaraAppear);
        actionMap.Add("/newpark/lara/disappear", newParkLaraController.LaraDisappear);
        //Aunt
        actionMap.Add("/newpark/aunt/appear", newParkAuntController.AuntAppear);
        actionMap.Add("/newpark/aunt/disappear", newParkAuntController.AuntDisappear);

    }

    public void HandleAction(string address)
    {
        if (actionMap.ContainsKey(address))
        {
            actionMap[address]();
        }
    }
}
