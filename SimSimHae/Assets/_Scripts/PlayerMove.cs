using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _con;

    public float speed = 3.0f;
    public float jumpForce = 2.5f;
    public float dashBoostAmout = 1.2f;

    private void Awake()
    {
        _con = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        float calculateSpeed = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            calculateSpeed *= dashBoostAmout;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += (transform.forward * calculateSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (-transform.forward * calculateSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += (-transform.right * calculateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (transform.right * calculateSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _con.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

}
