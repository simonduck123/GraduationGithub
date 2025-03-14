using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CustomAnimation
{
    public Animation anim;
    public AnimationCurve curve;
    public AnimationClip clip;
    public Keyframe[] keys;

    public CustomAnimation(Animation customAnim, AnimationCurve customCurve, AnimationClip customClip, Keyframe[] customeKeys)
    {
        anim = customAnim;
        curve = customCurve;
        clip = customClip;
        keys = customeKeys;
    }
}
