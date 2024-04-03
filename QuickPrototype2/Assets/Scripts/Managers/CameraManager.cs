using extOSC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera[] cameras;
    public float camSpeed = 1f;
    public float rotationSpeed = 10f;
    private int currentCameraIndex = 0;
    private float xPos;
    private float yPos;
    private float zPos;
    private float xRot;
    private float yRot;
    private float zRot;

    [Header("OSC Settings")]
    public OSCReceiver Receiver;


    public void Start()
    {

        foreach (var camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            //LoadCameraPosition(i);
        }
        Receiver.Bind("/camera/position/x", ReceivedX);
        Receiver.Bind("/camera/position/y", ReceivedY);
        Receiver.Bind("/camera/position/z", ReceivedZ);
        Receiver.Bind("/camera/rotation/x", ReceivedXRot);
        Receiver.Bind("/camera/rotation/y", ReceivedYRot);
        Receiver.Bind("/camera/rotation/z", ReceivedZRot);
        Receiver.Bind("/camera/next", NextCamera);
        Receiver.Bind("/camera/previous", PreviousCamera);
        EnableCamera(currentCameraIndex);

        /*

        CustomAnimation customAnimation = new CustomAnimation(GetComponent<Animation>(), new AnimationCurve(), new AnimationClip(), Keyframe[3]);
        // create a new AnimationClip
        clip = new AnimationClip();
        clip.legacy = true;

            Keyframe[] keys;
        keys = new Keyframe[3];
        keys[0] = new Keyframe(0.0f, 0.0f);
        keys[1] = new Keyframe(1.0f, 1.5f);
        keys[2] = new Keyframe(2.0f, 0.0f);
        curve = new AnimationCurve(keys);
        clip.SetCurve("", typeof(Transform), "localPosition.x", curve);
        curve = new AnimationCurve(keys);
        //clip.SetCurve("", typeof(Transform), "localPosition.x", curve);
        clip.SetCurve("", typeof(Transform), "localPosition.y", curve);
        //clip.SetCurve("", typeof(Transform), "localPosition.z", curve);

        clip.name = "UPMovement";
        */
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchNextCamera();
        }

        Camera currentCamera = cameras[currentCameraIndex];
        MoveCamera(currentCamera);
        RotateCamera(currentCamera);

        //SaveCameraPosition(currentCameraIndex);
    }

    public void SwitchNextCamera()
    {
        // Disable the current camera
        cameras[currentCameraIndex].gameObject.SetActive(false);

        // Move to the next camera
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Enable the next camera
        EnableCamera(currentCameraIndex);
    }

    void EnableCamera(int index)
    {
        cameras[index].gameObject.SetActive(true);
    }


    public void SwitchPreviousCamera()
    {
        // Disable the current camera
        cameras[currentCameraIndex].gameObject.SetActive(false);

        // Move to the next camera
        currentCameraIndex = (currentCameraIndex - 1) % cameras.Length;

        // Enable the next camera
        EnableCamera(currentCameraIndex);
    }



    void PlayAnimaion(string name)
    {
        //anim.AddClip(clip, name);
        //anim.Play(name);
    }

    void MoveCamera(Camera camera)
    {
        Vector3 movementDirection = camera.transform.forward * yPos + camera.transform.right * xPos + camera.transform.up * zPos;
        camera.transform.Translate(movementDirection * camSpeed * Time.deltaTime, Space.World);
    }

    void RotateCamera(Camera camera)
    {
        Vector3 newRotation = camera.transform.rotation.eulerAngles + new Vector3(xRot, yRot, zRot) * rotationSpeed * Time.deltaTime;
        camera.transform.rotation = Quaternion.Euler(newRotation);
    }

    /*
    void SaveCameraPosition(int index)
    {
        Camera camera = cameras[index];
        PlayerPrefs.SetFloat($"Camera{index}PosX", camera.transform.position.x);
        PlayerPrefs.SetFloat($"Camera{index}PosY", camera.transform.position.y);
        PlayerPrefs.SetFloat($"Camera{index}PosZ", camera.transform.position.z);
        PlayerPrefs.SetFloat($"Camera{index}RotX", camera.transform.eulerAngles.x);
        PlayerPrefs.SetFloat($"Camera{index}RotY", camera.transform.eulerAngles.y);
        PlayerPrefs.SetFloat($"Camera{index}RotZ", camera.transform.eulerAngles.z);
        PlayerPrefs.Save();
    }

    void LoadCameraPosition(int index)
    {
        Camera camera = cameras[index];
        float posX = PlayerPrefs.GetFloat($"Camera{index}PosX", camera.transform.position.x);
        float posY = PlayerPrefs.GetFloat($"Camera{index}PosY", camera.transform.position.y);
        float posZ = PlayerPrefs.GetFloat($"Camera{index}PosZ", camera.transform.position.z);
        float rotX = PlayerPrefs.GetFloat($"Camera{index}RotX", camera.transform.eulerAngles.x);
        float rotY = PlayerPrefs.GetFloat($"Camera{index}RotY", camera.transform.eulerAngles.y);
        float rotZ = PlayerPrefs.GetFloat($"Camera{index}RotZ", camera.transform.eulerAngles.z);

        camera.transform.position = new Vector3(posX, posY, posZ);
        camera.transform.eulerAngles = new Vector3(rotX, rotY, rotZ);
    }

    */
    #region OSC Methods
    private void ReceivedX(OSCMessage message)
    {
        if (message.ToFloat(out var value))
        {
            xPos = value;
        }
    }

    private void ReceivedY(OSCMessage message)
    {
        if (message.ToFloat(out var value))
        {
            yPos = value;
        }
    }

    private void ReceivedZ(OSCMessage message)
    {
        if (message.ToFloat(out var value))
        {
            zPos = value;
        }
    }
    private void ReceivedXRot(OSCMessage message)
    {
        if (message.ToFloat(out var value))
        {
            xRot = value;
        }
    }

    private void ReceivedYRot(OSCMessage message)
    {
        if (message.ToFloat(out var value))
        {
            yRot = value;
        }
    }

    private void ReceivedZRot(OSCMessage message)
    {
        if (message.ToFloat(out var value))
        {
            zRot = value;
        }
    }

    private void NextCamera(OSCMessage message)
    {
        SwitchNextCamera();
    }

    private void PreviousCamera(OSCMessage message)
    {
        SwitchPreviousCamera();
    }
    #endregion
}
