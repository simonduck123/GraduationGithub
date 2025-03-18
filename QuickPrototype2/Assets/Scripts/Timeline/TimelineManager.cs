using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public PlayableAsset exitAnimation;

    public void PlayTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Play();
        }
    }

    public void RestartTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.time = 0;
            playableDirector.Play();
        }
    }

    public void PauseTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.Pause();
        }
    }

    public void SkipTimeline()
    {
        if (playableDirector != null)
        {
            Debug.Log("do");
            playableDirector.Pause();
            playableDirector.Evaluate();
            playableDirector.playableAsset = exitAnimation;
            playableDirector.Play();
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
