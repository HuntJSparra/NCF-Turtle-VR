using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravitateTowardsPlayer : MonoBehaviour
{
    public float lerpVal;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(Vector3.Lerp(transform.position, Camera.main.transform.position + 0.5f * Vector3.down, lerpVal*Time.deltaTime));
    }
}
