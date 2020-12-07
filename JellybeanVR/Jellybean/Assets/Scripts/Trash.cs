using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR.Cardboard;

public class Trash : MonoBehaviour
{
    [SerializeField]
    private float lookAtHoverEulerMargin;

    [SerializeField]
    private GameObject bubbleBurst;

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    protected Transform camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        TrashScene.instance.AddTrash();
    }

    // Update is called once per frame
    void Update()
    {
        // Maybe highlight and then remove when a button is pressed?
        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetMouseButtonDown(0))
        {
            if (IsHighlighted())
            {
                TrashScene.instance.TrashCollected();
                GetComponent<Renderer>().enabled = false;
                Instantiate(bubbleBurst, transform.position, Quaternion.identity);
                Destroy(gameObject);
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
