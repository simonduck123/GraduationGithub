using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{

    private CustomAnimation customAnimation;
    Animation anim = new Animation();

    private void Start()
    {
        anim = GetComponent<Animation>(); // Initialize anim here
        InitialiseAnimation();
    }


    private void InitialiseAnimation()
    {
        AnimationCurve curve = new AnimationCurve();
        AnimationClip clip = new AnimationClip();
        clip.legacy = true;
        Keyframe[] keys = new Keyframe[3];
        keys[0] = new Keyframe(0, 0);
        keys[1] = new Keyframe(0.5f, 1);
        keys[2] = new Keyframe(1, 0);
        clip.name = "Camera Animation";
        customAnimation = new CustomAnimation(anim, curve, clip, keys);
    }


    public void PlayAnimation()
    {
        anim.AddClip(customAnimation.clip, customAnimation.clip.name);
        anim.Play(customAnimation.clip.name);
    }

    public void OnButton1Pressed()
    {
        SetTransformAnimation(0);
    }

    public void OnButton2Pressed()
    {
        SetTransformAnimation(1);
    }

    public void OnButton3Pressed()
    {
        SetTransformAnimation(2);
    }

    private void SetTransformAnimation(int index)
    {
        Vector3 newPosition = this.gameObject.transform.localPosition;
        newPosition.x = GetXTransform();
        newPosition.y = GetYTransform();
        newPosition.z = GetZTransform();

        customAnimation.keys[index].value = newPosition.x; // Update x position
        customAnimation.keys[index].inTangent = newPosition.y; // Update y position
        customAnimation.keys[index].outTangent = newPosition.z; // Update z position

        // Update the x, y, and z position curves separately
        AnimationCurve xCurve = new AnimationCurve(customAnimation.keys);
        AnimationCurve yCurve = new AnimationCurve(customAnimation.keys);
        AnimationCurve zCurve = new AnimationCurve(customAnimation.keys);

        customAnimation.clip.SetCurve("", typeof(Transform), "localPosition.x", xCurve);
        customAnimation.clip.SetCurve("", typeof(Transform), "localPosition.y", yCurve);
        customAnimation.clip.SetCurve("", typeof(Transform), "localPosition.z", zCurve);
    }


    /*

    public void OnButton1Pressed()
    {
        SetTransformXAnimation(0);
        SetTransformYAnimation(0);
        SetTransformZAnimation(0);
    }

    public void OnButton2Pressed()
    {
        SetTransformXAnimation(1);
        SetTransformYAnimation(1);
        SetTransformZAnimation(1);
    }

    public void OnButton3Pressed()
    {
        SetTransformXAnimation(2);
        SetTransformYAnimation(2);
        SetTransformZAnimation(2);
    }

    private void SetTransformXAnimation(int index)
    {
        customAnimation.keys[index].value = GetXTransform();
        customAnimation.curve = new AnimationCurve(customAnimation.keys);
        customAnimation.clip.SetCurve("", typeof(Transform), "localPosition.x", customAnimation.curve);
    }

    private void SetTransformYAnimation(int index)
    {
        customAnimation.keys[index].value = GetYTransform();
        customAnimation.curve = new AnimationCurve(customAnimation.keys);
        customAnimation.clip.SetCurve("", typeof(Transform), "localPosition.y", customAnimation.curve);
    }

    private void SetTransformZAnimation(int index)
    {
        customAnimation.keys[index].value = GetZTransform();
        customAnimation.curve = new AnimationCurve(customAnimation.keys);
        customAnimation.clip.SetCurve("", typeof(Transform), "localPosition.z", customAnimation.curve);
    }
    */

    #region Getters
    private float GetXTransform()
    {
        return this.gameObject.transform.position.x;
    }
    private float GetYTransform()
    {
        return this.gameObject.transform.position.y;
    }
    private float GetZTransform()
    {
        return this.gameObject.transform.position.z;
    }
    private float GetXRotation()
    {
        return this.gameObject.transform.eulerAngles.x;
    }
    private float GetYRotation()
    {
        return this.gameObject.transform.eulerAngles.y;
    }
    private float GetZRotation()
    {
        return this.gameObject.transform.eulerAngles.z;
    }

    #endregion
}
