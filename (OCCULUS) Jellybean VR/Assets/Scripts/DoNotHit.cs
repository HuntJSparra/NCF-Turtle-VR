using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotHit : MonoBehaviour
{
    string[] badTags; // Objects to detect if the player is hitting with

    public float cooldownDuration;
    public bool coolingDown;

    void Awake()
    {
        badTags = new string[]{"Soda", "Water", "Trash"};
    }

    void Start()
    {
        coolingDown = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (!coolingDown && Array.Exists(badTags, tag => (tag == col.gameObject.tag))) {
            UpdatePoints.instance.removePoint();
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        // Prevent duplicate cooldowns
        if (coolingDown)
        {
            yield return new WaitForEndOfFrame();
        }
        else
        {
            coolingDown = true;
            yield return new WaitForSeconds(cooldownDuration);
            coolingDown = false;
        }
    }
}
