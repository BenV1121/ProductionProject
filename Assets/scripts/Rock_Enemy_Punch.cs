using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Enemy_Punch : MonoBehaviour {

    GameObject parent;
    enum STATE { MOVE_LEFT, MOVE_RIGHT, STAND_STILL, LANDING, REEL_BACK, ATTACK }

    // Use this for initialization
    void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(parent.GetComponent<Rock_Enemy>().curr_state == STATE.ATTACK)
        {

        }
    }
}
