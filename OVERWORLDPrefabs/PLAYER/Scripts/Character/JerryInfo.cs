using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryInfo : Character
{
    public GameObject UIManager;
    private OverworldUIManager UIManager_properties;

    private Manager GameManager_properties = new Manager();
    void Start()
    {
        //if (GameManager_properties.get_jerry_health() != 0) { 
        //    health = GameManager_properties.get_jerry_health();  
        //}
        getStats();
        UIManager_properties = UIManager.GetComponent<OverworldUIManager>();
        UIManager_properties.setUIValues();
        Debug.Log(health);
    }

    public string getLevel() {
        return level.ToString();
    }
    public string getHealth() {
        return health.ToString();
    }
    public string getName() {
        return characterName;
    }
    public int getEnemiesKilled() {
        return GameManager_properties.get_enemies_killed();
    }
    public void getStats()
    {
        level = GameManager_properties.get_jerry_level();
        speed = GameManager_properties.get_jerry_speed();
        health = GameManager_properties.get_jerry_health();
        attack = GameManager_properties.get_jerry_attack();
        total_exp = GameManager_properties.get_jerry_exp();
    }


}
