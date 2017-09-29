using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////////////////
// A slow enemy that doesn't do anything except move slowly
////////////////////////////////////////////////////////////////

public class ClassSlowGuy : ClassBase {            

    // Use this for initialization
    override public void Start ()
    {
        base.Start();

        control.maxWalkSpeed = 1.25f;
        control.walkSpeedMult = .95f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    override public void HandleInput()
    {
        // Use default movement and jump
        base.HandleInput();     

        // ATTACK
        if (Input.GetButton("Fire1"))
        {
            //TODO
        }
    }

    void moveAround()
    {

    }

    override public void FixedUpdate()
    {
        if (!control.isEnemyAI)
        {
            HandleInput();
        }
    }

    // Update is called once per frame
    override public void Update () {

        //If this is an enemy AI, 
        if (control.isEnemyAI)
        {
            // Moveback from left to right
            
        }
    }
}
