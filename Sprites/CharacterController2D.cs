using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 50;
    public float speed;
    Animator animator;
    Rigidbody2D rb;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       

    }
    
    // Update is called once per frame
   
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*speed,0);
        //transform.Translate(Input.GetAxisRaw("Horizontal") * speed, 0,0);
        //rb.
        if (Input.GetAxis("Horizontal") > 0)
        {
            //Debug.Log(Input.GetAxis("horizontal"));
            animator.SetBool("MoveRight", true);
            animator.SetBool("MoveLeft", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("MoveLeft", true);
            animator.SetBool("MoveRight", false);
        }
        if(!Input.anyKey){
            animator.SetBool("MoveRight", false);
            animator.SetBool("MoveLeft", false);
        }
        /*
        float move = Input.GetAxis("Horizontal");
        int move1 = (int)Input.GetAxis("Horizontal");
        animator.SetFloat("Movement", move);
        animator.SetInteger("Movement 0", move1);
        */
    }

    public void damage() {
        health = health - 10;
        if (health <= 9) {
            //Destroy(this);
        }
    }
}
