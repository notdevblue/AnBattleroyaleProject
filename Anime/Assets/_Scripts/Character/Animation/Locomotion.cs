using System;
using System.Collections.Generic;
using UnityEngine;


namespace Character.Animation
{
    public class Locomotion : MonoBehaviour
    {
        public Animator animator;
        public UnityEngine.Animation anim;
        public List<Blend> animations;
        private MotionParams motionParams;

        private void Awake()
        {
            motionParams = new MotionParams(Vector3.zero);

            // anim.Blend() 
            // anim.Play() 이거 잘 쓰면 될 거 같음
        }

        private void Start()
        {
            RuntimeAnimatorController controller = animator.runtimeAnimatorController;
            AnimatorOverrideController overrideController = new AnimatorOverrideController();
            overrideController.runtimeAnimatorController = controller;
            overrideController["Hello"] = animations[0].animClip;
            // anim.clip = animations[0].animClip;
            // anim.Play();
            animator.runtimeAnimatorController = overrideController;

            // 이거 잘 쓰면 에니메이션 교채가 될 듯 한데...
        }
    }
}