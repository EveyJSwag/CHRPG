using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerChar : MonoBehaviour
{
    public GameObject player;
    private Manager gameManager_properties = Manager.getInstance();
    private Vector3 spawnPoint;
    void Start()
    {
        spawnPoint = gameManager_properties.get_jerry_last_pos();
        Instantiate(player, spawnPoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
