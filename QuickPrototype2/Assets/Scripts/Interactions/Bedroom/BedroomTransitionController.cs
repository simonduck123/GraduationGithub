using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BedroomTransitionController : MonoBehaviour
{
    public Animator animator;
    public void DoTransition()
    {
        animator.SetTrigger("lights");
    }


    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
