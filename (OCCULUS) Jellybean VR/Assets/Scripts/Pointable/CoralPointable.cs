using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralPointable : Pointable
{
    public GameObject canvas;

    void LateUpdate()
    {
        if (pointedAt)
        {
            if (firstPoint)
            {
                UpdatePoints.instance.coralPoint();
                firstPoint = false;
            }
            canvas.GetComponent<CanvasCollect>().turnOn();
            pointedAt = false;
        }
    }
}
