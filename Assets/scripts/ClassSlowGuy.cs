using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////////////////
// A slow enemy that doesn't do anything except move slowly
////////////////////////////////////////////////////////////////

public class ClassSlowGuy : ClassBase {

    // Variables for AI behavior
    public Vector2 StartPos, LeftExtent, RightExtent;
    bool goingLeft = true;
    float moveTimer = 0f;

    // Use this for initialization
    override public void Start ()
    {
        base.Start();

        LeftExtent = RightExtent = StartPos = transform.position;

        LeftExtent.x = LeftExtent.x - Random.Range(1,3);
        RightExtent.x = RightExtent.x + Random.Range(1,3);

        control.maxJumpForce = 1.2f;
        control.maxWalkSpeed = 1.05f;
        control.walkSpeedMult = .92f;
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

    void MoveTowardsExtents()
    {  
        if (goingLeft)
        {
            moveTimer += Time.deltaTime;
            control.rb.velocity = new Vector2(-control.maxWalkSpeed/2, control.rb.velocity.y);
            if (transform.position.x < LeftExtent.x || moveTimer > 10)
            {
                goingLeft = false;
                moveTimer = 0f;
            }
        }

        if (!goingLeft)
        {
            moveTimer += Time.deltaTime;
            control.rb.velocity = new Vector2(control.maxWalkSpeed/2, control.rb.velocity.y);
            if (transform.position.x > RightExtent.x || moveTimer > 10)
            {
                goingLeft = true;
                moveTimer = 0f;
            }
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }



    // Update is called once per frame
    override public void Update () {
        base.Update();

        if (control.isEnemyAI)
        {
            MoveTowardsExtents();
        }
    }
}
