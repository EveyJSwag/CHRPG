using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
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
    public static int jerry_ap = 50;
    public static int jerry_max_ap = 50;
    public static int jerry_defense = 10;
    public static int jerry_speed = 50;
    public static int jerry_level = 1;
    public static int jerry_exp = 0;
    public static int enemies_killed = 0;
    public static Vector3 last_pos = new Vector3(-13.35f, -1.34f);


    /////////////////////////
    // INVENTORY AND ITEMS //
    /////////////////////////
    //public static GameObject[] inventory = new GameObject[100];
    //public static int inventoryIndex = 0;
    //public GameObject[] all_items;

    

    /////////////////////////////////
    // SET/GET THESE STATS (JERRY) //
    /////////////////////////////////
    public void set_jerry_health(int value) { jerry_health = value; }
    public int get_jerry_health() { return jerry_health; }

    public void set_jerry_max_health(int value) { jerry_max_health = value; }
    public int get_jerry_max_health() { return jerry_max_health; }

    public void set_jerry_attack(int value) { jerry_attack = value; }
    public int get_jerry_attack() { return jerry_attack; }

    public void set_jerry_ap(int value) { jerry_ap = value; }
    public int get_jerry_ap() { return jerry_ap; }
    public int get_jerry_max_ap() { return jerry_max_ap; }

    public void set_jerry_defense(int value) { jerry_defense = value; }
    public int get_jerry_defense() { return jerry_defense; }

    public void set_jerry_speed(int value) { jerry_speed = value; }
    public int get_jerry_speed() { return jerry_speed; }

    public void set_jerry_level(int value) { jerry_level = value; }
    public int get_jerry_level() { return jerry_level; }

    public void set_jerry_exp(int value) { jerry_exp = value; }
    public int get_jerry_exp() { return jerry_exp; }

    public void set_jerry_last_pos(Vector3 value) { last_pos = value; }
    public Vector3 get_jerry_last_pos() { return last_pos; }

    public void jerry_level_up()
    {
        jerry_max_health += 20;
        jerry_attack += 3;
        jerry_max_ap += 5;
        jerry_ap += 5;
        jerry_defense += 2;
        jerry_speed += 4;
    }

    public void set_enemies_killed() { enemies_killed++; }
    public int get_enemies_killed() { return enemies_killed; }

    /////////////////////////
    // INVENTORY FUNCTIONS //
    /////////////////////////
    /////////////////////////////////////////////////
    // *** THESE FUNCTIONS NEED TO BE MOVED... *** //
    // *** UNITY KEEPS BITCHING AT ME...       *** //
    /////////////////////////////////////////////////
    /*
    public void add_to_inventory(string itemName) {
        inventory[inventoryIndex] = findItem(itemName);
        inventoryIndex++;
    }
    public GameObject findItem(string itemName) {
        for (int i = 0; i < all_items.Length; i++) {
            if (itemName == all_items[i].name) {
                return all_items[i];
            }
        }
        return null;
    }

    public GameObject[] getInventory() {
        return inventory;
    }
    public int getInventoryIndex() {
        return inventoryIndex;
    }
    public void printInventory() {
        for (int i = 0; i < inventoryIndex; i++) {
            Debug.Log(inventory[i].name);
        }
    }
    public void useItem(int index) {
        index--;
        set_jerry_health(get_jerry_health()+inventory[index].GetComponent<ItemAttr>().HP_restore);
        set_jerry_ap(get_jerry_ap() + inventory[index].GetComponent<ItemAttr>().AP_restore);
        if (get_jerry_health() > get_jerry_max_health())
            set_jerry_health(get_jerry_max_health());
        if (get_jerry_ap() > get_jerry_max_ap())
            set_jerry_ap(get_jerry_max_ap());
        setInventory(index);
    }
    public void setInventory(int removeAt) {
        int oldLength = getInventoryIndex();
        int newIndex = 0;
        GameObject [] tempInventory = new GameObject [100];
        for (int i = 0; i < oldLength; i++)
        {
            if (i != removeAt)
            {
                tempInventory[newIndex] = inventory[i];
                newIndex++;
            }
        }
        inventory = tempInventory;
        inventoryIndex--;
    }
*/
}
