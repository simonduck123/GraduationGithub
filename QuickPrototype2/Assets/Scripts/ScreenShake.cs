using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin _cbmcp;
    public AnimationCurve shakeIntensityCurve; // Serialized field for animation curve
    public float ShakeTime = 0.2f;
    public float strength = 1.0f;
    private float timer;
    public AudioClip shakeSound;
    public AudioSource audioSource;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        StopShake();
    }

    // Method to shake the camera with the specified curve
    public void ShakeCamera()
    {
        timer = ShakeTime;
        PlayAudio(shakeSound);
    }

    void StopShake()
    {
        if (_cbmcp != null)
        {
            _cbmcp.m_AmplitudeGain = 0f;
            timer = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ShakeCamera();
        }

        if (timer > 0)
        {
            
            float curveValue = shakeIntensityCurve.Evaluate(1 - (timer / ShakeTime)); // Evaluate curve based on time
            curveValue = curveValue * strength;
            if (_cbmcp != null)
            {
                _cbmcp.m_AmplitudeGain = curveValue;
            }

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                StopShake();
            }
        }
    }
    private void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
