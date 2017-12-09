using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuerta : MonoBehaviour {
	int tiempo = 100;
	int tiempoTranscurrido = 0;
	bool abrir = false;
	bool cerrar = false;
	bool abierta = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {



		if (abrir) {
			AbrirPuerta();
		}
		if (cerrar) {
			cerrarPuerta();
		}
	}

	// Abrir puerta
	void AbrirPuerta () {
		if (tiempo > tiempoTranscurrido) {
			transform.Rotate (0, Time.deltaTime * 50, 0);
			tiempoTranscurrido++;
		} else {
			tiempoTranscurrido = 0;
			abrir = false;
			cerrar = true;
			abierta = true;
		}
	}

	// Cerrar puerta
	void cerrarPuerta() {
		if (tiempo > tiempoTranscurrido) {
			transform.Rotate (0, Time.deltaTime * -50, 0);
			tiempoTranscurrido++;
		} else {
			tiempoTranscurrido = 0;
			cerrar = false;
			abierta = false;
		}
	}

	// Colision con personaje
	void OnTriggerStay(Collider Other){
		
		if(Input.GetKeyDown(KeyCode.E)){
			abrir = true;
		}
	}
	void OnTriggerExit()
	{
		if (abierta) {
			cerrar = true;
		}
	}
}
