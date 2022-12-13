using UnityEngine;
using System;
using System.Collections.Generic;

using Matters;

namespace Character.Player.KeyAction.Movement
{
    // 기능
    /*
    키 입력을 받고 Matters.Velocity.SetDelta(이동 방향);

    status:
        KeyDown = true
        KeyUp = false

    Move(status ? 방향 : -방향) {
        Velocity.SetDelta();
    }
    */

    public class MoveActor : KeyActor
    {
        private Dictionary<KeyCode, Action<bool>> _keyEventActions
            = new Dictionary<KeyCode, Action<bool>>();

        private Vector3[] _dirs = new Vector3[4] {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        private Velocity _velocity;

        

        private void Start()
        {
            handledKeys.Add(KeyCode.W);
            handledKeys.Add(KeyCode.S);
            handledKeys.Add(KeyCode.A);
            handledKeys.Add(KeyCode.D);

            for (int i = 0; i < _dirs.Length; ++i)
            {
                _keyEventActions.Add(handledKeys[i], status => {
                    Move(status ? _dirs[i] : -_dirs[i]);
                });
            }
        }

        public void Move(Vector3 dir)
        {
            _velocity.SetContinuousForce(dir);
        }

        public override void OnKeyDown(KeyCode pressedKey)
        {
            _keyEventActions[pressedKey](true);
        }

        public override void OnKeyUp(KeyCode pressedKey)
        {
            _keyEventActions[pressedKey](false);
        }
    }
}