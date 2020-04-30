using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float distance;
    private bool canMove = false;
    private Vector3 originalPosition;
    private Vector3 toPosition;
    private float speed = 5f;
    private float startTime;
    private float dist;
    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (canMove) {
            transform.position = Vector3.MoveTowards(transform.position, toPosition, Time.deltaTime*speed);
        }
    }

    public void destroyEnemy() {
        Destroy(this);
    }

    public void setMove(bool value) {
        canMove = value;
    }
    public void setToPosition(Vector3 value) {
        toPosition = value;
    }


    


}
