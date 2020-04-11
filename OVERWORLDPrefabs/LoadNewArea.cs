using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{

    private GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("yeet");
        //Enemy.GetComponent<Enemy>().destroyEnemy();
        
        if (other.gameObject.name == "JerryOverworld") {
        //    //Application.LoadLevel();
            Debug.Log("YEET");
            
            SceneManager.LoadScene("BattleScene");
            Destroy(FindObjectOfType<GameObject>(), 0.1f);

        }
    }

}
