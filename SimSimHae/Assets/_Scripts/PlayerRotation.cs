using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float speed = 1.5f;

    public Transform camTrm;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 rot =  this.transform.localEulerAngles;
        rot.y += Input.GetAxis("Mouse X") * speed;
        this.transform.localEulerAngles = rot;


        rot = camTrm.localEulerAngles;
        rot.x -= Input.GetAxis("Mouse Y") * speed;
        camTrm.localEulerAngles = rot;
    }
}
