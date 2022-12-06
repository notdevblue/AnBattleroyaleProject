using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Player.KeyAction
{
    // 기능
    /*
    자식 오브젝트의 MoveActor 컴포넌트를 Get 한뒤 Handler 에 추가한 뒤,
    입력 이벤트를 받아 그에 맞는 헨들러 Invoke

    void Action(KeyCode key) {
        this.actions[key]();
    }
    */

    public class MovementHandler : MonoBehaviour, IHandleInput
    {
        private Dictionary<KeyCode, List<MoveActor>> _handlers
            = new Dictionary<KeyCode, List<MoveActor>>();

        public IEnumerable<KeyCode> HandledKeys => _handlers.Keys;

        private void Awake()
        {
            MoveActor[] actors = GetComponentsInChildren<MoveActor>(true);
            for (int i = 0; i < actors.Length; ++i)
            {
                AddHandler(actors[i]);
            }
        }


        public void OnKeyDown(KeyCode key)
        {
            if (!_handlers.ContainsKey(key)) return;

            _handlers[key].ForEach(x => x.OnKeyDown(key));
        }

        public void OnKeyUp(KeyCode key)
        {
            if (!_handlers.ContainsKey(key)) return;

            _handlers[key].ForEach(x => x.OnKeyUp(key));
        }

        public void AddHandler(MoveActor actor)
        {
            actor.handledKeys.ForEach(x => {
                if (!_handlers.ContainsKey(x))
                {
                    _handlers.Add(x, new List<MoveActor>());
                    _handlers[x].Add(actor);
                }
            });
        }

        public void RemoveHandler(MoveActor actor)
        {
            actor.handledKeys.ForEach(x => {
                if (!_handlers.ContainsKey(x))
                {
                    Debug.LogError($"MovementHandler::RemoveHandler > cannot find key: {x}, ignoring.");
                    return;
                }

                if (!_handlers[x].Contains(actor))
                {
                    Debug.LogError($"MovementHandler::RemoveHandler > cannot find item: {x} by: {actor.gameObject.name}, ignoring.");
                    return;
                }

                _handlers[x].Remove(actor);
            });
        }
    }
}