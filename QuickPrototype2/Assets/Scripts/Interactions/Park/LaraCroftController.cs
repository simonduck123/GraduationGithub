using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaraCroftController : MonoBehaviour
{
    public Animator momAnimator;

    public void LaraEnter()
    {
        momAnimator.SetTrigger("Enter");
    }

    public void LaraResetPos()
    {
        momAnimator.SetTrigger("Reset");
    }

    public void LaraDialogueOne()
    {

    }

    public void LaraDialogueTwo()
    {

    }
}
