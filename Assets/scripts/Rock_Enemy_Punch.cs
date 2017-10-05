using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Enemy_Punch : MonoBehaviour
{
    public BoxCollider2D punchcollider;

    // Use this for initialization
    void Start()
    {
        punchcollider = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (GetComponentInParent<Rock_Enemy>().curr_state == Rock_Enemy.STATE.ATTACK)
        {

        }
    }
}
