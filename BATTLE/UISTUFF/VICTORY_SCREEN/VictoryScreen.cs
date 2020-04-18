using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    

    public Text exp_text;
    public Text exp_text_int;
    public Text lvl_text;

    public void set_exp_text(string exp) {
        exp_text.text = exp;
    }

    public void set_exp_text_int(int exp) {
        exp_text_int.text = exp.ToString();
    }

    public void set_lvl_text(int lvl) {
        lvl_text.text = lvl.ToString();
    }

    



}
