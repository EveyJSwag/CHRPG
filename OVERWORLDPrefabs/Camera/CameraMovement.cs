using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject follow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ( !(follow.transform.position.x > 42f || follow.transform.position.x < -27f))
        {
            transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y, -10);
        }

    }
}
