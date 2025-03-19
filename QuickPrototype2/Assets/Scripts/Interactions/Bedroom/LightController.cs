using UnityEngine;

public class LightController : MonoBehaviour
{
    public Animator animator;
    public AudioClip lightOn;
    public AudioSource audioSource;
    public void DoLights()
    {
        animator.SetTrigger("lights");
        PlayAudio(lightOn);
    }

    private void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
