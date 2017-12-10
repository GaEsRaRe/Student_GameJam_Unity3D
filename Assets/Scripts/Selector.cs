using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {
    public GameObject player;
    public Camera maincamera;
    public Camera scamera; //second camera
    public float distance = 100f;
    float scale;
    GameObject examine;
	// Use this for initialization
	void Start () {
		    
	}
	

    void select()
    {
        RaycastHit ray;
        if(Physics.Raycast(transform.position, transform.forward, out ray, distance))
        {
            if(ray.transform.gameObject.tag == "selectable" )
            {
                scale = 0.01f;
                create(ray.transform.gameObject);
                player.GetComponent<Movement>().State = 1;
                
            }
            if (ray.transform.gameObject.tag == "observable")
            {
                scale = 1;
                create(ray.transform.gameObject);
                player.GetComponent<Movement>().State = 3;
                
            }
            Debug.Log(ray.transform.name);
            
        }
    }

    void create(GameObject dar)
    {
        examine = Instantiate(dar, new Vector3(scamera.transform.position.x, scamera.transform.position.y, scamera.transform.position.z + 1.5f), new Quaternion(Quaternion.identity.x, Quaternion.identity.y, Quaternion.identity.z - 10, Quaternion.identity.w)) as GameObject;
        MeshCollider col;
        col = examine.transform.GetComponent<MeshCollider>();
        col.transform.localScale = new Vector3(1, 1, scale);
        col.enabled = false;
        maincamera.enabled = false;
        scamera.enabled = true;
        col.gameObject.AddComponent<RotateMouse>();
    }
	// Update is called once per frame
	void Update () {
        if(player.GetComponent<Movement>().State == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                select();
            }
        }  
	}
}
