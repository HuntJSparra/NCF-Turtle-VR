using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    Text fpsText;

    private void Start()
    {
        fpsText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        fpsText.text = string.Format("{0:0} FPS", (1 / Time.deltaTime));
    }
}
