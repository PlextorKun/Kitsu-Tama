using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;

    private void Awake()
    {
        float centerX = GetMinPlayer();
        transform.position = new Vector3(centerX, transform.position.y, transform.position.z);
    }
    private void LateUpdate()
    {
        float centerX = GetMinPlayer();

        if (transform.position.x <= centerX)
        {
            Vector3 newPos = new Vector3(centerX, transform.position.y, transform.position.z);
            transform.position = newPos;
        }

    }

    private float GetMinPlayer()
    {
        float min = targets[0].position.x;
        for (int i = 1; i < targets.Capacity; i++)
        {
            if (targets[i].position.x < min)
            {
                min = targets[i].position.x;
            }
        }
        return min;
    }
}
