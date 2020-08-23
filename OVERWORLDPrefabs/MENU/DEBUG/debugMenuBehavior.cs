using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugMenuBehavior : MonoBehaviour
{

    public bool status = false;

    public GameObject healthInput;
    InputField healthInput_text;

    public GameObject levelInput;
    InputField levelInput_text;

    public Text BACK;

    public GameObject cursor;
    GameObject cursor_debug;
    Vector3 cursorSpawnPos;

    public GameObject overworldUIManager;
    OverworldUIManager overworldUIManager_properties;
    
    ////////////////////////
    // GAME MANAGER STUFF //
    ////////////////////////
    Manager gameManager_properties = Manager.getInstance();

    //////////////////////////
    // *** BUTTON GUIDE *** //
    //       0 = HEALTH     //
    //       1 = LEVEL      //
    //       2 = BACK       //
    //////////////////////////
    int choiceIndex = 0;
    void Start()
    {
        ////////////////////
        // STATUS OF MENU //
        ////////////////////
        status = true;

        overworldUIManager = GameObject.Find("Overworld_UI");

        ////////////
        // CURSOR //
        ////////////
        cursorSpawnPos = new Vector3(BACK.transform.position.x + 2f, BACK.transform.position.y);
        cursor_debug = Instantiate(cursor, cursorSpawnPos, Quaternion.identity);

        //////////////////////
        // TEXT FIELD STUFF //
        //////////////////////
        healthInput_text = healthInput.GetComponent<InputField>();
        levelInput_text = levelInput.GetComponent<InputField>();

        /////////////////////////
        // OVERWORLD MANAGER   //
        // UPDATE OVERWORLD UI //
        /////////////////////////
        overworldUIManager_properties = overworldUIManager.GetComponent<OverworldUIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //////////////////////////
        // *** BUTTON GUIDE *** //
        //       0 = HEALTH     //
        //       1 = LEVEL      //
        //       2 = BACK       //
        //////////////////////////
        /*
        if (Input.GetKeyDown(KeyCode.DownArrow))
            choiceIndex++;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            choiceIndex--;

        if (choiceIndex > 2)
            choiceIndex = 0;
        if (choiceIndex < 0)
            choiceIndex = 2;
        */
        if (Input.GetKeyDown(KeyCode.Return) && choiceIndex == 0)
        {
            //Debug.Log("HEALTH: " + healthInput_text.text+ "/t" + "LEVEL: " + levelInput_text.text);
            gameManager_properties.set_jerry_health(System.Convert.ToInt32(healthInput_text.text));
            gameManager_properties.set_jerry_level(System.Convert.ToInt32(levelInput_text.text));
            overworldUIManager_properties.updateUIValues();
            Destroy(this.gameObject);
            Destroy(cursor_debug);
            status = false;
        }
    
    }

    public bool getStatus()
    {
        return status;
    }
}
