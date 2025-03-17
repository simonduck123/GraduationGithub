using UnityEngine;
using UnityEngine.Video;

public class VideoSwitcher : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoData[] videos;  // Array of VideoData

    private int currentIndex = 0;

    public void SwapVideo()
    {
        if (videos.Length == 0) return;

        currentIndex = (currentIndex + 1) % videos.Length; // Cycle through videos
        videoPlayer.clip = videos[currentIndex].clip;
        videoPlayer.SetDirectAudioVolume(0, videos[currentIndex].volume);
        videoPlayer.Play();
        Debug.Log("nextVid");
    }
}



[System.Serializable]
public class VideoData
{
    public VideoClip clip;
    [Range(0f, 1f)] public float volume; // Volume slider in Inspector
}