using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject menu;
    MenuBehaviour menu_properties;
    Canvas menuCanvas;
    bool isActive = false;

    public GameObject stats_menu;
    GameObject stats_menu_tmp;
    statsMenuBehavior stats_menu_properties;
    statsMenuBehavior stats_menu_tmp_properties;
    Canvas stats_menuCanvas;



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
    public void setUpMenu_stats() {
        stats_menu_tmp = Instantiate(stats_menu);
        stats_menu_tmp_properties = stats_menu_tmp.GetComponent<statsMenuBehavior>();
        stats_menuCanvas = stats_menu_tmp.GetComponent<Canvas>();
        stats_menuCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        stats_menuCanvas.worldCamera = Camera.main;
        stats_menuCanvas.planeDistance = 10f;
        stats_menuCanvas.sortingLayerName = "statMenuLayer";
        stats_menuCanvas.sortingOrder = 1;
    }

}
