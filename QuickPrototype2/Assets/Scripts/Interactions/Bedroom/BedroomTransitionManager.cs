using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedroomTransitionManager : MonoBehaviour
{

    public Animator animator;
    private string currentAnimaton;

    const string TRANSITION = "transition";
    const string PARKTRANSITION = "parkTransition";

    public void DoTransition()
    {
        ChangeAnimationState(TRANSITION);
    }

    void ChangeAnimationState(string newAnimation)
    {
        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    public void ParkTransition()
    {
        ChangeAnimationState(PARKTRANSITION);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
