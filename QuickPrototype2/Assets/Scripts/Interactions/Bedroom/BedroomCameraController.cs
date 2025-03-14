using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomCameraController : MonoBehaviour
{
    public Animator animator;
    public GameObject brother;

    public void StartGameAnimation()
    {
        animator.SetTrigger("StartScene");
    }

    public void ResetBedroomScene()
    {
        //animator.SetTrigger("Reset");
    }

    public void StartBrother()
    {
        brother.SetActive(true);
    }
}
