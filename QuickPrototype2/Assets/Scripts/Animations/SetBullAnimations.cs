using UnityEngine;

public class SetBullAnimations : MonoBehaviour
{
    public BullAnimationController bullAnimationController;
    public Animator animator;

    public void DoTransition()
    {
        animator.SetTrigger("do");
    }

    public void SetIdle()
    {
        bullAnimationController.BullIdle();
    }

    public void SetWalk()
    {
        bullAnimationController.BullWalk();
    }


}
