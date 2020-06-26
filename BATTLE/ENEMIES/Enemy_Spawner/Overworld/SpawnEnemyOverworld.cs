using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOverworld : MonoBehaviour
{
    public GameObject spawne;
    public Enemy[] enemies;
    public Vector2 levelBorderPos;
    public Vector2 levelBorderNeg;
    public int maxEnemyNum;
    public int enemiesToSpawn;


    public GameObject playerChar;
    private Vector3 playerPosition;
    void Start()
    {
        enemiesToSpawn = (int)Random.Range(1, maxEnemyNum);
        spawnOverworldEnemies(enemiesToSpawn);

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = playerChar.transform.position;
        for (int i = 0; i < enemies.Length; i ++) {
            if (Vector2.Distance(playerPosition, enemies[i].transform.position) < 15)
            {
                enemies[i].setMove(true);
                enemies[i].setToPosition(playerPosition);
            }
            else {
                enemies[i].setMove(false);
            }
        }
    }

    public void spawnOverworldEnemies (int enemySpawnLimit) {
        enemies = new Enemy[enemySpawnLimit];
        for (int i = 0; i < enemySpawnLimit; i++) {
            /////////////////////////////////
            // Generate random coordinates //
            /////////////////////////////////
            float randomXCoord = Random.Range(levelBorderNeg.x, levelBorderPos.x);
            float randomYCoord = Random.Range(levelBorderNeg.y, levelBorderPos.y);
            Vector2 spawnLocation = new Vector2(randomXCoord, randomYCoord);

            ///////////////////////////////////////////////////////
            // Keep track of the newly spawned overworld enemies //
            ///////////////////////////////////////////////////////
            GameObject spawnedEnemy;
            spawnedEnemy = Instantiate(spawne, spawnLocation, Quaternion.identity);
            enemies[i] = spawnedEnemy.GetComponent<Enemy>();
        }
    }

    

}
