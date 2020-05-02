using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float timeToAppear;
    public float floatSpeed;
    private float timer;
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= timeToAppear) {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        floatUp();
    }

    public void floatUp() {
        transform.Translate(new Vector2(0f,floatSpeed *Time.deltaTime));
    }



}
