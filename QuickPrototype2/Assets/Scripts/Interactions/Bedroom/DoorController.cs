using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioClip knockAudio;
    public AudioClip loudKnockAudio;
    public AudioSource audioSource;
    public void PlayKnockSound()
    {
        audioSource.clip = knockAudio;
        audioSource.Play();
    }

    public void PlayLoudKnockSound()
    {
        audioSource.clip = loudKnockAudio;
        audioSource.Play();
    }

    public void OpenDoor()
    {
        doorAnimator.SetBool("DoorOpen", true);
    }

    public void CloseDoor()
    {
        doorAnimator.SetBool("DoorOpen", false);
    }
}