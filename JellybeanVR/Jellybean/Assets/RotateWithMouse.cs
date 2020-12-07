using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            var xRot = Input.GetAxis("Mouse X") * rotationSpeed;
            var yRot = -1 * Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.Rotate(xRot * Vector2.up, Space.World);
            transform.Rotate(yRot * Vector2.right, Space.Self);
        }
    }
}
