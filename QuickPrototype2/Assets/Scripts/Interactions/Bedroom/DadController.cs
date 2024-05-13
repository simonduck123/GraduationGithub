using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadController : MonoBehaviour
{
    public Animator dadAnimator;
    private string currentAnimaton;

    const string DAD_IDLE = "Dad_Idle";
    const string DAD_DANCE = "Dad_Dance";
    const string DAD_TALK = "Dad_Talk";
    const string DAD_WALK = "Dad_Walk";
    const string DAD_WAVE = "Dad_Wave";
    const string DAD_RESET = "Dad_RESET";

    public void Walk()
    {
        ChangeAnimationState(DAD_WALK);
    }

    public void ResetDad()
    {
        ChangeAnimationState(DAD_RESET);
    }
     
    public void Talk() 
    {
        ChangeAnimationState(DAD_TALK);
    }
    
    public void Wave()
    {
        ChangeAnimationState(DAD_WAVE);
    }

    public void Dance()
    {
        ChangeAnimationState(DAD_DANCE);
    }

    public void Idle()
    {
        ChangeAnimationState(DAD_IDLE);
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        dadAnimator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
