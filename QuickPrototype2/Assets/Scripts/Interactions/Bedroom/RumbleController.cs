using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleController : MonoBehaviour
{
    [SerializeField] private GameObject camOne;
    [SerializeField] private GameObject camTwo;

    public void PlayRumble()
    {
        camOne.GetComponent<ScreenShake>().ShakeCamera();
        camTwo.GetComponent<ScreenShake>().ShakeCamera();
    }
}
