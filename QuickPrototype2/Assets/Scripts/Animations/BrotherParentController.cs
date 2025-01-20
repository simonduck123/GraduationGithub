using UnityEngine;

public class BrotherParentController : MonoBehaviour
{
    public Animator animator;
    private string currentAnimaton;

    const string BROTHER_IDLE = "Brother_Idle";
    const string BROTHER_IDLE_FIGHT = "Brother_Idle_Fight";
    const string BROTHER_WALK = "Brother_Walk";
    const string BROTHER_SLAM = "Brother_Slam";
    const string BROTHER_STAND_TO_FIGHT = "Brother_Stand_To_Fight";
    const string BROTHER_FIGHT_TO_STAND = "Brother_Fight_To_Stand";

    public void BrotherIdle()
    {
        ChangeAnimationState(BROTHER_IDLE);
    }

    public void BrotherIdleFight()
    {
        ChangeAnimationState(BROTHER_IDLE_FIGHT);
    }

    public void BrotherWalk()
    {
        ChangeAnimationState(BROTHER_WALK);
    }

    public void BrotherSlam()
    {
        ChangeAnimationState(BROTHER_SLAM);
    }

    public void BrotherStandToFight()
    {
        ChangeAnimationState(BROTHER_STAND_TO_FIGHT);
    }

    public void BrotherFightToStand()
    {
        ChangeAnimationState(BROTHER_FIGHT_TO_STAND);
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
