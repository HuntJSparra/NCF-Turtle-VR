using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackMovementInput : MonoBehaviour
{
    private readonly float ENTRIES_PER_SECOND = 1;

    private float TIME_BETWEEN_ENTRIES;
    private float timeSinceLastEntry = 0.0f;

    private void Awake()
    {
        TIME_BETWEEN_ENTRIES = 1 / ENTRIES_PER_SECOND;
    }

    // Update is called once per frame
    void Update()
    {
        var isInputting = (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0));

        if (isInputting)
        {
            Records.AddEntry(transform.eulerAngles, isInputting, SceneManager.GetActiveScene().name);
            timeSinceLastEntry = 0.0f;
        }
        else if (timeSinceLastEntry >= TIME_BETWEEN_ENTRIES)
        {
            Records.AddEntry(transform.eulerAngles, isInputting, SceneManager.GetActiveScene().name);
            timeSinceLastEntry = 0.0f;
        }

        timeSinceLastEntry += Time.deltaTime;
    }
}
