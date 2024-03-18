/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{
	public class SimpleMessageReceiver : MonoBehaviour
	{
		#region Public Vars

		public string addressX = "/example/x";
        public string addressY = "/example/y";

        private const string _BedroomAddress1 = "/Bedroom/1";

        private const string _BedroomAddress2 = "/Bedroom/2";

        private const string _LivingRoomAddress1 = "/LivingRoom/1";

        private const string _LivingRoomAddress2 = "/LivingRoom/2";

        private float isLivingRoom;
        private float xPos;
        private float yPos;
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
            Debug.Log(xPos + " " + yPos);
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