using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Manager GameManager_properties = Manager.getInstance();
    public Vector2 BOUNDARIES_POS;
    public Vector2 BOUNDARIES_NEG;
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

        ////////////////////////////////////////////////
        // SET UP THE STARTING POSITION OF THE CAMERA //
        ////////////////////////////////////////////////
        xFollow = GameManager_properties.get_jerry_last_pos().x;
        yFollow = GameManager_properties.get_jerry_last_pos().y;
        if (xFollow + width/2 > BOUNDARIES_POS.x) { xFollow = BOUNDARIES_POS.x - width/2; }
        if (yFollow + height/2 > BOUNDARIES_POS.y) { yFollow = BOUNDARIES_POS.y - height/2; }
        if (xFollow - width/2 < BOUNDARIES_NEG.x) { xFollow = BOUNDARIES_NEG.x + width/2; }
        if (yFollow - height/2 < BOUNDARIES_NEG.x) { yFollow = BOUNDARIES_NEG.y + height/2; }

    }
    void Update()
    {

        /////////////////////////////////////////////////////////////////////////
        // FOLLOW THE PLAYER AND MAKE SURE THE CAMERA DOESN'T GO OUT OF BOUNDS //
        /////////////////////////////////////////////////////////////////////////   
        if ( (follow.transform.position.x + width/2) < BOUNDARIES_POS.x  && (follow.transform.position.x - width/2) > BOUNDARIES_NEG.x) 
        {
            xFollow = follow.transform.position.x;
        }
        if ( (follow.transform.position.y + height/2) < BOUNDARIES_POS.y && (follow.transform.position.y - height/2) > BOUNDARIES_NEG.y)
        {
            yFollow = follow.transform.position.y;
        }     
        transform.position = new Vector3(xFollow, yFollow, -10);

    }
}
