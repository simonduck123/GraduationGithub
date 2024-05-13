using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadControllerParent : MonoBehaviour
{
    public Animator dadAnimator;
    public GameObject child;

    public void MoveOne()
    {
        dadAnimator.SetTrigger("MoveToRoom");
    }

    public void ResetDad()
    {
        dadAnimator.SetTrigger("Reset");
    }

    public void MoveTwo()
    {
        dadAnimator.SetTrigger("MoveToPC");
    }

    public void StopWalk()
    {
        child.GetComponent<DadController>().Idle();
    }

    public void StartWalk()
    {
        child.GetComponent<DadController>().Walk();
    }
}
