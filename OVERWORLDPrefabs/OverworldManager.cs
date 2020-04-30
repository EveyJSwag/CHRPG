using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldManager : MonoBehaviour
{
    // Start is called before the first frame update\
    public GameObject playerChar;
    public GameObject enemies;
    SpawnEnemyOverworld enemies_properties;
    float startTime;
    void Start()
    {

        enemies_properties = enemies.GetComponent<SpawnEnemyOverworld>();
    }

    // Update is called once per frame
    void Update()
    {
        ////////////////////////////////////////////////////////////////////
        // Check to see if the distance from any enemy to the player < 15 //
        ////////////////////////////////////////////////////////////////////
               
        

    }
}
