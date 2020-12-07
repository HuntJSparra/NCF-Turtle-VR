using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausticsAnimation : MonoBehaviour
{
    [SerializeField]
    private int FPS = 30;

    [SerializeField]
    Texture2D[] causticsTextures;

    private double timeSinceTextureChange = 0.0;
    private int currentTexture = 0;
    
    void Start()
    {
        GetComponent<Light>().cookie = causticsTextures[0];
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceTextureChange += Time.deltaTime;

        if (timeSinceTextureChange >= (1.0 / FPS))
        {
            currentTexture = (currentTexture + 1) % causticsTextures.Length;
            GetComponent<Light>().cookie = causticsTextures[currentTexture];

            timeSinceTextureChange = 0;
        }
    }
}
