using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalButton : MonoBehaviour
{
    public GameObject portal;
    public Color openColor;
    public Color closedColor;

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
        if (coll.transform.CompareTag("Egg") || coll.transform.CompareTag("Fox"))
        {
            portal.GetComponent<LockedPortal>().openPortal();
            Debug.Log("opening portal");
            gameObject.GetComponent<SpriteRenderer>().color = openColor;
        }
        
    }


    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.transform.CompareTag("Egg") || coll.transform.CompareTag("Fox"))
        {
            portal.GetComponent<LockedPortal>().closePortal();
            gameObject.GetComponent<SpriteRenderer>().color = closedColor;
        }
    }
}
