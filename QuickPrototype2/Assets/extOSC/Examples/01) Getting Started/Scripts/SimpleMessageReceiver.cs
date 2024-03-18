/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEditor.Experimental.GraphView;
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


        public GameObject testCam;
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

        

        [Header("OSC Settings")]
		public OSCReceiver Receiver;

        #endregion

        #region Unity Methods

        protected virtual void Start()
		{
            
            Receiver.Bind(addressX, ReceivedX);
            Receiver.Bind(addressY, ReceivedY);
            Receiver.Bind(addressZ, ReceivedZ);
            Receiver.Bind(addressRotX, ReceivedXRot);
            Receiver.Bind(addressRotY, ReceivedYRot);
            Receiver.Bind(addressRotZ, ReceivedZRot);

        }

        private void Update()
        {
            Vector3 newPosition = testCam.transform.position + new Vector3(xPos, -yPos, zPos) * camSpeed * Time.deltaTime;
            testCam.transform.position = newPosition;

            Vector3 newRotation = testCam.transform.rotation.eulerAngles + new Vector3(xRot, yRot, zRot) * rotationSpeed * Time.deltaTime;
            testCam.transform.rotation = Quaternion.Euler(newRotation);

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


        #endregion
    }
}