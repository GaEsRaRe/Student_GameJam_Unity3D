using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public Camera camera;
    public float distance = 100f;
    GameObject examine;
	// Use this for initialization
	void Start () {
		
	}
	

    void select()
    {
        RaycastHit ray;
        if(Physics.Raycast(transform.position, transform.forward, out ray, distance))
        {
            if(ray.transform.gameObject.tag == "selectable")
            {
                create(ray.transform.gameObject);
            }
            
            Debug.Log(ray.transform.name);
        }
    }

    void create(GameObject dar)
    {
        examine = Instantiate(dar, new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z - 0.2f), new Quaternion(Quaternion.identity.x, Quaternion.identity.y, Quaternion.identity.z - 10, Quaternion.identity.w)) as GameObject;
        MeshCollider col;
        col = examine.transform.GetComponent<MeshCollider>();
        col.enabled = false;
    }
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            select();   
        }
	}
}
