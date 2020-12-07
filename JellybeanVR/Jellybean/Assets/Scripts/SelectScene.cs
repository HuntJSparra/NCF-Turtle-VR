using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectScene : MonoBehaviour
{
    public float lookAtHoverEulerMargin;

    [SerializeField]
    private GameObject[] options;

    [SerializeField]
    private string[] scenes;

    private int? selectedOption = 0;
    private bool scenarioStarted = false;

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    protected Transform camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        var optionLookAngles = new float[options.Length];
        for (int i=0; i<options.Length; i++)
        {
            var option = options[i];
            optionLookAngles[i] = GetAngleBetweenLook(option);
        }

        var (isAngleHighlightable, smallestAngleIndex, smallestAngle) = GetSmallestAngle(optionLookAngles);
        if (isAngleHighlightable)
        {
            selectedOption = smallestAngleIndex;
            HighlightOptions(smallestAngleIndex);
        }
        else
        {
            selectedOption = null;
            HighlightOptions(); // Which is so say, highlight nothing
        }

        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0))
        {
            if (!(selectedOption is null) && !scenarioStarted)
            {
                SceneTransition.instance.ChangeScene(scenes[(int)selectedOption]);
                scenarioStarted = true;
            }
        }
    }

    float GetAngleBetweenLook(GameObject option)
    {
        var cameraLookVector = camera.forward;
        var lookAtVector = (option.transform.position - camera.position).normalized;

        var angleBetween = Vector3.Angle(cameraLookVector, lookAtVector);

        return angleBetween;
    }

    bool AngleHighlightable(float angle)
    {
        return (angle < lookAtHoverEulerMargin);
    }

    (bool isHighlightable, int smallestAngleIndex, float smallestAngle) GetSmallestAngle(float[] angles)
    {
        int runningSmallestIndex = 0;
        float runningSmallest = angles[0];
        for (int i=1; i<angles.Length; i++)
        {
            if (angles[i] < runningSmallest)
            {
                runningSmallestIndex = i;
                runningSmallest = angles[i];
            }
        }

        return (AngleHighlightable(runningSmallest), runningSmallestIndex, runningSmallest);
    }

    void HighlightOptions(int optionIndex=-1)
    {
        for (int i=0; i<options.Length; i++)
        {
            var animator = options[i].GetComponent<Animator>();
            if (i == optionIndex)
            {
                animator.SetBool("Selected", true);
            }
            else
            {
                animator.SetBool("Selected", false);
            }
        }
    }
}
