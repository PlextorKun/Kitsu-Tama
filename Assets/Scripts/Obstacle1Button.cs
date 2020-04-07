using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1Button : MonoBehaviour
{
    public Color activatedColor;
    public Color inactivatedColor;

    public GameObject wall;

    private bool activated = true;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (activated)
        {
            gameObject.GetComponent<SpriteRenderer>().color = inactivatedColor;
            wall.GetComponent<Obstacle1Wall>().move();
            activated = false;
        }
        

    }

    public void activateButton()
    {
        gameObject.GetComponent<SpriteRenderer>().color = activatedColor;
        activated = true;
    }

}
