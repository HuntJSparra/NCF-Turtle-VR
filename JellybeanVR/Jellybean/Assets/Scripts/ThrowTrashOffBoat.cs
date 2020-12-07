using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTrashOffBoat : MonoBehaviour
{
    [SerializeField]
    private float lookAtHoverEulerMargin;

    private bool scenarioStarted = false;

    private Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Maybe highlight and then remove when a button is pressed?
        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0))
        {
            if (IsHighlighted() && !scenarioStarted)
            {
                scenarioStarted = true;
                GetComponent<Animator>().SetTrigger("Fall");
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
}
