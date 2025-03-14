using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ComputerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void StopVideoPlayer()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }
    }

    public void PlayVideo()
    {
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }

}
