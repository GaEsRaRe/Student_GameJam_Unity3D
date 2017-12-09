using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_camera_selector : MonoBehaviour {


    [Range(0, 10)]
    public float Intensity = 2;

    private Material _compositeMat;

    void OnEnable()
    {
        _compositeMat = new Material(Shader.Find("Hidden/GlowComposite"));
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        _compositeMat.SetFloat("_Intensity", Intensity);
        Graphics.Blit(src, dst, _compositeMat, 0);
    }
}

