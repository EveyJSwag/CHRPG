using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    ////////////////////////////
    // STATIC STATS FOR JERRY //
    ////////////////////////////
    /**********************************
     * THESE VALUES ARE JUST DEFAULTS *
     **********************************/ 
    public static int jerry_health = 100;
    private static int jerry_max_health = 100;
    public static int jerry_attack = 25;
    public static int jerry_ap;
    public static int jerry_defense = 10;
    public static int jerry_speed = 50;
    public static int jerry_level = 1;
    public static int jerry_exp = 0;
    public static int enemies_killed = 0;
    
    

    

    /////////////////////////////////
    // SET/GET THESE STATS (JERRY) //
    /////////////////////////////////
    public void set_jerry_health(int value) { jerry_health = value; }
    public int get_jerry_health() { return jerry_health; }

    public void set_jerry_attack(int value) { jerry_attack = value; }
    public int get_jerry_attack() { return jerry_attack; }

    public void set_jerry_ap(int value) { jerry_ap = value; }
    public int get_jerry_ap() { return jerry_ap; }

    public void set_jerry_defense(int value) { jerry_defense = value; }
    public int get_jerry_defense() { return jerry_defense; }

    public void set_jerry_speed(int value) { jerry_speed = value; }
    public int get_jerry_speed() { return jerry_speed; }

    public void set_jerry_level(int value) { jerry_level = value; }
    public int get_jerry_level() { return jerry_level; }

    public void set_jerry_exp(int value) { jerry_exp = value; }
    public int get_jerry_exp() { return jerry_exp; }

    public void set_enemies_killed() { enemies_killed++; }
    public int get_enemies_killed() { return enemies_killed; }


}
