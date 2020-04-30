using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    
    ////////////////////////////////////////////////////////////////
    // States for showing which direction the character is moving //
    ////////////////////////////////////////////////////////////////
    public enum MovementState { UP, DOWN, LEFT, RIGHT, STILL }
    public MovementState state;

    //////////////////////////////////////////////////////
    // Speed variable... Kinda buggy for some reason... //
    //////////////////////////////////////////////////////
    public float speed;
    
    //////////////////////////////////
    // Variables used for animation //
    //////////////////////////////////
    Animator animator;
    private string[] anim_bools = { "key_up", "key_down", "key_left", "key_right" };
    
    //////////////////////////////////////////////
    // Rigid body stuff... will need this later //
    //////////////////////////////////////////////
    Rigidbody2D rb;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        state = MovementState.STILL;
    }

    void Update()
    {

        setState();
        if (state == MovementState.DOWN)
        {
            transform.Translate(new Vector2(0f, -0.01f*speed));
            setAllAnimFalseBut("key_down");
        }
        else if (state == MovementState.UP)
        {
            transform.Translate(new Vector2(0f, 0.01f * speed));
            setAllAnimFalseBut("key_up");
        }
        else if (state == MovementState.LEFT)
        {
            transform.Translate(new Vector2(-0.01f * speed, 0f));
            setAllAnimFalseBut("key_left");
        }
        else if (state == MovementState.RIGHT)
        {
            transform.Translate(new Vector2(0.01f * speed, 0f));
            setAllAnimFalseBut("key_right");
        }
        else {
            setAllAnimFalse();
        }
        


        
    }


    private void setState() {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            state = MovementState.RIGHT;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            state = MovementState.LEFT;

        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            state = MovementState.UP;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            state = MovementState.DOWN;
        }
        else {
            state = MovementState.STILL;
        }
    }

    ///////////////////////////////////////////////////////////////
    // These functions are here for managing animation variables //
    ///////////////////////////////////////////////////////////////
    private void setAllAnimFalse() {
        for (int i = 0; i < anim_bools.Length; i++) {
            animator.SetBool(anim_bools[i], false);
        }
    }
    private void setAllAnimFalseBut(string exception) {
        for (int i = 0; i < anim_bools.Length; i++) {
            if (anim_bools[i] != exception)
                animator.SetBool(anim_bools[i], false);
            else
                animator.SetBool(exception, true);
        }
    }

    
}
