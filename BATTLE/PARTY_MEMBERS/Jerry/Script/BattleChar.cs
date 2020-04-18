using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleChar : MonoBehaviour
{
    // ***PLAYER STATS***
    // ***Base***
    public int health = 100;
    public int attack = 20;
    public int defense = 10;
    public int level = 1;
    public float speed = 40;
    // ******************

    ///////////////
    // EXP STUFF //
    ///////////////
    public int total_exp;

    private int damageTaken;
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
    public int getExp() {
        return total_exp;
    }

    public void gainExp(int expGained)
    {
        total_exp += expGained;
    }
    public int calculateLevel()
    {
        return (int)(0.5 * Math.Round(Math.Sqrt(total_exp)));
    }


}
