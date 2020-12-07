using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtlePathfinding : MonoBehaviour
{
    public Transform pivot; // Point that the turtle "orbits" around under normal circumstances
    private float startDistance; // Distance from pivot; stored in case we need to get back to that distance ever

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startDistance = Vector3.Distance(pivot.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.position, Vector3.up, speed * Time.deltaTime);
    }
}
