using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMirror : ClassBase {

    // The default starting character: Mirror
    public BoxCollider2D mimicCollider;
    bool canMimic = false;
    ClassBase otherClass;   

	// Use this for initialization
	override public void Start ()
    {
        mimicCollider = gameObject.AddComponent<BoxCollider2D>();                
        mimicCollider.size = new Vector3(1.5f, 1f, 1f);

        otherClass = null;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BaseController>())
        {
            canMimic = true;
            otherClass = other.gameObject.GetComponent<BaseController>().playerClass;
        }
        else
        {
            canMimic = false;
            otherClass = null;
        }
    }

    override public void HandleInput()
    {
        // Use default movement and jump
        base.HandleInput();

        // MIMIC
        if (Input.GetButton("Fire2") && canMimic)
        {
            control.playerState = BaseController.PlayerState.MIMIC;

            if (otherClass != null)
            {
                control.playerClass = otherClass;                
                Destroy(otherClass.gameObject);                
            } 
            
        }

        // ATTACK
        if (Input.GetButton("Fire1"))
        {
            //mirror class can't attack
        }
    }

    // Update is called once per frame
    override public void Update () {

        //If this is an enemy AI, 
        if (control.isEnemyAI)
        {
            // do AI stuff
            // Mirror doesn't have AI (maybe)
        }

        else
        {
            // do playerInput stuff
            HandleInput();
        }       

        // Handle Death


    }
}
