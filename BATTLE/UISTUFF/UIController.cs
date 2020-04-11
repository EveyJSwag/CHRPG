using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // *** THIS IS FOR THE CHARACTER'S NAME ON THE BATTLE SCREEN ***
    public Text charName;

    // *** THIS THE POINTER/CURSOR/GLOVE THING YOU SEE ON THE SCREEN ***
    public GameObject cursor;

    // *** THIS IS THE ABILITY MENU THAT POPS UP AFTER YOU PRESS ENTER WHEN IT IS THE PLAYER'S TURN ***
    public GameObject abilityMenuJerry;

    /*EVERY FUNCTION...
    **All of these functions are to initialize and destroy the cursor and ability menu objects.
    **I would have put this in 'BattleManagerS' but UNITY is weird about destroying stuff.
    */
    public GameObject insCursor(Vector3 position) 
    {
        GameObject newCursor = Instantiate(cursor, position, Quaternion.identity);
        return newCursor;
    }
    public GameObject insAbilityMenu(Vector3 position) 
    {
        GameObject abilityMenu = Instantiate(abilityMenuJerry, position, Quaternion.identity);
        return abilityMenu;
    }
}
