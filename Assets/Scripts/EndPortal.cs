using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject partner;
    public GameManager manager;
    public bool triggered = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.gameObject.SetActive(false); 
        triggered = true;
        if (partner.GetComponent<EndPortal>().triggered)
        {
            Debug.Log("switch to end");
            manager.EndScene();
        }
    }
}
