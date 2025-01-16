using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomCameraController : MonoBehaviour
{
    public Animator animator;

    public void StartGameAnimation()
    {
        animator.SetTrigger("StartScene");
    }
}
