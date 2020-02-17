using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuausticSurface : MonoBehaviour
{
    public float FPS = 30.0f;
    public Texture[] causticsTextures;

    private int currentCaustic = 0;
    private new Material causticsMat;

    // Start is called before the first frame update
    void Start()
    {
        causticsMat = GetComponent<Renderer>().material;

        InvokeRepeating("ChangeCaustic", 1.0f/FPS, 1.0f/FPS);
    }

    void ChangeCaustic()
    {
        currentCaustic = (currentCaustic + 1) % causticsTextures.Length;
        causticsMat.SetTexture("_BumpMap", causticsTextures[currentCaustic]);
    }
}
