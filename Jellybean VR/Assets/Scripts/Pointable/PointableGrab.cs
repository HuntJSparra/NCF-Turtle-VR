using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointableGrab : Pointable
{
    float movementTimer; // Tracks how long until the can should stop moving towards the target hand
    GameObject targetHand;

    private OVRGrabbable ovrg;
    private Rigidbody rb;

    private void Start()
    {
        ovrg = GetComponent<OVRGrabbable>();
        rb = GetComponent<Rigidbody>();

        movementTimer = 0.0f;
    }

    private void Update()
    {
        movementTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (ovrg.isGrabbed)
        {
            movementTimer = 0;
        }

        if (movementTimer > 0)
        {
            rb.velocity.Set(0, 0, 0);
            rb.MovePosition(Vector3.Lerp(transform.position, targetHand.transform.position, 0.01f));
            rb.AddForce(-1 * rb.mass * Physics.gravity);
        }
    }

    override public void getPointed(GameObject handGO)
    {
        movementTimer = 1.0f;
        targetHand = handGO;
    }
}
