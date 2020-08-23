using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    Manager game_manager_properties = Manager.getInstance();
    /////////////////////////
    // INVENTORY AND ITEMS //
    /////////////////////////
    public static GameObject[] inventory = new GameObject[100];
    public static int[] inventory_amt = new int [100];
    public static int inventoryIndex = 0;
    public GameObject[] all_items;

    /////////////////////////
    // INVENTORY FUNCTIONS //
    /////////////////////////
    bool hasItem(string itemName) {
        for (int i = 0; i < inventoryIndex; i++) {
            if (itemName == inventory[i].name) {
                int amt = inventory_amt[i]++;
                amt++;
                inventory_amt[i] = amt;
                return true;
            }
        }
        return false;
    }
    public void add_to_inventory(string itemName)
    {
        if (!hasItem(itemName))
        {
            inventory[inventoryIndex] = findItem(itemName);
            inventory_amt[inventoryIndex] = 1;
            inventoryIndex++;
        }
    }

    public GameObject findItem(string itemName)
    {
        for (int i = 0; i < all_items.Length; i++)
            if (itemName == all_items[i].name)
                return all_items[i];
            
        return null;
    }

    public GameObject[] getInventory()
    {
        return inventory;
    }
    public int[] getInventoryAmount() {
        return inventory_amt;
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
        if (inventory_amt[index-1] == 1)
        {
            index--;
            inventory_amt[index] = 0;
            game_manager_properties.set_jerry_health(game_manager_properties.get_jerry_health() + inventory[index].GetComponent<ItemAttr>().HP_restore);
            game_manager_properties.set_jerry_ap(game_manager_properties.get_jerry_ap() + inventory[index].GetComponent<ItemAttr>().AP_restore);
            if (game_manager_properties.get_jerry_health() > game_manager_properties.get_jerry_max_health())
                game_manager_properties.set_jerry_health(game_manager_properties.get_jerry_max_health());
            if (game_manager_properties.get_jerry_ap() > game_manager_properties.get_jerry_max_ap())
                game_manager_properties.set_jerry_ap(game_manager_properties.get_jerry_max_ap());
            setInventory(index);
        }
        else {
            int tmp = inventory_amt[index-1]-1;
            inventory_amt[index-1] = tmp;
        }
    }
    public void setInventory(int removeAt)
    {
        ////////////////////////////////////////
        // THIS IS DONE FOR THE INVENTORY AND //
        // THE INVENTORY AMOUNT               //
        ////////////////////////////////////////
        int oldLength = getInventoryIndex();
        int newIndex = 0;

        GameObject[] tempInventory = new GameObject[100];
        int[] tempItemAmt = new int[100];

        for (int i = 0; i < oldLength; i++)
        {
            if (i != removeAt)
            {
                tempInventory[newIndex] = inventory[i];
                tempItemAmt[newIndex] = inventory_amt[i];
                newIndex++;
            }
        }
        inventory = tempInventory;
        inventory_amt = tempItemAmt;

        inventoryIndex--;
        Debug.Log("INVENTORY INDEX IS NOW: " + inventoryIndex);
    }
}
