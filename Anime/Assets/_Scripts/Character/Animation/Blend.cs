using System;
using UnityEngine;

namespace Character.Animation
{
    [Serializable]
    public class Blend
    {
        public string name;
        public MotionParams motionParams;
        public AnimationClip animClip;

        public Blend(string name, MotionParams motionParams, AnimationClip animClip)
        {
            this.name = name;
            this.motionParams = motionParams;
            this.animClip = animClip;
        }
    }
}