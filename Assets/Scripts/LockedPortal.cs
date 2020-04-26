using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedPortal : MonoBehaviour
{
    private List<GameObject> alreadyPortaled = new List<GameObject>();
    private List<GameObject> onPortal = new List<GameObject>();
    private int openButtons = 0;

    public Color openColor;
    public Color closedColor;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (openButtons > 0)
        {
            foreach (GameObject gameobj in onPortal)
            {
                if (gameobj.CompareTag("Fox") && !alreadyPortaled.Contains(gameobj))
                {
                    gameobj.GetComponent<FoxController>().portal(transform.position);
                    Debug.Log("portalling fox");
                    alreadyPortaled.Add(gameobj);
                } else if (gameobj.CompareTag("Egg") && !alreadyPortaled.Contains(gameobj))
                {
                    gameobj.GetComponent<EggController>().portal(transform.position);
                    alreadyPortaled.Add(gameobj);
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(!onPortal.Contains(coll.gameObject))
        {
            onPortal.Add(coll.gameObject);
            Debug.Log("adding object to portal list");
        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        onPortal.Remove(coll.gameObject);
    }

    public void openPortal()
    {
        openButtons += 1;
        gameObject.GetComponent<SpriteRenderer>().color = openColor;
        anim.SetBool("Open", true);
    }

    public void closePortal()
    {
        openButtons -= 1;
        if (openButtons <= 0)
        {
            anim.SetBool("Open", false);
            alreadyPortaled = new List<GameObject>();
            gameObject.GetComponent<SpriteRenderer>().color = closedColor;
        }
    }

}
