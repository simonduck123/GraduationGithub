using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkTransitionController : MonoBehaviour
{
    public Animator animator;
    const string OPENINGTRAN = "OpeningTransition";

    public void DoTransition()
    {
        ChangeAnimationState(OPENINGTRAN);
    }

    public void UndoTransition()
    {

    }

    void ChangeAnimationState(string newAnimation)
    {
        animator.Play(newAnimation);
    }
}
