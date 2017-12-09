using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMouse : MonoBehaviour {
    public AudioClip otherClip;
    AudioSource audioSource;
    public float speed = 2f;
    float h = 0.0f;
    float v = 0.0f;
    Rigidbody rigi;

    // Use this for initialization
    void Start () {
      

    }

    void calculate()
    {
        h = speed * Input.GetAxis("Mouse X");
        v = speed * Input.GetAxis("Mouse Y");
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButton(0))
        {   
            calculate();
            transform.Rotate(new Vector3(0, h, 0));
            //transform.Rotate(new Vector3(v, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Object.Destroy(this.gameObject);
        }
        
    }
}
