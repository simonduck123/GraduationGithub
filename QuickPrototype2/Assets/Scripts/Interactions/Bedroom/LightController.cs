using UnityEngine;

public class LightController : MonoBehaviour
{
    public Animator animator;
    public void DoLights()
    {
        animator.SetTrigger("lights");
    }
}
