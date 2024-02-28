/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{
	public class SimpleMessageReceiver : MonoBehaviour
	{
		#region Public Vars

		public string Address = "/example/1";

        private const string _BedroomAddress1 = "/Bedroom/1";

        private const string _BedroomAddress2 = "/Bedroom/2";

        private const string _LivingRoomAddress1 = "/LivingRoom/1";

        private const string _LivingRoomAddress2 = "/LivingRoom/2";

        private float isLivingRoom;
        private float isBedroom;
        public GameObject bedroom;
        public GameObject livingRoom;

        

        [Header("OSC Settings")]
		public OSCReceiver Receiver;

		#endregion

		#region Unity Methods

		protected virtual void Start()
		{
            
            Receiver.Bind(_BedroomAddress1, ReceivedBedroomOne);
            Receiver.Bind(_BedroomAddress2, ReceivedBedroomTwo);
            Receiver.Bind(_LivingRoomAddress1, ReceivedLivingRoomOne);
            Receiver.Bind(_LivingRoomAddress2, ReceivedLivingRoomTwo);
            /*
            Receiver.Bind(_blobAddress, ReceiveBlob);
            Receiver.Bind(_charAddress, ReceiveChar);
            Receiver.Bind(_colorAddress, ReceiveColor);
            Receiver.Bind(_doubleAddress, ReceiveDouble);
            Receiver.Bind(_boolAddress, ReceiveBool);
            Receiver.Bind(_floatAddress, ReceiveFloat);
            Receiver.Bind(_impulseAddress, ReceiveImpulse);
            Receiver.Bind(_intAddress, ReceiveInt);
            Receiver.Bind(_longAddress, ReceiveLong);
            Receiver.Bind(_nullAddress, ReceiveNull);
            Receiver.Bind(_stringAddress, ReceiveString);
            Receiver.Bind(_timetagAddress, ReceiveTimeTag);
            Receiver.Bind(_midiAddress, ReceiveMidi);
            */
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                livingRoom.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                livingRoom.SetActive(false);
            }
        }

        #endregion

        #region Private Methods

        private void ReceivedBedroomOne(OSCMessage message)
        {
            Debug.LogFormat("Received: {0}", message);
            if (message.ToFloat(out var value))
            {
                isBedroom = value;
            }
        }

        private void ReceivedBedroomTwo(OSCMessage message)
        {
            Debug.LogFormat("Received: {0}", message);
            if (message.ToFloat(out var value))
            {
                isBedroom = value;
            }
        }

        private void ReceivedLivingRoomOne(OSCMessage message)
        {
            Debug.LogFormat("Received: {0}", message);
            if (message.ToFloat(out var value))
            {
                isLivingRoom = value;
            }
        }

        private void ReceivedLivingRoomTwo(OSCMessage message)
        {
            Debug.LogFormat("Received: {0}", message);
            if (message.ToFloat(out var value))
            {
                isLivingRoom = value;
            }
        }


        #endregion
    }
}