using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePoints : MonoBehaviour
{
    private static int points;
    //private Text RightStars, LeftStars;
    //public GameObject LeftHand, RightHand;
    private static bool coral;
    public List<GameObject> starfish;
    // Start is called before the first frame update
    void Start()
    {
        points = 1;
        //RightStars = RightHand.GetComponentInChildren<Text>();
        //LeftStars = LeftHand.GetComponentInChildren<Text>();
        coral = false;
    }

    public static void coralPoint()
    {
        if (!coral)
        {
            addPoint();
            coral = true;
        }
    }

    public static void addPoint()
    {
        points++;
    }

    public static void removePoint()
    {
        points--;
    }

    // Update is called once per frame
    void Update()
    {
        if (points <= starfish.Count) {
            for (int i = 0; i < points; i++) {
                starfish[i].SetActive(true);
            }
            for (int i = points; i < 10; i++) {
                starfish[i].SetActive(false);
            }
        }
    }
}
