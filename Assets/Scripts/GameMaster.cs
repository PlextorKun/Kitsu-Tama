using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance = null;

    //public GameObject[] spawnpoints_fox;
    //public GameObject[] spawnpoints_egg;

    [SerializeField] Transform spawn_fox;
    [SerializeField] Transform spawn_egg;


    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);

        //spawnpoints_fox = new GameObject[3];
        //spawnpoints_egg = new GameObject[3];
    }
    

    public void RespawnEgg(EggController egg)
    {
        egg.Heal(10);
        egg.gameObject.transform.position = spawn_egg.position;
    }

    public void RespawnFox(FoxController fox)
    {
        fox.Heal(10);
        fox.gameObject.transform.position = spawn_fox.position;
    }
}
