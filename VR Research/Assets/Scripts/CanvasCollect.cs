using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCollect : MonoBehaviour
{
    private int on;
    private GameObject textObject, imageObject;
    public List<GameObject> otherObjects;

    private void Start()
    {
        textObject = gameObject.GetComponentInChildren<Text>().gameObject;
        imageObject = gameObject.GetComponentInChildren<Image>().gameObject;
        textObject.SetActive(false);
        imageObject.SetActive(false);
        if (otherObjects.Count > 0)
        {
            foreach (GameObject obj in otherObjects)
            {
                obj.SetActive(false);
            }
        }
    }

    private void LateUpdate()
    {
        if (on > 0)
        {
            activate();
        }
        else
        {
            deactivate();
        }
        on = 0;
        
    }

    public void turnOn()
    {
        on++;
    }

    private void activate()
    {
        textObject.SetActive(true);
        imageObject.SetActive(true);
        if (otherObjects.Count > 0)
        {
            foreach (GameObject obj in otherObjects)
            {
                obj.SetActive(true);
            }
        }
    }

    private void deactivate()
    {
        textObject.SetActive(false);
        imageObject.SetActive(false);
        if (otherObjects.Count > 0)
        {
            foreach (GameObject obj in otherObjects)
            {
                obj.SetActive(false);
            }
        }
    }
}
