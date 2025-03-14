using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public GameObject lightSource;

    public void TurnOnLamp()
    {
        lightSource.SetActive(true);
        Debug.Log("Lamp on");
    }

    public void TurnOffLamp()
    {
        lightSource.SetActive(false);
        Debug.Log("Lamp off");
    }
}
