using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject cameraThree;
    public GameObject cameraFour;
    public void ShowCameraOne()
    {
        ClearAllCameras();
        cameraOne.SetActive(true);
    }
    public void ShowCameraTwo()
    {
        ClearAllCameras();
        cameraTwo.SetActive(true);
    }
    public void ShowCameraThree()
    {
        ClearAllCameras();
        cameraThree.SetActive(true);
    }

    public void ShowCameraFour()
    {
        ClearAllCameras();
        cameraFour.SetActive(true);
    }

    private void ClearAllCameras()
    {
        cameraOne.SetActive(false);
        cameraTwo.SetActive(false);
        cameraThree.SetActive(false);
        cameraFour.SetActive(false);
    }

}
