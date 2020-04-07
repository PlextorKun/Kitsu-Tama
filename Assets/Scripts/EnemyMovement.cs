using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 original;
    private Vector3 other;
    bool moving;
    bool move_right;
    public int burnDamage;

    // Start is called before the first frame update
    void Start()
    {
        original = transform.position;
        other = transform.position + new Vector3(3, 0, 0);
        moving = false;
        move_right = true;
        StartCoroutine(EnemyMoveRight());
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving && move_right)
        {
            StartCoroutine(EnemyMoveRight());
        }
        if (!moving && !move_right)
        {
            StartCoroutine(EnemyMoveLeft());
        }
    }

    #region interact_functions
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit collider");
        if (collision.transform.CompareTag("Egg"))
        {
            collision.transform.GetComponent<EggController>().TakeDamage(burnDamage);
            Debug.Log("burned egg");
        }

        if (collision.transform.CompareTag("Fox"))
        {
            collision.transform.GetComponent<FoxController>().TakeDamage(burnDamage);
            Debug.Log("burned fox");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit trigger");
        Debug.Log("will die");
        Die();
    }
    #endregion

    public void Die()
    {
        Destroy(this.gameObject);
    }

    IEnumerator EnemyMoveRight()
    {
        moving = true;
        float elapsedTime = 0;
        float totalTransitionTime = 2;
        while (transform.position != other)
        {
            transform.position = Vector3.Lerp(original, other, elapsedTime / totalTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        move_right = false;
        moving = false;
    }

    IEnumerator EnemyMoveLeft()
    {
        moving = true;
        float elapsedTime = 0;
        float totalTransitionTime = 2;
        while (transform.position != original)
        {
            transform.position = Vector3.Lerp(other, original, elapsedTime / totalTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        move_right = true;
        moving = false;

    }
}
