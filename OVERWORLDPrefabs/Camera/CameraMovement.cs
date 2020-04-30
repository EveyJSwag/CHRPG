using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject follow;
    private float xFollow;
    private float yFollow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //&& follow.transform.position.y < 28f && follow.transform.position.y > -47f
        if (follow.transform.position.x < 48f && follow.transform.position.x > -34f)
        {
            xFollow = follow.transform.position.x;
            //transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y, -10);
        }
        if (follow.transform.position.y < 28f && follow.transform.position.y > -48f)
        {
            yFollow = follow.transform.position.y;
        }

        transform.position = new Vector3(xFollow, yFollow, -10);

    }
}
