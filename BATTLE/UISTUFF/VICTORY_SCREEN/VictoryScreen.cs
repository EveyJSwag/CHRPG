using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    

    public Text exp_text;
    public Text exp_text_int;
    public Text lvl_text;
    public GameObject end_text;

    public void set_exp_text(string exp) {
        exp_text.text = exp;
    }

    public void set_exp_text_int(int exp) {
        exp_text_int.text = exp.ToString() + " EXP";
    }

    public void set_lvl_text(int lvl_old, int lvl_new) {
        lvl_text.text = "LVL UP!!! "+ lvl_old.ToString() + " -> " + lvl_new.ToString();
    }

    public Vector3 get_end_text_location() {
        return new Vector3(end_text.transform.position.x, end_text.transform.position.y);
    
    }

    



}
