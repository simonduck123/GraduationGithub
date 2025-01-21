using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManagerBrother : MonoBehaviour
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
}
