using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

   


    void OnTriggerEnter(Collider Col) {
        if(Col.gameObject.tag == "Player"){
            Col.gameObject.GetComponent<Movement>().Restart();
        }
    }
}
