using UnityEngine;

public class HouseAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for key presses
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Play animation 1
            PlayAnimation("Animation1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Play animation 2
            PlayAnimation("Animation2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Play animation 3
            PlayAnimation("Animation3");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            // Play animation 4
            PlayAnimation("Q");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            // Play animation 5
            PlayAnimation("W");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            // Play animation 5
            PlayAnimation("E");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            // Play animation 5
            PlayAnimation("R");
        }
    }

    // Function to play animation by name
    void PlayAnimation(string animationName)
    {
        // Trigger the animation by setting a parameter
        animator.SetTrigger(animationName);
    }
}
