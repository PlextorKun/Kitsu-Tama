using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static void KillEgg(EggController egg)
    {
        Destroy(egg.gameObject);
    }

    public static void KillFox(FoxController fox)
    {
        Destroy(fox.gameObject);
    }
}
