using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorController : MonoBehaviour
{
    public Animator doorAnimator;
    public void OpenDoor()
    {
        doorAnimator.SetBool("DoorOpen", true);
    }

    public void CloseDoor()
    {
        doorAnimator.SetBool("DoorOpen", false);
    }
}
