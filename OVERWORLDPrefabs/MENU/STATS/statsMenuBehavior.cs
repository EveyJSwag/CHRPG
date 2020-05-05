using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsMenuBehavior : MonoBehaviour
{
    public Text HP_VALUE;
    public Text AP_VALUE;
    public Text ATK_VALUE;
    public Text DEF_VALUE;
    public Text SPD_VALUE;
    public Text EXP_VALUE;
    public Text LEVEL_VALUE;
    public Text BACK;
    public GameObject cursor;
    GameObject cursor_stat;
    Vector3 cursorSpawnPos;

    public bool status = false;

    ////////////////////////
    // GAME MANAGER STUFF //
    ////////////////////////
    Manager gameManager_properties = new Manager();

    //////////////////////////
    // *** BUTTON GUIDE *** //
    //       0 = BACK       //
    //////////////////////////
    public int choice_index = 0;
    void Start()
    {
        status = true;
        cursorSpawnPos = new Vector3(BACK.transform.position.x + 2f, BACK.transform.position.y);
        cursor_stat = Instantiate(cursor, cursorSpawnPos, Quaternion.identity);
        getValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            Destroy(this.gameObject);
            Destroy(cursor_stat);
            status = false;
        }
    }

    public void getValues() {
        HP_VALUE.text = gameManager_properties.get_jerry_health().ToString();
        AP_VALUE.text = gameManager_properties.get_jerry_ap().ToString();
        ATK_VALUE.text = gameManager_properties.get_jerry_attack().ToString();
        DEF_VALUE.text = gameManager_properties.get_jerry_defense().ToString();
        SPD_VALUE.text = gameManager_properties.get_jerry_speed().ToString();
        EXP_VALUE.text = gameManager_properties.get_jerry_exp().ToString();
        LEVEL_VALUE.text = gameManager_properties.get_jerry_level().ToString();
    }
    public bool getStatus() {
        return status;
    }
}
