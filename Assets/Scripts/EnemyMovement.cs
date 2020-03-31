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

    #region attack_functions
    private void Burn()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 0.2f, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Player"))
            {
                hit.transform.GetComponent<EggController>().TakeDamage(burnDamage);
                Debug.Log("burned egg");
            }
        }
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit trigger");
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("will burn");
            Burn();
        }
    }
    #endregion

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
