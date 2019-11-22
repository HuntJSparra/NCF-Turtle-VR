using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerControl : MonoBehaviour
{
    public GameObject Left, Right;
    static ArrayList tags;
    // Start is called before the first frame update
    void Start()
    {
        tags = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) == true && OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger) == false)
        {
            Left.SetActive(true);
        }
        else
        {
            Left.SetActive(false);
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) == true && OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger) == false)
        {
            Right.SetActive(true);
        }
        else
        {
            Right.SetActive(false);
        }
    }

    public static bool containsTag(string tag)
    {
        return tags.Contains(tag);
    }

    public static void addTag(string tag)
    {
        tags.Add(tag);
    }
}
