using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoclips : MonoBehaviour
{
    public VideoClip[] videoClips;
    public VideoPlayer videoPlayer;
    private int videoClipIndex = 0;


    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    public void PlayNextClip()
    {

            videoClipIndex++;

            videoPlayer.clip = videoClips[videoClipIndex];
            videoPlayer.Play();
        

    }

    public void PlayPreviousClip()
    {

        videoClipIndex--;

        videoPlayer.clip = videoClips[videoClipIndex];
        videoPlayer.Play();


    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayNextClip();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayPreviousClip();
        }
    }
}
