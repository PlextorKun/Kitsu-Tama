using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Fox"))
        {
            collision.gameObject.GetComponent<FoxController>().TakeDamage(10);
        }
        else if (collision.transform.CompareTag("Egg"))
        {
            collision.gameObject.GetComponent<EggController>().TakeDamage(10);
        }
    }

}
