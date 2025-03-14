using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParkTransitionController : MonoBehaviour
{
    public Animator animator;
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }

    public void SwapScenes()
    {
        animator.SetTrigger("OrbTrans");
    }
}
