using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] Transform[] spawn_fox;
    [SerializeField] Transform[] spawn_egg;

    float checkpoint = 0;

    public void AddCheckpoint()
    {
        checkpoint += 0.5f;
    }

    public void RespawnEgg(EggController egg)
    {
        egg.gameObject.transform.position = spawn_egg[(int)checkpoint].position;
        egg.Heal(10);

        GameObject f = GameObject.FindWithTag("Fox");
        f.transform.position = spawn_fox[(int)checkpoint].position;
        FoxController fox = f.GetComponent<FoxController>();
        fox.Heal(10);
        if (fox.CheckCountdown())
        {
            fox.SwitchSides();
        }

        GameObject cam = GameObject.FindWithTag("MainCamera");
        cam.GetComponent<CameraFollow>().Respawn();
    }

    public void RespawnFox(FoxController fox)
    {
        fox.gameObject.transform.position = spawn_fox[(int)checkpoint].position;
        fox.Heal(10);

        GameObject e = GameObject.FindWithTag("Egg");
        e.transform.position = spawn_egg[(int)checkpoint].position;
        EggController egg = e.GetComponent<EggController>();
        egg.Heal(10);
        if (egg.CheckCountdown())
        {
            egg.SwitchSides();
        }

        GameObject cam = GameObject.FindWithTag("MainCamera");
        cam.GetComponent<CameraFollow>().Respawn();
    }
}
