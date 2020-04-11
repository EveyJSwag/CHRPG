using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleChar : MonoBehaviour
{
    // ***PLAYER STATS***
    public int health = 35;
    public int attack = 10;
    public int defense = 4;
    public int level = 1;
    public float speed = 100;
    // ******************


    private int damageTaken;
    private bool playerMove = false;
    private bool hasSelect = false;
    public GameObject enemyB;
    public GameObject selector;
    public Canvas bUI;
    
    void Start()
    {
        
        enemyB.GetComponent<SpanEnemies>();
    }

    public float getPlayerSpeed() {
        return speed;
    }
    public void takeDamage(int damage) {
        damageTaken = damage - defense;
        if (damageTaken < 0) {
            damageTaken = 0;
        }
        health -= damageTaken;
    }
    public int getDamageTaken()
    {
        return damageTaken;
    }
    public int getPlayerHealth() {
        return health;
    }
    public int getAttack() {
        return attack;
    }

}
