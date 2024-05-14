using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomTransitionManager : MonoBehaviour
{

    public Animator animator;
    private string currentAnimaton;

    const string TRANSITION = "transition";

    public void DoTransition()
    {
        ChangeAnimationState(TRANSITION);
    }

    void ChangeAnimationState(string newAnimation)
    {
        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
