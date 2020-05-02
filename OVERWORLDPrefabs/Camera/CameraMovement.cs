using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject follow;
    private float xFollow;
    private float yFollow;
    float height;
    float width;
    void Start()
    {
        ////////////////////////////////////////////
        // GET THE HEIGHT AND WIDTH OF THE CAMERA //
        ////////////////////////////////////////////
        Camera cam = Camera.main;
        height =2f* cam.orthographicSize;
        width = cam.aspect * height;
    }
    void Update()
    {

        /////////////////////////////////////////////////////////////////////////
        // FOLLOW THE PLAYER AND MAKE SURE THE CAMERA DOESN'T GO OUT OF BOUNDS //
        /////////////////////////////////////////////////////////////////////////
        if ( (follow.transform.position.x + width/2) < 54f  && (follow.transform.position.x - width/2) > -40f) {
            xFollow = follow.transform.position.x;
        }
        if ( (follow.transform.position.y + height / 2) < 31f && (follow.transform.position.y - height / 2) > -53f)
        {
            yFollow = follow.transform.position.y;
        }
        transform.position = new Vector3(xFollow, yFollow, -10);

    }
}
