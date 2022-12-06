using System.Collections.Generic;
using UnityEngine;

namespace Character.Player.KeyAction
{
    // 기능
    /*
    (본인 오브젝트 포함) 자식의 IHandleInput interface 를 전부 긁어와
    HandledKeys 에 따른 입력 이벤트 발생시킴.

    update() {
        executes KeyInputEvent
    }
    */

    public class InputSystem : MonoBehaviour
    {
        private IHandleInput[] _inputHandlers;


        private void Awake()
        {
            _inputHandlers = GetComponentsInChildren<IHandleInput>();
        }


        private void Update()
        {
            for (int i = 0; i < _inputHandlers.Length; ++i)
            {
                foreach (KeyCode key in _inputHandlers[i].HandledKeys)
                {
                    if (Input.GetKeyUp(key))
                    {
                        _inputHandlers[i].OnKeyUp(key);
                    }
                    else if (Input.GetKeyDown(key))
                    {
                        _inputHandlers[i].OnKeyDown(key);
                    }
                }
            }
        }
    }
}