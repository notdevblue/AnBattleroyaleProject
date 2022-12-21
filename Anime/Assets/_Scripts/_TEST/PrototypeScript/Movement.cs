using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2.0f;
    public float rotSpeed = 2.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }



        float x = Input.GetAxis("Horizontal");
        Debug.Log(x);

        Vector3 rot = transform.eulerAngles;
        rot.y += x * rotSpeed * Time.deltaTime;
        Debug.Log(rot.y);
        transform.eulerAngles = rot;
    }
}