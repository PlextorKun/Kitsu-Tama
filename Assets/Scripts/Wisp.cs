using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : MonoBehaviour
{
    public int burnDamage;

    #region interact_functions
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit wisp collider");
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
        if (collision.transform.CompareTag("Egg"))
        {
            Debug.Log("hit trigger");
            Debug.Log("will die");
            Die();
        }
    }
    #endregion

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
