using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public PlayableDirector playableDirector;

    public void PlayTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Play();
            Debug.Log("Play");
        }
    }

    public void RestartTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Pause();
           // playableDirector.time = 0;
            Debug.Log("Restart");
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
