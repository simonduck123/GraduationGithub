using UnityEngine;

public class DistroTransitionController : MonoBehaviour
{
    public Animator animator;
    public DistroBoxController distroBoxController;

    public void DoTransition()
    {
        animator.SetTrigger("do");
    }

    public void StartBoxes()
    {
        distroBoxController.DoBoxes();
    }
}
