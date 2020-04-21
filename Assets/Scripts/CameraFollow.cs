using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;

    public GameObject blackScreen;

    private void Awake()
    {
        float centerX = GetMinPlayer();
        transform.position = new Vector3(centerX, transform.position.y, transform.position.z) + offset;
    }
    private void LateUpdate()
    {
        float centerX = GetMinPlayer();

        if (transform.position.x <= centerX + offset.x)
        {
            Vector3 newPos = new Vector3(centerX, transform.position.y, transform.position.z) + offset;
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
    public void Respawn()
    {
        StartCoroutine(FadeInAndOut());
    }

    IEnumerator FadeInAndOut()
    {
        float elapsedTime = 0;
        Color original = blackScreen.GetComponent<SpriteRenderer>().color;
        Color opaque = new Color(original.r, original.g, original.b, 1f);
        while (elapsedTime < 1f)
        {
            blackScreen.GetComponent<SpriteRenderer>().color = Color.Lerp(original, opaque, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        float centerX = GetMinPlayer();
        transform.position = new Vector3(centerX, transform.position.y, transform.position.z) + offset;

        elapsedTime = 0;
        while (elapsedTime < 1f)
        {
            blackScreen.GetComponent<SpriteRenderer>().color = Color.Lerp(opaque, original, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


    }

   
}
