using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Fox"))
        {
            collision.transform.GetComponent<FoxController>().TakeDamage(2);
            Destroy(this.gameObject);
        }

        if (collision.transform.CompareTag("Egg"))
        {
            collision.transform.GetComponent<EggController>().TakeDamage(2);
            Destroy(this.gameObject);
        }

        if (!collision.transform.CompareTag("Wisp"))
        {
            Destroy(this.gameObject);

        }

    }
}
