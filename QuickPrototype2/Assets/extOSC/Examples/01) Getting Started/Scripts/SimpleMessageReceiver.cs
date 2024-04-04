/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;
using UnityEngine.PlayerLoop;

namespace extOSC.Examples
{
    public class SimpleMessageReceiver : MonoBehaviour
    {
        #region Public Vars

        private string addressX = "/camera/position/x";
        private string addressY = "/camera/position/y";
        private string addressZ = "/camera/position/z";
        private string addressRotX = "/camera/rotation/x";
        private string addressRotY = "/camera/rotation/y";
        private string addressRotZ = "/camera/rotation/z";

        public Camera[] cameras;
        public float camSpeed = 1f;
        public float rotationSpeed = 10f;

        private float xPos;
        private float yPos;
        private float zPos;
        private float xRot;
        private float yRot;
        private float zRot;
        public GameObject bedroom;
        public GameObject livingRoom;
        private int currentCameraIndex = 0;



        [Header("OSC Settings")]
		public OSCReceiver Receiver;

        #endregion

        #region Unity Methods

        protected virtual void Start()
		{
            for (int i = 0; i < cameras.Length; i++)
            {
                LoadCameraPosition(i);
            }
            Receiver.Bind(addressX, ReceivedX);
            Receiver.Bind(addressY, ReceivedY);
            Receiver.Bind(addressZ, ReceivedZ);
            Receiver.Bind(addressRotX, ReceivedXRot);
            Receiver.Bind(addressRotY, ReceivedYRot);
            Receiver.Bind(addressRotZ, ReceivedZRot);


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

            SaveCameraPosition(currentCameraIndex);
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

        void MoveCamera(Camera camera)
        {
            Vector3 movementDirection = camera.transform.forward * -yPos + camera.transform.right * xPos + camera.transform.up * zPos;
            camera.transform.Translate(movementDirection * camSpeed * Time.deltaTime, Space.World);
        }


        void RotateCamera(Camera camera)
        {
            Vector3 newRotation = camera.transform.rotation.eulerAngles + new Vector3(xRot, yRot, zRot) * rotationSpeed * Time.deltaTime;
            camera.transform.rotation = Quaternion.Euler(newRotation);
        }

        #endregion

        #region Private Methods

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


        #endregion
    }
}