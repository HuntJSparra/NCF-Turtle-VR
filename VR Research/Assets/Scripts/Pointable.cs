using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointable : MonoBehaviour
{
    public GameObject canvas;
    bool pointedAt,firstPoint;
    public string itemTag;
    // Start is called before the first frame update
    void Start()
    {
        pointedAt = false;
        firstPoint = false;
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
            canvas.GetComponent<CanvasCollect>().turnOn();
            pointedAt = false;
        }
    }

    public void getPointed()
    {
        pointedAt = true;
    }

    public void setFirst()
    {
        firstPoint = true;
    }

    public string giveTag()
    {
        return itemTag;
    }
}