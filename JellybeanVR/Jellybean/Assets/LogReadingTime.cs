using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogReadingTime : MonoBehaviour
{
    private readonly float READING_EULER_ANGLE = 20;

    public string textNickname;

    private bool readingLastFrame = false;
    private float readingDuration = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (readingLastFrame)
        {
            readingDuration += Time.deltaTime;
        }

        if (GetAngleBetween() < READING_EULER_ANGLE)
        {
            readingLastFrame = true;
        }
        else if (readingLastFrame)
        {
            WebAPI.LogReading(textNickname, readingDuration);

            // Clean-Up/Reset
            readingLastFrame = false;
            readingDuration = 0.0f;
        }
    }

    private float GetAngleBetween()
    {
        var cameraForward  = Camera.main.transform.forward;
        var readingForward = (transform.position - Camera.main.transform.position); // The text is on the opposite side, so we don't need to change things

        return Vector3.Angle(cameraForward, readingForward);
    }

    private void OnDestroy()
    {
        if (readingLastFrame)
        {
            WebAPI.LogReading(textNickname, readingDuration);
        }
    }
}