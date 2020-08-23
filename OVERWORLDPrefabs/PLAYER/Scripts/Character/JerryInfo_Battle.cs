using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryInfo_Battle : Character
{
    private OverworldUIManager UIManager_properties;
    private Manager GameManager_properties = Manager.getInstance();
    void Start()
    {
        getStats();
        transform.position = GameManager_properties.get_jerry_last_pos();
        UIManager_properties.setUIValues();
    }

    public string getLevel()
    {
        return level.ToString();
    }
    public string getHealth()
    {
        return health.ToString();
    }
    public string getName()
    {
        return characterName;
    }
    public int getEnemiesKilled()
    {
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
