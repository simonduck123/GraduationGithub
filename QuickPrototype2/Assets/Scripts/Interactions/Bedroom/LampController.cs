using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public GameObject lightSource;

    public void TurnOnLamp()
    {
        lightSource.SetActive(true);
    }

    public void TurnOffLamp()
    {
        lightSource.SetActive(false);
    }
}
