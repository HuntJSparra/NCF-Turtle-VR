using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trash")
        {
            Destroy(other.gameObject);
            UpdatePoints.instance.addPoint();
        }
    }
}
