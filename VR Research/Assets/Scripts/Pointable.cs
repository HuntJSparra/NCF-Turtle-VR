using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointable : MonoBehaviour
{
    private GameObject childObj;
    bool pointedAt;
    // Start is called before the first frame update
    void Start()
    {
        pointedAt = false;
        childObj = gameObject.transform.Find("Canvas").gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (pointedAt)
        {
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