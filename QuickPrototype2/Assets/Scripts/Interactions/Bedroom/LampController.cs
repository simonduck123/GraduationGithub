using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public GameObject lightSource;
    public AudioClip lampOn;
    public AudioSource audioSource;

    public void TurnOnLamp()
    {
        lightSource.SetActive(true);
    }

    public void TurnOffLamp()
    {
        lightSource.SetActive(false);
        PlayAudio(lampOn);
    }

    private void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
