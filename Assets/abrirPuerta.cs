using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuerta : MonoBehaviour {
	int tiempo = 100;
	int tiempoTranscurrido = 0;
	bool abrir = false;
	bool cerrar = false;
	bool abierta = false;
	public bool llave;
	public AudioClip sndAbrir;
	public AudioClip sndCerrar;
	public AudioClip sndCerrado;
	AudioSource aS;

	public void SetLlave(){
		llave = true;
	}
	// Use this for initialization
	void Start () {
		llave = false;
		aS = GetComponent<AudioSource>();
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
			aS.PlayOneShot (sndCerrar,90.0f);
		}
	}

	// Colision con personaje
	void OnTriggerStay(Collider Other){

		if (llave) {
			if (Other.gameObject.CompareTag ("Player")) {
				if (Input.GetKeyDown (KeyCode.E)) {
					if (!cerrar && !abierta) {
						abrir = true;
						aS.PlayOneShot (sndAbrir, 80.0f);
					}
				} 
			}
		} else {
			if (Input.GetKeyDown (KeyCode.E)) {
				aS.PlayOneShot (sndCerrado, 80.0f);
				Debug.Log ("dlg,fmgklfd");
			}
		}
	}
	void OnTriggerExit(Collider Other)
	{
		if (Other.gameObject.CompareTag ("Player")) {
			if (abierta&&!abrir) {
				cerrar = true;
			}
		}
	}
}
