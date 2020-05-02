using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{

    private GameObject Enemy;
    // Start is called before the first frame update
    private Manager gameManager_properties = new Manager();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.name == "Final_Jerry_Overworld") {
            Debug.Log(other.transform.position);
            gameManager_properties.set_jerry_last_pos(other.transform.position);
            SceneManager.LoadScene("BattleScene");
            Destroy(FindObjectOfType<GameObject>(), 0.1f);
        }
    }

}
