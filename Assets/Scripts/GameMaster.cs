using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject[] spawnpoints = new GameObject[3];

    public static void RespawnEgg(EggController egg)
    {
        Destroy(egg.gameObject);
    }

    public static void RespawnFox(FoxController fox)
    {
        Destroy(fox.gameObject);
    }
}
