using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleChar : MonoBehaviour
{
    // ***PLAYER STATS***
    // ***Base***
    public int health;
    public int attack;
    public int defense;
    public int level;
    public float speed;
    // ******************

    ///////////////
    // EXP STUFF //
    ///////////////
    public int total_exp;

    private int damageTaken;
    public GameObject enemyB;
    public GameObject selector;
    public Canvas bUI;
    

    /////////////////////
    // ANIMATION STUFF //
    /////////////////////
    Animator animator;
    private string [] anim_bools = { "idle", "walk_right", "walk_left", "attack" };
    private string[] anim_states = { "Final_Jerry_Idle_Right", "Final_Jerry_Walk_Right", "Final_Jerry_Walk_Left", "Final_Jerry_Attack" };
    
    /////////////////////////
    // UPDATE STATIC STATS //
    /////////////////////////
    private Manager gameManager_properties = new Manager();

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyB.GetComponent<SpanEnemies>();
        getStats();
    }
    private void Update()
    {
        
    }

    public float getPlayerSpeed() {
        return speed;
    }
    public int getDefense() {
        return defense;
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
        return (int)(0.3 * Math.Round(Math.Sqrt(total_exp)));
    }

    ///////////////////////////////////////////////////////////////
    // These functions are here for managing animation variables //
    ///////////////////////////////////////////////////////////////
    private void setAllAnimFalse()
    {
        for (int i = 0; i < anim_bools.Length; i++)
        {
            animator.SetBool(anim_bools[i], false);
        }
    }
    public void setAllAnimFalseBut(string exception)
    {
        for (int i = 0; i < anim_bools.Length; i++)
        {
            if (anim_bools[i] != exception)
                animator.SetBool(anim_bools[i], false);
            else
                animator.SetBool(exception, true);
        }
    }

    public void playAttack() {
        animator.Play(anim_states[3]);
    }
    public bool getAnimState() {
        return animator.GetCurrentAnimatorStateInfo(0).IsName("Final_Jerry_Attack");
    }
    public float getNormTime() {
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    ////////////////////////////////
    // SET ALL OF THE STATIC VARS //
    ////////////////////////////////
    public void updateStats(bool killed=false) {
        gameManager_properties.set_jerry_level(calculateLevel());
        gameManager_properties.set_jerry_health(getPlayerHealth());
        gameManager_properties.set_jerry_attack(getAttack());
        gameManager_properties.set_jerry_defense(getDefense());
        gameManager_properties.set_jerry_exp(getExp());
        if (killed) {
            gameManager_properties.set_enemies_killed();
        }
    }
    public void getStats() {
        level = gameManager_properties.get_jerry_level();
        speed = gameManager_properties.get_jerry_speed();
        health = gameManager_properties.get_jerry_health();
        attack = gameManager_properties.get_jerry_attack();
        total_exp = gameManager_properties.get_jerry_exp();
    }
}
