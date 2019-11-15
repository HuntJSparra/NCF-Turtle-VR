using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointable : MonoBehaviour
{
    private GameObject childObj;
    bool pointedAt,firstPoint;
    // Start is called before the first frame update
    void Start()
    {
        pointedAt = false;
        firstPoint = true;
        childObj = gameObject.transform.Find("Canvas").gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (pointedAt)
        {
            if (firstPoint)
            {
                UpdatePoints.addPoint();
                firstPoint = false;
            }
            childObj.SetActive(true);
            pointedAt = false;
        }
        else
        {
            childObj.SetActive(false);
        }
    }

    public void getPointed()
    {
        pointedAt = true;
    }
}