using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldUIManager : MonoBehaviour
{
    public Text CharacterName;
    public Text HPValue;
    public Text LevelValue;
    public Text enemiesKilledValue;
    public GameObject character;
    public void setUIValues() {
        JerryInfo character_properties = character.GetComponent<JerryInfo>();
        CharacterName.text = character_properties.getName();
        HPValue.text = character_properties.getHealth();
        LevelValue.text = character_properties.getLevel();
        enemiesKilledValue.text = character_properties.getEnemiesKilled().ToString();
    }

}
