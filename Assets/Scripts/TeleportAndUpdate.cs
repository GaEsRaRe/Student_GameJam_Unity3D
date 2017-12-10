using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAndUpdate : MonoBehaviour {

    public Vector3 Pos;  //pos to teleport
    public Vector3 Angle;

    public int State = 0; //0 on, 1 off
    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Player" && State == 0)
        {
            Col.gameObject.GetComponent<Movement>().Teleport(Pos);
            Col.gameObject.transform.eulerAngles = Angle;
        }
    }
}
