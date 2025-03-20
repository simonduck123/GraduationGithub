using UnityEngine;

public class SunsetController : MonoBehaviour
{
    public Animator animator;

    public void DoSunset()
    {
        animator.SetTrigger("do");
    }
}
