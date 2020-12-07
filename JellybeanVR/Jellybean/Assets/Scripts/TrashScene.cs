using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScene : MonoBehaviour
{
    public static TrashScene instance;

    private int trashRemaining;
    private bool trashCollected = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TrashCollected()
    {
        trashRemaining--;

        if (!trashCollected && (trashRemaining <= 0))
        {
            trashCollected = true;
            SceneTransition.instance.ChangeScene("Menu");
        }
    }

    public void AddTrash()
    {
        trashRemaining++;
    }
}
