using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBag : MonoBehaviour
{
    public GameObject turtle;

    [SerializeField]
    private float lookAtHoverEulerMargin;

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    protected Transform camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    private bool scenarioStarted = false;

    void Start()
    {
        camera = Camera.main.transform;
    }

    void Update()
    {
        // Maybe highlight and then remove when a button is pressed?
        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0))
        {
            if (IsHighlighted() && !scenarioStarted)
            {
                StartScenario();
            }
        }
    }

    bool IsHighlighted()
    {
        var cameraLookVector = camera.forward;
        var lookAtTrashVector = (transform.position - camera.position).normalized;

        var angleBetween = Vector3.Angle(cameraLookVector, lookAtTrashVector);

        return (angleBetween < lookAtHoverEulerMargin);
    }

    void StartScenario()
    {
        turtle.SetActive(true);
        scenarioStarted = true;
        turtle.GetComponent<Animator>().SetTrigger("Start Scenario");
    }
}
