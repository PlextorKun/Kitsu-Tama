using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalButton : MonoBehaviour
{
    public GameObject portal;

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
        portal.GetComponent<LockedPortal>().openPortal();
        Debug.Log("opening portal");
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }


    void OnTriggerExit2D(Collider2D coll)
    {
        portal.GetComponent<LockedPortal>().closePortal();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
