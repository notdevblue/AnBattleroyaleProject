using System;
using System.Collections.Generic;
using Matters;
using UnityEngine;


namespace Character.Animation
{
    public class Locomotion : MonoBehaviour
    {
        public Velocity velocity;
        public Animator animator;
        public List<Blend> animations;
        private readonly int _moveX = Animator.StringToHash("MoveX");
        private readonly int _moveY = Animator.StringToHash("MoveY");
        public float animLerpSecond = 1.0f;
        private float _lerpAmount;

        private MotionParams _pastMotionParams;
        private MotionParams _curMotionParams;
        private MotionParams _targetMotionParams;
        private float _t = 0.0f;


        private void Awake()
        {
            _pastMotionParams = new MotionParams(Vector3.zero);
            _curMotionParams = new MotionParams(Vector3.zero);
            _targetMotionParams = new MotionParams(Vector3.zero);

            _lerpAmount = 1.0f / animLerpSecond;
        }

        private void Start()
        {
            velocity
                .onContinuousForceChanged
                .AddListener(force => {
                    Debug.Log("A");
                    _pastMotionParams.motionParams = _curMotionParams.motionParams;
                    _targetMotionParams.motionParams = force;
                    _t = 0.0f;
                });
        }

        private void Update()
        {
            _t += _lerpAmount * Time.deltaTime;
            _curMotionParams.motionParams
                = _pastMotionParams.Lerp(_targetMotionParams, _t);

            animator.SetFloat(_moveX, _curMotionParams.motionParams.x);
            animator.SetFloat(_moveY, _curMotionParams.motionParams.z);
        }
    }
}