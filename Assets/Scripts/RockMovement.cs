using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    private Vector3 initial;
    private Vector3 replacement;
    bool isMoving;
    bool moveRight;
    public float speed = 0.25f;
    Vector3 pointA;
    Vector3 pointB;
    int health;
    int damage = 2;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Egg"))
        {
            collision.transform.GetComponent<EggController>().TakeDamage(damage);
        }

        if (collision.transform.CompareTag("Fox"))
        {
            collision.transform.GetComponent<FoxController>().TakeDamage(damage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pointA = new Vector3(142, 2, 0);
        pointB = new Vector3(162, 2, 0);
        //initial = transform.position;
        //replacement = transform.position + new Vector3(3, 0, 0);
        //isMoving = false;
        //moveRight = true;
        //StartCoroutine(enemyRight());
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
        //if (!isMoving && moveRight)
        //{
        //   StartCoroutine(enemyRight());
        //}
        //if (!isMoving && !moveRight)
        //{
        //   StartCoroutine(enemyLeft());
        //}
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

    public void Die()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            health -= 1;
        }
        
    }

}
