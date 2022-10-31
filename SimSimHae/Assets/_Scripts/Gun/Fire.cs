using UnityEngine;
using UnityEngine.Events;

public class Fire : MonoBehaviour
{
    public UnityEvent OnFire;
    public Transform firePos;

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(firePos.position, firePos.forward, out RaycastHit hit))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            
            OnFire.Invoke();
        }

    }
}