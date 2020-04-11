using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
    // ***ENEMY STATS***
    public int attack = 8;
    public int health = 25;
    public int defense = 4;
    public float speed = 25;
    private int damageTaken;
    // *****************
    
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
    public int getDamageTaken() {
        return damageTaken;
    }
    public int getAttack() {
        return attack;
    }
    public float getEnemySpeed() {
        return speed;
    }

}
