using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    private Vector3 positionV = new Vector3(9f, -4f, 0f);
    public GameObject enemies;
    private int enemiesAmount = 0;
    //private static int spawnCount = 
    private GameObject []enemyArray = new GameObject[3];
    private Vector3[] posArray = new Vector3[3];
    //float swag = 0;
    //int timeSpawn= 5;
    public void Spawn() {

        for (int i = 0; i < (int)Random.Range(1, 4); i++)
        {
            
            enemyArray[i]=Instantiate(enemies, positionV, Quaternion.identity);
            posArray[i] = positionV;
            positionV.y = positionV.y + 3;
            enemiesAmount++;
            //enemyArray[i] = Instantiate(enemies, positionV, Quaternion.identity);
            //enemyArray[i] = enemies;
            //enemyArray.SetValue(enemies, i);
        }
        Debug.Log(this.getSize());
    }

    void Start()
    {
        //Spawn();
    }
    private void Update()
    {
        /*
        swag = Time.deltaTime + swag;
        if (swag > timeSpawn) {
            Spawn();
            swag= 0;
        }
        */
    }

    public GameObject getEnemy(int index) {

        return enemyArray[index];

    }
    public int getSize() {
        return enemiesAmount;
    }
    public Vector3 getOgPos(int index) {
        return posArray[index];
    }
    /*
    public GameObject[] initEnemies() {
        for (int i = 0; i < (int)Random.Range(1, 4); i++)
        {

            enemyArray[i] = Instantiate(enemies, positionV, Quaternion.identity);
            posArray[i] = positionV;
            positionV.y = positionV.y + 3;
            enemiesAmount++;
            //enemyArray[i] = Instantiate(enemies, positionV, Quaternion.identity);
            //enemyArray[i] = enemies;
            //enemyArray.SetValue(enemies, i);
        }
        return enemyArray;

    }
    */
    //public void 


}
