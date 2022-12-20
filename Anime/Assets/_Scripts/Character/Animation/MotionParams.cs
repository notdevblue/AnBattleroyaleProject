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
    }
}