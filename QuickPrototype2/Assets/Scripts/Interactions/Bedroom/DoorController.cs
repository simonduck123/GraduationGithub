using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioClip knockAudio;
    public AudioClip loudKnockAudio;
    public AudioClip doorOpen;
    public AudioSource audioSource;
    private string currentAnimaton;

    const string DOOR_OPEN = "Door_Open";
    const string DOOR_CLOSE = "Door_Close";
    const string DOOR_KNOCK = "Door_Knock";
    const string DOOR_LOUDKNOCK = "Door_LoudKnock";
    /*
    public void OpenDoor()
    {
        doorAnimator.SetBool("DoorOpen", true);
    }

    public void CloseDoor()
    {
        doorAnimator.SetBool("DoorOpen", false);
    }
*/
    public void Open()
    {
        ChangeAnimationState(DOOR_OPEN);
        PlayAudio(doorOpen);
    }

    public void Close()
    {
        ChangeAnimationState(DOOR_CLOSE);
        PlayAudio(doorOpen);
    }

    public void Knock()
    {
        ChangeAnimationState(DOOR_KNOCK);
        PlayAudio(knockAudio);
    }

    public void LoudKnock()
    {
        ChangeAnimationState(DOOR_LOUDKNOCK);
        PlayAudio(loudKnockAudio);
    }

    void ChangeAnimationState(string newAnimation)
    {
        doorAnimator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    private void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
