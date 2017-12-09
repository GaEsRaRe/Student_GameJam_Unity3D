using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody rigi;
    public Camera camera;
    public float camera_speed = 5.00f;
    public float camera_up = 5.00f;
    public float force = 10;
    float basic_speed = 0.05f;
    float double_speed = 0.09f;
    public float limit_up;
    public float limit_down;
    public float speed = 0.05f;
    float h = 0.0f;
    float v = 0.0f;
    // Use this for initialization
	void Start () {
        rigi = GetComponent<Rigidbody>() ;
        //camera = GetComponent<Camera>();
	}

    void Zoom()
    {
        if (Input.GetMouseButton(1)){
            camera.fieldOfView = 40;
        }else
        {
            camera.fieldOfView = 60;
        }
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = double_speed;
        }else
        {
            speed = basic_speed;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("is working");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0,0,speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -speed));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigi.AddForce(new Vector3(0,300,0));
        }

    }
        void calculate()
    {
        h = camera_speed * Input.GetAxis("Mouse X");
        v = camera_up * Input.GetAxis("Mouse Y");
    }
	// Update is called once per frame
	void Update () {
        calculate();
        Zoom();
        movement();

        transform.Rotate(new Vector3(0, h, 0));
        camera.transform.Rotate(new Vector3(-v, 0, 0));

        float temp = Mathf.Min(camera.transform.eulerAngles.x, 80);
        temp = Mathf.Max(camera.transform.eulerAngles.x, -80);
        camera.transform.localEulerAngles = new Vector3(temp,0,0);
    }
}
