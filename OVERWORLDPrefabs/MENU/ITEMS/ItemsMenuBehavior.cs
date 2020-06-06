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
    //Manager game_manager_properties = new Manager();
    InventoryController inv_controller_properties;

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

    ////////////////////////
    // OVERWORLD UI STUFF //
    ////////////////////////
    public GameObject overworldUI;
    private OverworldUIManager overworldUI_properties;

    //////////////////
    // CHOICE INDEX //
    //////////////////
    int choiceIndex = 0;
    int gridLength = 12;
    int rows = 3;
    int column = 4;
    ////////////////////////
    // ***CHOICE GUIDE*** //
    //      0 = back      //
    //     1-12 = items   //
    ////////////////////////
    Transform itemGrid;
    
    void Start()
    {
        inv_controller_properties = GameObject.Find("ITEM_MANAGER").GetComponent<InventoryController>();
        overworldUI_properties = GameObject.Find("Overworld_UI").GetComponent<OverworldUIManager>();
        itemsGrid.GetComponent<RectTransform>().GetLocalCorners(fourCorners);
        Debug.Log(fourCorners[0] + ", " + fourCorners[1] +", "+ fourCorners[2] +", "+ fourCorners[3]);
        status = true;
        cursorSpawnPos = new Vector3(BACK.transform.position.x + 2f, BACK.transform.position.y);
        cursor_items = Instantiate(cursor, cursorSpawnPos, Quaternion.identity);
        itemGrid = this.gameObject.transform.GetChild(7);
        displayInventory();
    }

    void Update()
    {
        /////////////////////
        // SELECTING ITEMS //
        /////////////////////
        if(choiceIndex > 0 && choiceIndex <= inv_controller_properties.getInventoryIndex())
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                choiceIndex--;
                if (choiceIndex == (1-1) || choiceIndex == (5-1) || choiceIndex == (9-1)) 
                {
                    if (getRow(choiceIndex + 1) == 0)
                    {
                        if (inv_controller_properties.getInventoryIndex() < 4)
                        {
                            choiceIndex = inv_controller_properties.getInventoryIndex();
                        }
                        else
                        { 
                            choiceIndex = 4;
                        }
                    }
                    else if (getRow(choiceIndex + 1) == 1)
                    {
                        if (inv_controller_properties.getInventoryIndex() < 8)
                        {
                            choiceIndex = inv_controller_properties.getInventoryIndex();
                        }
                        else
                        {
                            choiceIndex = 8;
                        }
                    }
                    else if (getRow(choiceIndex + 1) == 2) {
                        if (inv_controller_properties.getInventoryIndex() < 12)
                        {
                            choiceIndex = inv_controller_properties.getInventoryIndex();
                        }
                        else
                        {
                            choiceIndex = 12;
                        }
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                choiceIndex++;
                if (choiceIndex == 5 || choiceIndex == 9 || choiceIndex == 13 || choiceIndex == inv_controller_properties.getInventoryIndex() + 1) {
                    if (getRow(choiceIndex-1) == 0)
                    {
                        choiceIndex = 1;
                    }
                    else if (getRow(choiceIndex-1) == 1)
                    {
                        choiceIndex = 5;
                    }
                    else {
                        choiceIndex = 4;
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                choiceIndex -= 4;

                if (choiceIndex == (1 - 4))
                {
                    choiceIndex = 0;
                }
                else if (choiceIndex == (2 - 4) || choiceIndex == (3 - 4) || choiceIndex == (4 - 4))
                {
                    int currentLength = inv_controller_properties.getInventoryIndex();
                    Debug.Log("Current Length: " + currentLength);
                    Debug.Log("Current Row: " + getRow(currentLength));
                    int scaler = (getRow(currentLength) + 1) * 4;
                    int sLength = scaler + choiceIndex;

                    if (getRow(currentLength) == 0)
                    {
                        choiceIndex = 0;
                    }
                    else if (getRow(currentLength) > 1)
                    {
                        if (sLength > currentLength)
                        {
                            choiceIndex = sLength - 4;
                        }
                        else if (sLength <= currentLength)
                        {
                            choiceIndex = sLength;
                        }
                    }
                    else {
                        if (sLength > currentLength)
                        {
                            choiceIndex = 0;
                        }
                        else if (sLength <= currentLength)
                        {
                            choiceIndex = sLength;
                        }
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                int currentLength = inv_controller_properties.getInventoryIndex();
                choiceIndex += 4;
                int rows = getRow(currentLength);
                if ((choiceIndex != (1 + 4) && choiceIndex != (5 + 4) && choiceIndex != (9 + 4)) && choiceIndex > inv_controller_properties.getInventoryIndex())
                {
                    switch (rows)
                    {
                        case 0:
                            choiceIndex = 0;
                            break;
                        case 1:
                            if (currentLength < 8)
                                choiceIndex = 0;
                            else
                                choiceIndex -= 8;
                            break;
                        case 2:
                            choiceIndex -= 12;
                            break;
                    }
                }
                else if ((choiceIndex == (1 + 4) || choiceIndex == (5 + 4) || choiceIndex == (9 + 4)) && choiceIndex > inv_controller_properties.getInventoryIndex()) {
                    choiceIndex = 0;            
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
                if (inv_controller_properties.getInventoryIndex() >= 5 && inv_controller_properties.getInventoryIndex() <= 8)
                {
                    choiceIndex = 5;
                }
                else if (inv_controller_properties.getInventoryIndex() >= 9)
                {
                    choiceIndex = 9;
                }
                else {
                    choiceIndex = 1;
                }
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                choiceIndex = 1;
            }
            if (choiceIndex > 0)
            {
                cursor_items.transform.position = itemGrid.GetChild(choiceIndex - 1).transform.position;
                displayDescription(choiceIndex);
            }
        }
        if (choiceIndex == 0) {
            cursor_items.transform.position  = BACK.transform.position;
        }
        ////////////////////
        // PRESSING ENTER //
        ////////////////////
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (choiceIndex == 0)
            {
                Destroy(cursor_items);
                Destroy(this.gameObject);
                status = false;
            }
            else {
                inv_controller_properties.useItem(choiceIndex);
                overworldUI_properties.updateUIValues();
                redoInventory();
                if (inv_controller_properties.getInventoryIndex() == 0)
                    choiceIndex = 0;
                else if (inv_controller_properties.getInventoryIndex() == choiceIndex - 1) {
                    choiceIndex--;
                }
            }
        }

    }

    public void displayInventory() {
        GameObject[] inventory = inv_controller_properties.getInventory();
        GameObject temp;
        Vector3 scaleVector = new Vector3(0.25f, 0.25f, 0);
        for (int i = 0; i < inv_controller_properties.getInventoryIndex(); i++) {
            temp = Instantiate(inventory[i]);
            temp.transform.localScale = scaleVector;
            temp.transform.SetParent(itemGrid);
            temp.transform.position = itemGrid.GetChild(i).transform.position;
            temp.GetComponent<SpriteRenderer>().sortingLayerName = "BattleCursorLayer";
        }
    }
    public void redoInventory() {
        int inventoryLength = inv_controller_properties.getInventoryIndex();
        for (int i = 12; i < inventoryLength + 13; i++) { 
            Destroy(itemGrid.GetChild(i).gameObject);
        }
        displayInventory();
    }
    public void displayDescription(int index) {
        ItemAttr item_properties = itemGrid.GetChild(index + 11).GetComponent<ItemAttr>();
        itemName.text = item_properties.Name;
        itemDescriptions.text = item_properties.Description;
        itemAttrs_hp.text = "+" + item_properties.HP_restore.ToString() + " HP";
        itemAttrs_ap.text = "+" + item_properties.AP_restore.ToString() + " AP"; 
    }

    private int getRow(int length) {
        return (length - 1) / column;
    }
    public bool getStatus() {
        return status;
    }
}
