using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damNum : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject player;
    public GameObject battleMan;
    private GameObject myGameObject;
    private GameObject myDamNums;
    BattleManagerS damNumbers;
    Text damageNum;
    void Start()
    {
        damageNum = GetComponent<Text>();
        damNumbers = battleMan.GetComponent<BattleManagerS>();
    }

    // Update is called once per frame
    void Update()
    {
        damageDisplay();
    }


    public void damageDisplay() {
       
    }

    public Text getDamNumIns() {
        return damageNum;
    }


}
