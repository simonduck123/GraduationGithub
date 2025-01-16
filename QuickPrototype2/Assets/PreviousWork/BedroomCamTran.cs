using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomCamTran : MonoBehaviour
{
    public GameObject cameraManager;

    public void EndTransitionCam()
    {
        cameraManager.GetComponent<CameraManager>().SwitchNextCamera();
    }
}
