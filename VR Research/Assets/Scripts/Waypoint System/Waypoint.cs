using System.Collections;
using UnityEngine;

public interface Waypoint
{
    bool checkCompletion(Transform transform);
    Vector3 getPosition();
}

public class VectorWaypoint : Waypoint
{
    private Vector3 position;

    public VectorWaypoint(Vector3 position)
    {
        this.position = position;
    }

    public bool checkCompletion(Transform ownerTransform)
    {
        return Vector3.Distance(ownerTransform.position, position) < 0.5f;
    }

    public Vector3 getPosition() {
        return this.position;
    }
}

public class TransformWaypoint : Waypoint
{
    private Transform transform;

    public TransformWaypoint(Transform targetTransform)
    {
        this.transform = targetTransform;
    }

    public bool checkCompletion(Transform ownerTransform)
    {
        return Vector3.Distance(ownerTransform.position, transform.position) < 0.5f;
    }

    public Vector3 getPosition() {
        return this.transform.position;
    }
}

public class ManualTransformWaypoint : Waypoint
{
    private Transform transform;

    public ManualTransformWaypoint(Transform targetTransform)
    {
        this.transform = targetTransform;
    }

    public bool checkCompletion(Transform ownerTransform)
    {
        return false;
    }

    public Vector3 getPosition() {
        return this.transform.position;
    }
}