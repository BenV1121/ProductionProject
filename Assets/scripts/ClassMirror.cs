using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMirror : ClassBase {

    // The default starting character: Mirror
    

	// Use this for initialization
	override public void Start ()
    {
		
	}    

    public void HandleInput()
    {
        // MOVEMENT
        //if colliding == true 
        //&& collider.gameObject.getcomponentnt<baseController>().playerClass == ClassRockGuy
        //&& collider.gameObject.getcomponentnt<baseController>().playerState == PlayerState.ATTACK

        // JUMP
        if (Input.GetButton("Jump"))
        {
            // Do jump
        }

        // ATTACK
        if (Input.GetButton("Fire1"))
        {
            //does nothing for mirror class
        }

        // MIMIC
        if (Input.GetButton("Fire2"))
        {
            //if colliding
            //playerClass = collidingsclass
            //collidingclass disabled

        }
         
    }

    // Update is called once per frame
    override public void Update () {

        //If this is an enemy AI, 
        if (control.isEnemyAI)
        {
            // do AI stuff


        }

        else
        {
            // do playerInput stuff
            HandleInput();
        }       

    }
}
