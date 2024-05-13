using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeController : MonoBehaviour
{
    public Animator fridgeAnimator;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioSource audioSource;

    public void OpenFridge()
    {
        fridgeAnimator.SetBool("FridgeOpen", true);
        PlayAudio(doorOpen);
    }

    public void CloseFridge()
    {
        fridgeAnimator.SetBool("FridgeOpen", false);
        PlayAudio(doorClose);
    }

    private void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
