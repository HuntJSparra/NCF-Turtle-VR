﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trash" || other.gameObject.tag == "Soda")
        {
            Destroy(other.gameObject);
            UpdatePoints.addPoint();
        }
    }
}
