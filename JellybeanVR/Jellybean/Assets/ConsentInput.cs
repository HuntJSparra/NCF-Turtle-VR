using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsentInput : MonoBehaviour
{
    private bool transitioning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0))
        {
            if (transitioning == false)
            {
                SceneTransition.instance.ChangeScene("Menu");
                transitioning = true;
            }
        }
    }
}
