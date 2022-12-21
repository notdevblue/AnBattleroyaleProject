using System;
using UnityEngine;

namespace Character.Animation
{
    [Serializable]
    public class MotionParams
    {
        public Vector3 motionParams;

        public MotionParams(Vector3 motionParams)
        {
            this.motionParams = motionParams;
        }

        public Vector3 Lerp(MotionParams target, float t)
        {
            return Vector3.Lerp(this.motionParams, target.motionParams, t);
        }
    }
}