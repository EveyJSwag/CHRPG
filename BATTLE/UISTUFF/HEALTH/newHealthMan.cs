using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newHealthMan : MonoBehaviour
{
    // Start is called before the first frame update
    Text health;
    public GameObject player;

    Manager gameManager = Manager.getInstance();
    
    void Start()
    {
        health = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //health.text = player.GetComponent<BattleChar>().getPlayerHealth().ToString();
        health.text = gameManager.get_jerry_health().ToString();
    }


}
