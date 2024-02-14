using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public UDPReceive udpReceive;
    [SerializeField] private bool isInversed;
    private float inverseOffset;

    void Update()
    {
        if (isInversed)
        {
            inverseOffset = -1f;
        }
        else
        {
            inverseOffset = 1f;
        }

        string data = udpReceive.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        string[] info = data.Split(',');

        float x = float.Parse(info[0]) / 1280;  // Normalize x to 0-1 range
        float y = float.Parse(info[1]) / 720;  // Normalize y to 0-1 range

        float xPos = (x * 18) - 9;  // Map to -9 to 9 range
        float yPos = (y * 10) - 5;  // Map to -5 to 5 range

        gameObject.transform.localPosition = new Vector3(inverseOffset * xPos, 0, inverseOffset * yPos);


    }
}
