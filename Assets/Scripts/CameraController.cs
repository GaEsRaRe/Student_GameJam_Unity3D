using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Shader camera_shader;


    void onEnable()
    {
        if(camera_shader != null)
        {
            GetComponent<Camera>().SetReplacementShader(camera_shader, "RenderType");
        }
    }

    void onDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }
}


