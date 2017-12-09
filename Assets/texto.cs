using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texto : MonoBehaviour {
	MeshRenderer m;
	bool mostrar = true;
	// Use this for initialization
	void Start () {
		m = GetComponent<MeshRenderer> ();
		m.enabled = false;
	}

	void OnTriggerEnter (Collider Other){
		
		if (Other.gameObject.CompareTag ("Player") && mostrar) {
			
			mostrar = false;
			m.enabled = true;
		}
	}
	void OnTriggerExit (Collider Other){

		if (Other.gameObject.CompareTag ("Player")) {

			m.enabled = false;
		}
	}
}
