using UnityEngine;

public class DistroBoxController : MonoBehaviour
{
    public Animator animator;

    public void DoBoxes()
    {
        animator.SetTrigger("do");
    }
}
