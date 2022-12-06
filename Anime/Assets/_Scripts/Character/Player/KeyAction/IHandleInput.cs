using System.Collections.Generic;
using UnityEngine;

namespace Character.Player.KeyAction
{
    interface IHandleInput
    {
        void OnKeyDown(KeyCode key);
        void OnKeyUp(KeyCode key);

        IEnumerable<KeyCode> HandledKeys { get; }
        
    }
}