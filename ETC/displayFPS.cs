using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayFPS : MonoBehaviour
{

    public Text fps_text;
    string fps_string = "FPS: ";
    float time;


    void Update()
    {

        time += (Time.deltaTime - time) * 0.1f;
        float fps = 1.0f / time;
        fps_text.text = fps_string + Mathf.Ceil(fps).ToString();

    }
}
