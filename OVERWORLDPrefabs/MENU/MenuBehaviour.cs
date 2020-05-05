using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{

    public GameObject menuController;
    MenuController menuController_properties;

    public enum Menu_States {CHOOSE, STATS, ITEMS, SAVE, DEBUG}
    public Menu_States state;
    
    public GameObject cursor;
    GameObject myCursor;
    
    public Text stats;
    public Text items;
    public Text save;
    public Text debug;

    Vector3[] choicePos;
    
    int choiceIndex = 0;

    void Start()
    {
        menuController_properties = menuController.GetComponent<MenuController>();
        state = Menu_States.CHOOSE;
    }

    
    void Update()
    {
        ////////////////////////
        // ***CHOICE GUIDE*** //
        //      0 = stats     //
        //      1 = items     //
        //      2 = save      //
        //      3 = debug     //
        ////////////////////////
        if (state == Menu_States.CHOOSE)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                choiceIndex--;
                ////////////////////////////
                // OBLIGATORY INDEX CHECK //
                ////////////////////////////
                if (choiceIndex < 0)
                    choiceIndex = 3;
                myCursor.transform.position = choicePos[choiceIndex];
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                choiceIndex++;
                ////////////////////////////
                // OBLIGATORY INDEX CHECK //
                ////////////////////////////
                if (choiceIndex > 3)
                    choiceIndex = 0;
                myCursor.transform.position = choicePos[choiceIndex];
            }

            if (Input.GetKeyDown(KeyCode.Return) && state == Menu_States.CHOOSE)
            {
                if (choiceIndex == 0)
                {
                    menuController_properties.setUpMenu_stats();
                    state = Menu_States.STATS;
                }
                if (choiceIndex == 1)
                    state = Menu_States.ITEMS;
                if (choiceIndex == 2)
                    state = Menu_States.SAVE;
                if (choiceIndex == 3)
                    state = Menu_States.DEBUG;
                choiceIndex = 0;
            }
        }
        
        if (state == Menu_States.STATS) {
            myCursor.SetActive(false);
            if (menuController_properties.getStatus_stats() == false) {
                myCursor.SetActive(true);
                state = Menu_States.CHOOSE;
            }
        }
        
        Debug.Log(choiceIndex);
        

    }
    public void setUpCursor() {
       
        Vector3 cursorSpawnPos = new Vector3(stats.transform.position.x+2f, stats.transform.position.y);
        myCursor = Instantiate(cursor);
        myCursor.transform.SetParent(this.transform);
        myCursor.transform.position = cursorSpawnPos;
    }
    public void destroyCursor()
    {
        Destroy(myCursor);
    }
    public void getChoicePos() {
        Vector3 statsPos = new Vector3(stats.transform.position.x + 2f, stats.transform.position.y);
        Vector3 itemsPos = new Vector3(items.transform.position.x + 2f, items.transform.position.y); 
        Vector3 savePos = new Vector3(save.transform.position.x + 2f, save.transform.position.y); 
        Vector3 debugPos = new Vector3(debug.transform.position.x + 2f, debug.transform.position.y);
        Vector3 [] posArr = { statsPos, itemsPos, savePos, debugPos };
        choicePos = posArr;
    }
    void statsMenu() { 
    }
    void itemsMenu() { 
    }
    void debugMenu() { 
    }
    

}
