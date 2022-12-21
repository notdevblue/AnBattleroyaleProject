using UnityEngine;
using UnityEngine.Events;

namespace Matters
{    
    [RequireComponent(typeof(Rigidbody))]
    public class Velocity : MonoBehaviour
    {
        public UnityEvent<Vector3> onContinuousForceChanged
            = new UnityEvent<Vector3>();

        private Vector3 _continuousForce = new Vector3(0.0f,0.0f,0.0f);
        private Vector3 _delta = new Vector3(0.0f, 0.0f, 0.0f);
        private Rigidbody _rigid;

        public void SetDelta(Vector3 dir)
            => _delta += dir;

        public void ResetDelta()
            => _delta = Vector3.zero;

        public void SetContinuousForce(Vector3 dir)
        {
            _continuousForce += dir;
            onContinuousForceChanged.Invoke(_continuousForce);
        }

        public void ResetContinuousForce()
        {
            _continuousForce = Vector3.zero;
            onContinuousForceChanged.Invoke(_continuousForce);
        }

        public void AddInstantForce(Vector3 force)
            => _rigid.AddForce(force, ForceMode.Impulse);
            

        private void Update()
        {
            
        }
    }
}