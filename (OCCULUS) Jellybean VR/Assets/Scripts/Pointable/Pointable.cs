using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pointable : MonoBehaviour
{
    //public GameObject canvas;
    protected bool pointedAt,firstPoint;
    public string itemTag;
    // Start is called before the first frame update
    void Start()
    {
        pointedAt = false;
        firstPoint = false;
    }

    virtual public void getPointed(GameObject handGO)
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