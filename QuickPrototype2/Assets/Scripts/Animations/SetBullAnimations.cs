using UnityEngine;

public class SetBullAnimations : MonoBehaviour
{
    public BullAnimationController bullAnimationController;

    public void SetIdle()
    {
        bullAnimationController.BullIdle();
    }
}
