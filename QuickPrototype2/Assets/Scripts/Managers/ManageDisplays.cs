using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageDisplays : MonoBehaviour
{
    void Start()
    {
        for(int i = 0; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate(1440, 1080, new RefreshRate() { numerator = 60, denominator = 1 });
        }
    }
}