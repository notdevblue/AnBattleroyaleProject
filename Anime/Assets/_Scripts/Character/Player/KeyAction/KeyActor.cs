using System.Collections.Generic;
using UnityEngine;

namespace Character.Player.KeyAction
{    
    abstract public class KeyActor : MonoBehaviour
    {
        public List<KeyCode> handledKeys;
        
        abstract public void OnKeyDown(KeyCode pressedKey);
        abstract public void OnKeyUp(KeyCode pressedKey);
    }
}