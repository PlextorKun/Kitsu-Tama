using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1Wall : MonoBehaviour
{
    public Color movingColor;
    public Color stationaryColor;
    public GameObject button;

    private bool inOriginalPos = true;

    public void move()
    {
        gameObject.GetComponent<SpriteRenderer>().color = movingColor;
        if (inOriginalPos)
        {
            StartCoroutine(moveD());
        } else
        {
            StartCoroutine(moveU());
        }
        inOriginalPos = !inOriginalPos;
    }

    private void finishMoving()
    {
        gameObject.GetComponent<SpriteRenderer>().color = stationaryColor;
        button.GetComponent<Obstacle1Button>().activateButton();
    }

    IEnumerator moveD()
    {
        float elapsedTime = 0;
        float totalTransitionTime = 2;
        Vector3 original = transform.position;
        Vector3 other = new Vector3(transform.position.x, transform.position.y + gameObject.GetComponent<BoxCollider2D>().bounds.size.y, transform.position.z);
        while (transform.position != other)
        {
            transform.position = Vector3.Lerp(original, other, elapsedTime / totalTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        finishMoving();
    }

    IEnumerator moveU()
    {
        float elapsedTime = 0;
        float totalTransitionTime = 2;
        Vector3 original = transform.position;
        Vector3 other = new Vector3(transform.position.x, transform.position.y + gameObject.GetComponent<BoxCollider2D>().bounds.size.y, transform.position.z);
        while (transform.position != other)
        {
            transform.position = Vector3.Lerp(original, other, elapsedTime / totalTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        finishMoving();
    }
}
