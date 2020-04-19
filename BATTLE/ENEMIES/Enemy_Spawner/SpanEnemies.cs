using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanEnemies : MonoBehaviour
{
    private Vector3 positionV = new Vector3(9f, -4f, 0f);
    public GameObject enemies;
    private int enemiesAmount = 0;
    private GameObject []enemyArray = new GameObject[3];
    private Vector3[] posArray = new Vector3[3];
    public void Spawn() {
        int spawn_num = (int)Random.Range(1, 4);
        for (int i = 0; i < spawn_num; i++)
        {
            enemyArray[i]=Instantiate(enemies, positionV, Quaternion.identity);
            posArray[i] = positionV;
            positionV.y = positionV.y + 3;
            enemiesAmount++;
        }
        Debug.Log(this.getSize());
    }

    public GameObject getEnemy(int index) {

        return enemyArray[index];

    }
    public void removeEnemy(int at) {
        GameObject[] tempEnemyArray = new GameObject[enemiesAmount-1];
        int index = 0;
        for (int i = 0; i < enemiesAmount; i++) {
            if (i != at) {
                tempEnemyArray[index] = enemyArray[i];
                index++;
            }
        }
        enemyArray = tempEnemyArray;
        enemiesAmount--;

    }
    public int getSize() {
        return enemiesAmount;
    }
    public Vector3 getOgPos(int index) {
        return posArray[index];
    }

}
