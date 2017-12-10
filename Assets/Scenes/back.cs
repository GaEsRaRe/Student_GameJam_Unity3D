using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.TransitionKit;

public class back : MonoBehaviour {

	public void cambiarNivel(){

		TransitionKit.instance.transitionWithDelegate( fishEye );
	}

	FishEyeTransition fishEye = new FishEyeTransition()
	{
		nextScene = 0,
		duration = 1.0f,
		size = 0.08f,
		zoom = 10.0f,
		colorSeparation = 3.0f
	};
}