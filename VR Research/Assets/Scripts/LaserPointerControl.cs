using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerControl : MonoBehaviour
{
    public LineRenderer Left, Right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) == true && OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger) == false)
        {
            Left.enabled = true;
        }
        else
        {
            Left.enabled = false;
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) == true && OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger) == false)
        {
            Right.enabled = true;
        }
        else
        {
            Right.enabled = false;
        }
    }
}
