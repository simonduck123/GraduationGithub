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

    private string addressX = "/camera/position/x";
    private string addressY = "/camera/position/y";
    private string addressZ = "/camera/position/z";
    private string addressRotX = "/camera/rotation/x";
    private string addressRotY = "/camera/rotation/y";
    private string addressRotZ = "/camera/rotation/z";

    [Header("OSC Settings")]
    public OSCReceiver Receiver;


    public void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            //LoadCameraPosition(i);
        }
        Receiver.Bind(addressX, ReceivedX);
        Receiver.Bind(addressY, ReceivedY);
        Receiver.Bind(addressZ, ReceivedZ);
        Receiver.Bind(addressRotX, ReceivedXRot);
        Receiver.Bind(addressRotY, ReceivedYRot);
        Receiver.Bind(addressRotZ, ReceivedZRot);





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
            SwitchCamera();
        }

        Camera currentCamera = cameras[currentCameraIndex];
        MoveCamera(currentCamera);
        RotateCamera(currentCamera);

        //SaveCameraPosition(currentCameraIndex);
    }

    void SwitchCamera()
    {
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Disable all cameras except the current one
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == currentCameraIndex);
        }
    }

    void AnimateFromNothing()
    {

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
    #endregion
}
