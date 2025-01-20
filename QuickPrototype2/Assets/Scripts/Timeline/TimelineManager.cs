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
        Debug.Log("gsdfg");
        if (playableDirector != null)
        {
            playableDirector.Stop();
            playableDirector.time = 0;
            Debug.Log("Restart");
        }
    }
}
