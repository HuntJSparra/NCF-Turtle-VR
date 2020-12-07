using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoda : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soda")
        {
            Destroy(other.gameObject);
            UpdatePoints.instance.addPoint();
        }
    }
}
