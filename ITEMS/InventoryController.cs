using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    Manager game_manager_properties = new Manager();
    /////////////////////////
    // INVENTORY AND ITEMS //
    /////////////////////////
    public static GameObject[] inventory = new GameObject[100];
    public static int inventoryIndex = 0;
    public GameObject[] all_items;

    
    /////////////////////////
    // INVENTORY FUNCTIONS //
    /////////////////////////
    public void add_to_inventory(string itemName)
    {
        inventory[inventoryIndex] = findItem(itemName);
        inventoryIndex++;
    }
    public GameObject findItem(string itemName)
    {
        for (int i = 0; i < all_items.Length; i++)
        {
            if (itemName == all_items[i].name)
            {
                return all_items[i];
            }
        }
        return null;
    }

    public GameObject[] getInventory()
    {
        return inventory;
    }
    public int getInventoryIndex()
    {
        return inventoryIndex;
    }
    public void printInventory()
    {
        for (int i = 0; i < inventoryIndex; i++)
        {
            Debug.Log(inventory[i].name);
        }
    }
    public void useItem(int index)
    {
        index--;
        game_manager_properties.set_jerry_health(game_manager_properties.get_jerry_health() + inventory[index].GetComponent<ItemAttr>().HP_restore);
        game_manager_properties.set_jerry_ap( game_manager_properties.get_jerry_ap() + inventory[index].GetComponent<ItemAttr>().AP_restore);
        if ( game_manager_properties.get_jerry_health() >  game_manager_properties.get_jerry_max_health())
             game_manager_properties.set_jerry_health( game_manager_properties.get_jerry_max_health());
        if ( game_manager_properties.get_jerry_ap() >  game_manager_properties.get_jerry_max_ap())
             game_manager_properties.set_jerry_ap( game_manager_properties.get_jerry_max_ap());
        setInventory(index);
    }
    public void setInventory(int removeAt)
    {
        int oldLength = getInventoryIndex();
        int newIndex = 0;
        GameObject[] tempInventory = new GameObject[100];
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
}
