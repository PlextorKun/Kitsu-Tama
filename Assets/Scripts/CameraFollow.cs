using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
    private void LateUpdate()
    {
        if (targets.Count == 1)
        {
            return;
        }

        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = newPosition;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int index = 0; index < targets.Count; index++)
        {
            bounds.Encapsulate(targets[index].position);
        }
        return bounds.center;
    }
}
