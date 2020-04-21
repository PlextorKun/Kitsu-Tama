using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCheckpoint : MonoBehaviour
{
    bool unactivated = true;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if ((coll.transform.CompareTag("Egg") || coll.transform.CompareTag("Fox")) && unactivated)
        {
            unactivated = false;
            GameObject r = GameObject.FindWithTag("Respawn");
            r.GetComponent<Respawner>().AddCheckpoint();
        }
    }
}
