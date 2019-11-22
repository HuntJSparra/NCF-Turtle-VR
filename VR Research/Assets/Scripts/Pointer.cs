using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 fwd = gameObject.transform.forward;
        Vector3 str = gameObject.transform.position;
        Ray ray = new Ray(str, fwd);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag.Equals("pointable"))
            {
                Pointable temp = hit.collider.gameObject.GetComponent<Pointable>();
                temp.getPointed();
                string tag = temp.giveTag();
                if (!LaserPointerControl.containsTag(tag))
                {
                    temp.setFirst();
                    LaserPointerControl.addTag(tag);
                }
            }
        }
    }
}
