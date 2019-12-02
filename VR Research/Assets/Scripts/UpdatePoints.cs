using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePoints : MonoBehaviour
{
    private static int points;
    private Text RightStars, LeftStars;
    public GameObject LeftHand, RightHand;
    // Start is called before the first frame update
    void Start()
    {
        points = 1;
        RightStars = RightHand.GetComponentInChildren<Text>();
        LeftStars = LeftHand.GetComponentInChildren<Text>();
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
        switch (points)
        {
            case 1:
                RightStars.text = "*";
                LeftStars.text = ""; break;
            case 2:
                RightStars.text = "*";
                LeftStars.text = "*"; break;
            case 3:
                RightStars.text = "**";
                LeftStars.text = "*"; break;
            case 4:
                RightStars.text = "**";
                LeftStars.text = "**"; break;
            case 5:
                RightStars.text = "***";
                LeftStars.text = "**"; break;
            case 6:
                RightStars.text = "***";
                LeftStars.text = "***"; break;
            case 7:
                RightStars.text = "****";
                LeftStars.text = "***"; break;
            case 8:
                RightStars.text = "****";
                LeftStars.text = "****"; break;
            case 9:
                RightStars.text = "*****";
                LeftStars.text = "****"; break;
            case 10:
                RightStars.text = "*****";
                LeftStars.text = "*****"; break;
            default:
                RightStars.text = "";
                LeftStars.text = ""; break;
        }
    }
}
