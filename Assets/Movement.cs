using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody rigi;
    public int State = 0;
    public Camera camera;
    public Camera secondcamera;
    public float camera_speed = 5.00f;
    public float camera_up = 5.00f;
    public float force = 10;
    float basic_speed = 0.03f;
    float double_speed = 0.05f;
    public float limit_up;
    public float limit_down;
    public float speed = 0.05f;
    public bool temp = false;
    Vector3 checkpoint;
    float h = 0.0f;
    float v = 0.0f;
    //To be unable to read two times the same document
    bool readed = false;

    //AUDIO

    public AudioClip otherClip;
    AudioSource audioSource;

    //AudioSource m_MyAudioSource;
    bool camina = false;
	bool empiezaCaminar = false;
    // Use this for initialization
	void Start () {
        rigi = GetComponent<Rigidbody>() ;

        audioSource = GetComponent<AudioSource>();
        checkpoint = transform.position;
        secondcamera.enabled = false;
        camera.enabled = true;
        //camera = GetComponent<Camera>();
		//m_MyAudioSource = GetComponent<AudioSource>();
	}
    

    public void Teleport(Vector3 Post)
    {
        transform.position = Post;
        readed = false;
        checkpoint = Post;
    }

    public void Restart()
    {
        transform.position = checkpoint;
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
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (new Vector3 (-speed, 0, 0));
		}
        if (Input.GetKey(KeyCode.D))
        {
			transform.Translate(new Vector3(speed, 0, 0));
		}
        if (Input.GetKey(KeyCode.W))
        {
			transform.Translate(new Vector3(0,0,speed));
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (new Vector3 (0, 0, -speed));
		}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigi.AddForce(new Vector3(0,300,0));
        }
        /*
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) ||
		   Input.GetKey(KeyCode.S) || Input.GetKey (KeyCode.D)) {
			camina = true;
			if (empiezaCaminar) m_MyAudioSource.Play ();
		}else
			camina = false;
		if (camina) {
			m_MyAudioSource.loop = true;
			empiezaCaminar = false;
		} else {
			m_MyAudioSource.loop = false;
			m_MyAudioSource.Stop ();
			empiezaCaminar = true;
		}
        */


    }

    void PlaySound()
    {
        if(State == 1)
        {
            audioSource.Play();
            State = 2;
        }

    }
        void calculate()
    {
        h = camera_speed * Input.GetAxis("Mouse X");
        v = camera_up * Input.GetAxis("Mouse Y");
    }
	// Update is called once per frame
	void Update () {
        switch (State) {
            case 0:  //Normal Movement
                calculate();
                Zoom();
                movement();

                transform.Rotate(new Vector3(0, h, 0));
                camera.transform.Rotate(new Vector3(-v, 0, 0));

                float temp = Mathf.Min(camera.transform.eulerAngles.x, 80);
                temp = Mathf.Max(camera.transform.eulerAngles.x, -80);
                camera.transform.localEulerAngles = new Vector3(temp, 0, 0);
                break;
            case 1: //Rotating the object
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (!readed)
                    {
                        PlaySound();
                        State = 2;
                    }
                    else
                    {
                        secondcamera.enabled = false;
                        camera.enabled = true;
                        State = 0;
                    }
                   
                   
                }

                break;
            case 2:
                if (!audioSource.isPlaying)
                {
                    secondcamera.enabled = false;
                    camera.enabled = true;
                    State = 0;
                    readed = true;
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                   
                        secondcamera.enabled = false;
                        camera.enabled = true;
                        State = 0;
                }
                break;
        }
       
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("lala");
        if (col.gameObject.tag == "Platform")
        {
            Debug.Log("hASF");
            transform.SetParent(col.gameObject.transform);

        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Platform")
        {
            Debug.Log("hASF");
            transform.parent = null; 

        }
    }
}
