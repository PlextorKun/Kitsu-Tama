using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticPortal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //TASK 3
        //HINT: Use coll.gameObject to get a reference to coll's GameObject
        if (coll.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<FoxController>().automaticPortal();
            Debug.Log("calling players portal method");
        }
    }
    
}
