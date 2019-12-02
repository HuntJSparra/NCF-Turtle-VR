using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Water")
        {
            Destroy(other.gameObject);
            UpdatePoints.addPoint();
        }
    }
}