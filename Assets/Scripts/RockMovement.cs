using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    private Vector3 initial;
    private Vector3 replacement;
    bool isMoving;
    bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        initial = transform.position;
        replacement = transform.position + new Vector3(3, 0, 0);
        isMoving = false;
        moveRight = true;
        StartCoroutine(enemyRight());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && moveRight)
        {
            StartCoroutine(enemyRight());
        }
        if (!isMoving && !moveRight)
        {
            StartCoroutine(enemyLeft());
        }
    }

    IEnumerator enemyRight()
    {
        isMoving = true;
        float elapsedTime = 0;
        float totalTransitionTime = 5;
        while (transform.position != replacement)
        {
            transform.position = Vector3.Lerp(initial, replacement, elapsedTime / totalTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        moveRight = false;
        isMoving = false;
    }

    IEnumerator enemyLeft()
    {
        isMoving = true;
        float elapsedTime = 0;
        float totalTransitionTime = 5;
        while (transform.position != initial)
        {
            transform.position = Vector3.Lerp(replacement, initial, elapsedTime / totalTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        moveRight = true;
        isMoving = false;

    }
}
