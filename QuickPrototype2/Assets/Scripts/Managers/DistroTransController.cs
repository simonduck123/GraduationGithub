using UnityEngine;

public class DistroTransController : MonoBehaviour
{
    public Animator animator;
    public void DoTransition()
    {
        animator.SetTrigger("do");
    }
}
