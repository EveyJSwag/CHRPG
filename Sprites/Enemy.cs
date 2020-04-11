using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Idle;
    private bool isMoving = true;
    public bool shouldSpan = false;
    Rigidbody2D rbEnemy;
    GameObject spaner;
    void Start()
    {

        rbEnemy = GetComponent<Rigidbody2D>();
        Debug.Log(Idle.GetComponent<CharacterController2D>().health);
        //Debug.Log(Vector3.Distance(transform.position, Idle.transform.position));
        /*
        if (!shouldSpan){
            for(int i = 0; i < 2; i++)
                spaner.GetComponent<SpanEnemies>().Spawn();
            
        }
        */

    }
   
    public int attackPower = 5;
    public float speed;
    private Vector3 playerSpeed = new Vector3(0.0f,0.0f,0.0f);
    
    private float playerSpeedx; 
    // Update is called once per frame
    void Update()
    {
        //playerSpeed = transform.Translate(Idle.transform.Translate.x,0,0);
        //transform.Translate(Idle.transform.position*speed);
        //transform.Translate(Idle.transform.position.x*Time.deltaTime,0,0);
        if ((int)transform.position.x - (int)Idle.transform.position.x == 0)
        {
            Idle.GetComponent<CharacterController2D>().damage();
            //transform.Translate(1, 0, 0);
            //transform.Translate(0, 0, 0);
            isMoving = false;
            //Idle.
           


        }
        else if(isMoving || ((int)transform.position.x - (int)Idle.transform.position.x != 0))
        {

            isMoving = true;
            if (transform.position.x > Idle.transform.position.x)
            {
                rbEnemy.velocity = new Vector2(-1f*speed,0);
            }
            else {
                rbEnemy.velocity = new Vector2(1f * speed, 0);
            }


        }
    }

    public void destroyEnemy() {
        Destroy(this);
    }

}
