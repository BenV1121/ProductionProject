using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Enemy_AI : MonoBehaviour {

    public BoxCollider2D detectionCollider;
    float attackRange = 1.0f;

    // Use this for initialization
    void Start () {
        
        detectionCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player" && GetComponentInParent<Rock_Enemy>().curr_state == Rock_Enemy.STATE.STAND_STILL)
        {
            if (Mathf.Abs(collider.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x) <= attackRange)
            {
                GetComponentInParent<Rock_Enemy>().BeginAttack();
            }
            else
            {
                if (collider.GetComponent<Transform>().position.x < GetComponent<Transform>().position.x)
                {
                    GetComponentInParent<Rock_Enemy>().BeginMoveRight();
                }
                if (collider.GetComponent<Transform>().position.x > GetComponent<Transform>().position.x)
                {
                    GetComponentInParent<Rock_Enemy>().BeginMoveLeft();
                }
            }
        }
    }
}
