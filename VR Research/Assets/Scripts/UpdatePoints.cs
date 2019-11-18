using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePoints : MonoBehaviour
{
    private static int points;
    private Text stars;
    // Start is called before the first frame update
    void Start()
    {
        points = 1;
        stars = GetComponentInChildren<Text>();
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
        string temp = "";
        for(int i = 0; i < points; i++)
        {
            temp += "*";
        }
        stars.text = temp;
    }
}
