using UnityEngine;

public class BullAnimationController : MonoBehaviour
{
    public Animator animator;
    private string currentAnimaton;

    const string BULL_IDLE = "Bull_Idle";
    const string BULL_WALK = "Bull_Walk";
    const string BULL_LAUGHING = "Bull_Laugh";
    const string BULL_YELL = "Bull_Yell";
    const string BULL_ROAR = "Bull_Roar";

    public void BullIdle()
    {
        ChangeAnimationState(BULL_IDLE);
    }
    public void BullWalk()
    {
        ChangeAnimationState(BULL_WALK);
    }
    public void BullLaugh()
    {
        ChangeAnimationState(BULL_LAUGHING);
    }
    public void BullYell()
    {
        ChangeAnimationState(BULL_YELL);
    }
    public void BullRoar()
    {
        ChangeAnimationState(BULL_ROAR);
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
