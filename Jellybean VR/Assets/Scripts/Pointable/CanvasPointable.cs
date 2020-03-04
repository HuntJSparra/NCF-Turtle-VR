using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPointable : Pointable
{
    public GameObject canvas;

    void LateUpdate()
    {
        if (pointedAt)
        {
            if (firstPoint)
            {
                UpdatePoints.instance.addPoint();
                firstPoint = false;
            }
            canvas.GetComponent<CanvasCollect>().turnOn();
            pointedAt = false;
        }
    }
}
