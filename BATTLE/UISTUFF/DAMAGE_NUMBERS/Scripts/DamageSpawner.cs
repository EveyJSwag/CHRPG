using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSpawner : MonoBehaviour
{
 
    public Text damageText;
    
    public void insDam(GameObject damageTaker, int damageDone) {
        damageText.text = damageDone.ToString();
        Instantiate(damageText, new Vector3 (damageTaker.transform.position.x, damageTaker.transform.position.y, 0f), Quaternion.identity).transform.SetParent(transform);
    }

}
