﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    ////////////////////
    // MAIN MENU VARS //
    ////////////////////
    public GameObject menu;
    MenuBehaviour menu_properties;
    Canvas menuCanvas;
    bool isActive = false;

    /////////////////////
    // STATS MENU VARS //
    /////////////////////
    public GameObject stats_menu;
    GameObject stats_menu_tmp;
    statsMenuBehavior stats_menu_properties;
    statsMenuBehavior stats_menu_tmp_properties;
    Canvas stats_menuCanvas;

    /////////////////////
    // ITEMS MENU VARS //
    /////////////////////
    public GameObject items_menu;
    GameObject items_menu_tmp;
    ItemsMenuBehavior items_menu_properties;
    ItemsMenuBehavior items_menu_tmp_properties;
    Canvas items_menuCanvas;

    /////////////////////
    // DEBUG MENU VARS //
    /////////////////////
    public GameObject debug_menu;
    GameObject debug_menu_tmp;
    debugMenuBehavior debug_menu_properties;
    debugMenuBehavior debug_menu_tmp_properties;
    Canvas debug_menuCanvas;

    public enum MenuControl_States { MAIN, STAT, DEBUG, ITEMS}
    public MenuControl_States mainState;
    public GameObject player;
    
    void Start()
    {
        menu_properties = menu.GetComponent<MenuBehaviour>();
        menu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if ( (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))) {
            if (Input.GetKeyDown(KeyCode.M) && isActive == false) {
                mainState = MenuControl_States.MAIN;
                
                player.SetActive(false);
                isActive = true;
                setUpMenu();
                menu_properties.getChoicePos();
                menu_properties.setUpCursor();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isActive == true) {
            menu.SetActive(false);
            player.SetActive(true);
            isActive = false;
            menu_properties.destroyCursor();
        }
    }
    /////////////////////////////////////////////////////////////
    // SET UP MENU SO IT ATTACHES ITSELF TO THE MAIN CAMERA... //
    // AND SOME OTHER CAMERA STUFF                             //
    /////////////////////////////////////////////////////////////
    public void setUpMenu() {
        menuCanvas = menu.GetComponent<Canvas>();
        menuCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        menuCanvas.worldCamera = Camera.main;
        menuCanvas.planeDistance = 10f;
        menuCanvas.sortingLayerName = "Tilestuff";
        menuCanvas.sortingOrder = 9;
        menu.SetActive(true);
    }

    ///////////////////////////
    // SETTING UP STATS MENU //
    ///////////////////////////
    public void setUpMenu_stats() {
        mainState = MenuControl_States.STAT;
        stats_menu_tmp = Instantiate(stats_menu);
        stats_menu_tmp_properties = stats_menu_tmp.GetComponent<statsMenuBehavior>();
        setStatus_stats();
        stats_menuCanvas = stats_menu_tmp.GetComponent<Canvas>();
        stats_menuCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        stats_menuCanvas.worldCamera = Camera.main;
        stats_menuCanvas.planeDistance = 10f;
        stats_menuCanvas.sortingLayerName = "statMenuLayer";
        stats_menuCanvas.sortingOrder = 1;
    }
    public bool getStatus_stats() {
        return stats_menu_tmp_properties.getStatus();
    }
    public void setStatus_stats() {
        stats_menu_tmp_properties.status = true;
    }

    ///////////////////////////
    // SETTING UP DEBUG MENU //
    ///////////////////////////
    public void setUpMenu_debug()
    {
        mainState = MenuControl_States.DEBUG;
        debug_menu_tmp = Instantiate(debug_menu);
        debug_menu_tmp_properties = debug_menu_tmp.GetComponent<debugMenuBehavior>();
        setStatus_debug();
        debug_menuCanvas = debug_menu_tmp.GetComponent<Canvas>();
        debug_menuCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        debug_menuCanvas.worldCamera = Camera.main;
        debug_menuCanvas.planeDistance = 10f;
        debug_menuCanvas.sortingLayerName = "statMenuLayer";
        debug_menuCanvas.sortingOrder = 1;
    }
    public void setStatus_debug()
    {
        debug_menu_tmp_properties.status = true;
    }
    public bool getStatus_debug()
    {
        return debug_menu_tmp_properties.getStatus();
    }

    ///////////////////////////
    // SETTING UP ITEMS MENU //
    ///////////////////////////
    public void setUpMenu_items()
    {
        mainState = MenuControl_States.ITEMS;
        items_menu_tmp = Instantiate(items_menu);
        items_menu_tmp_properties = items_menu_tmp.GetComponent<ItemsMenuBehavior>();
        setStatus_items();
        items_menuCanvas = items_menu_tmp.GetComponent<Canvas>();
        items_menuCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        items_menuCanvas.worldCamera = Camera.main;
        items_menuCanvas.planeDistance = 10f;
        items_menuCanvas.sortingLayerName = "statMenuLayer";
        items_menuCanvas.sortingOrder = 1;
    }
    public void setStatus_items()
    {
        items_menu_tmp_properties.status = true;
    }
    public bool getStatus_items()
    {
        return items_menu_tmp_properties.getStatus();
    }

}
