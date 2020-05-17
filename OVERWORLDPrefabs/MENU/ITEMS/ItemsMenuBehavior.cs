using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsMenuBehavior : MonoBehaviour
{

    public bool status = false;
    ////////////
    // CURSOR //
    ////////////
    public GameObject cursor;
    GameObject cursor_items;
    Vector3 cursorSpawnPos;


    ////////////////
    // ITEM ATTRS //
    ////////////////
    Manager game_manager_properties = new Manager();

    /////////////////
    // TEXT FIELDS //
    /////////////////
    public Text itemName;
    public Text itemDescriptions;
    public Text itemAttrs_hp;
    public Text itemAttrs_ap;
    public GameObject itemsGrid;
    Vector3[] fourCorners = new Vector3[4];
    public GameObject BACK;

    //////////////////
    // CHOICE INDEX //
    //////////////////
    int choiceIndex = 0;
    ////////////////////////
    // ***CHOICE GUIDE*** //
    //      0 = back      //
    //     1-12 = items   //
    ////////////////////////
    Transform itemGrid;
    
    void Start()
    {
        itemsGrid.GetComponent<RectTransform>().GetLocalCorners(fourCorners);
        Debug.Log(fourCorners[0] + ", " + fourCorners[1] +", "+ fourCorners[2] +", "+ fourCorners[3]);
        status = true;
        cursorSpawnPos = new Vector3(BACK.transform.position.x + 2f, BACK.transform.position.y);
        cursor_items = Instantiate(cursor, cursorSpawnPos, Quaternion.identity);
        itemGrid = this.gameObject.transform.GetChild(7);
        displayInventory();
        
    }

    // Update is called once per frame
    void Update()
    {
        /////////////////////
        // SELECTING ITEMS //
        /////////////////////
        if (choiceIndex > 0 && choiceIndex < 13)
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                choiceIndex--;
                if (choiceIndex == 0 || choiceIndex == 4 || choiceIndex == 8) {
                    choiceIndex += 4;
                }
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                choiceIndex++;
                if (choiceIndex == 5 || choiceIndex == 9 || choiceIndex == 13) {
                    choiceIndex -= 4;
                }
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                choiceIndex -= 4;
                if (choiceIndex == (2-4) || choiceIndex == (3-4) || choiceIndex == (4-4)) {
                    choiceIndex += 12;
                }
                if (choiceIndex == (1-4)) {
                    choiceIndex = 0;
                }
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                choiceIndex += 4;
                if (choiceIndex == (10 + 4) || choiceIndex == (11 + 4) || choiceIndex == (12 + 4))
                {
                    choiceIndex -= 12;
                }
            }
            if (choiceIndex != 0)
            {
                cursor_items.transform.position = itemGrid.GetChild(choiceIndex - 1).transform.position;
                displayDescription(choiceIndex);
            }
        }
        else {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                choiceIndex = 9;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                choiceIndex = 1;
            }
            cursor_items.transform.position = itemGrid.GetChild(choiceIndex - 1).transform.position;
            displayDescription(choiceIndex);

        }
        if (choiceIndex == 0) {
            cursor_items.transform.position  = BACK.transform.position;
        }

    }

    public void displayInventory() {
        GameObject[] inventory = game_manager_properties.getInventory();
        GameObject temp;
        Vector3 scaleVector = new Vector3(0.25f, 0.25f, 0);
        for (int i = 0; i < game_manager_properties.getInventoryIndex(); i++) {
            temp = Instantiate(inventory[i]);
            temp.transform.localScale = scaleVector;
            temp.transform.SetParent(itemGrid);
            temp.transform.position = itemGrid.GetChild(i).transform.position;
            temp.GetComponent<SpriteRenderer>().sortingLayerName = "BattleCursorLayer";
        }
    }
    public void displayDescription(int index) {
        //choiceIndex - 1;
        ItemAttr item_properties = itemGrid.GetChild(index + 11).GetComponent<ItemAttr>();
        itemName.text = item_properties.Name;
        itemDescriptions.text = item_properties.Description;
        itemAttrs_hp.text = "+" + item_properties.HP_restore.ToString() + " HP";
        itemAttrs_ap.text = "+" + item_properties.AP_restore.ToString() + " AP"; 

    }
   

    public bool getStatus() {
        return status;
    }
}
