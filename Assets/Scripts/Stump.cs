using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Egg"))
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
