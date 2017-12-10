using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.TransitionKit;

public class puertaTeletrans2 : MonoBehaviour {
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

	public int tipo;

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
					if (tipo == 0) {
						if (!cerrar && !abierta) {
							abrir = true;
							aS.PlayOneShot (sndAbrir, 80.0f);
						}
					} else if (tipo == 1) {

						cambiarNivel ();
					}else {
						Debug.Log ("Ya lo buggeaste carajo");
					}
				}
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
	public void cambiarNivel(){

		TransitionKit.instance.transitionWithDelegate( fishEye );
	}

	FishEyeTransition fishEye = new FishEyeTransition() {
		nextScene = 2,
		duration = 1.0f,
		size = 0.08f,
		zoom = 10.0f,
		colorSeparation = 3.0f
	};
}
