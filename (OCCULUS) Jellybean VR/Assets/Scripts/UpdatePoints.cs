using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePoints : MonoBehaviour
{
    private static UpdatePoints _instance;
    public static UpdatePoints instance
    {
        get
        {
            return _instance;
        }
    }

    private int points;
    //private Text RightStars, LeftStars;
    //public GameObject LeftHand, RightHand;
    private bool coral;
    public List<GameObject> starfish;

    public AudioSource pointsSFXSource;
    public AudioClip positiveSFX;
    public AudioClip negativeSFX;

    public ParticleSystem bubbles;

    // Start is called before the first frame update
    private void Awake()
    {
        if (UpdatePoints.instance != null)
        {
            throw new InvalidOperationException("Singleton has already been assigned");
        }

        UpdatePoints._instance = this;
    }

    void Start()
    {
        points = 1;
        //RightStars = RightHand.GetComponentInChildren<Text>();
        //LeftStars = LeftHand.GetComponentInChildren<Text>();
        coral = false;

        UpdateStarfish();
    }

    public void coralPoint()
    {
        if (!coral)
        {
            addPoint();
            coral = true;
        }
    }

    public void addPoint()
    {
        pointsSFXSource.PlayOneShot(positiveSFX);
        points = Mathf.Min(points + 1, starfish.Count);
        UpdateStarfish(true);
    }

    public void removePoint()
    {
        pointsSFXSource.PlayOneShot(negativeSFX);
        points = Mathf.Max(0, points-1);
        UpdateStarfish();
    }

    void UpdateStarfish(bool showBubbles=false)
    {
        if (points <= starfish.Count)
        {
            for (int i = 0; i < points; i++)
            {
                starfish[i].SetActive(true);
            }
            for (int i = points; i < 10; i++)
            {
                starfish[i].SetActive(false);
            }

            if (showBubbles)
            {
                bubbles.gameObject.transform.position = starfish[points - 1].transform.position;
                bubbles.Play();
            }
        }
    }
}
