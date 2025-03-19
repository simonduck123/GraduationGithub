using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public Animator animator;
    public AudioClip lampOn;
    public AudioSource audioSource;

    public void DoLamps()
    {
        animator.SetTrigger("do");
        PlayAudio(lampOn);
    }


    private void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
