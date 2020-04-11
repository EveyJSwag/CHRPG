using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newHealthMan : MonoBehaviour
{
    // Start is called before the first frame update
    Text health;
    public GameObject player;
    void Start()
    {
        health = GetComponent<Text>();
        //Debug.Log("POSITION" + health.transform.position);
        //health.transform.position = new Vector3(-174f, -181f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        health.text = player.GetComponent<BattleChar>().getPlayerHealth().ToString();
    }
}
