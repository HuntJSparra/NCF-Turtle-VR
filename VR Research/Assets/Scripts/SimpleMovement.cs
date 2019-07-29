using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public int speed;
    public int rotSpeed;

    private Rigidbody rb;
    
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Camera.main.transform.forward*Input.GetAxis("Vertical")*Time.deltaTime*speed);
        transform.Translate(Camera.main.transform.right*Input.GetAxis("Horizontal")*Time.deltaTime*speed);
        Camera.main.transform.Rotate(-Vector3.right*Input.GetAxis("Mouse Y")*Time.deltaTime*rotSpeed);
        Camera.main.transform.Rotate(Vector3.up*Input.GetAxis("Mouse X")*Time.deltaTime*rotSpeed, Space.World);

        if (Input.GetKeyDown("space"))
            rb.useGravity = !rb.useGravity;
    }
}
