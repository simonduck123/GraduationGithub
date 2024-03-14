using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BedroomTransitionController : MonoBehaviour
{
    public void DoTransition()
    {
        LoadNextScene();
    }

    public void UndoTransition()
    {

    }

    public void LoadNextScene()
    {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene by incrementing the current scene index
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
