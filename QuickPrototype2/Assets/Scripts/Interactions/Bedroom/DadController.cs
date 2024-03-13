using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadController : MonoBehaviour
{
    public Animator dadAnimator;
    public void WalkInside()
    {
        dadAnimator.SetTrigger("MoveToRoom");
    }

    public void ResetDad()
    {
        dadAnimator.SetTrigger("Reset");
    }
     
    public void ThrowKevin() 
    {
        dadAnimator.SetTrigger("MoveToPC");
    }
    
    public void Dialogue()
    {
        
    }

    public void TurnPCOff()
    {

    }
}
