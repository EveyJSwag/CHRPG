using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
    // ***ENEMY STATS***
    // ****Base****
    public int attack = 15;
    public int health = 75;
    public int defense = 10;
    public float speed = 35;
    private int damageTaken;
    // *****************
    /////////////////////
    // EXP DROP AMOUNT //
    /////////////////////
    private int exp_drop = 5;
    void Start()
    {
        health = 25;
    }
    public void setHealth(int damage) {
        
        health -= damage;
            
        
    }
    public void takeDamage(int damage) {
        damageTaken = damage - defense;
        if (damageTaken < 0) {
            damageTaken = 0;
        }
        health -= damageTaken;
    }
    public int getHealth() {
        return health;
    }

    public int getDamageTaken() {
        return damageTaken;
    }
    public int getAttack() {
        return attack;
    }
    public float getEnemySpeed() {
        return speed;
    }

    public int getExpDroped() {
        return exp_drop;
    }

}
