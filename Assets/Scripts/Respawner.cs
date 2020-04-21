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

        GameObject fox = GameObject.FindWithTag("Fox");
        fox.transform.position = spawn_fox[(int)checkpoint].position;
        fox.GetComponent<FoxController>().Heal(10);

        GameObject cam = GameObject.FindWithTag("MainCamera");
        cam.GetComponent<CameraFollow>().Respawn();
    }

    public void RespawnFox(FoxController fox)
    {
        fox.gameObject.transform.position = spawn_fox[(int)checkpoint].position;
        fox.Heal(10);

        GameObject egg = GameObject.FindWithTag("Egg");
        egg.transform.position = spawn_egg[(int)checkpoint].position;
        egg.GetComponent<EggController>().Heal(10);

        GameObject cam = GameObject.FindWithTag("MainCamera");
        cam.GetComponent<CameraFollow>().Respawn();
    }
}
