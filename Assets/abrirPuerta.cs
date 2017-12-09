using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuerta : MonoBehaviour {
	int tiempo = 300;
	int tiempoAbriendo = 0;
	bool abrir = false;
	bool cerrar = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.E)){
			abrir = true;
		}
		if (abrir) {
			abrirPuerta();
		}
	}

	// Abrir puerta
	void abrirPuerta() {
		if (tiempo > tiempoAbriendo) {
			transform.Rotate (0, Time.deltaTime * 20, 0);
			tiempoAbriendo++;
		} else {
			tiempoAbriendo = 0;
			abrir = false;
		}
	}

	// Abrir puerta
	void cerrarPuerta() {
		if (tiempo > tiempoAbriendo) {
			transform.Rotate (0, Time.deltaTime * -20, 0);
			tiempoAbriendo++;
		} else {
			tiempoAbriendo = 0;
			abrir = false;
		}
	}
}
