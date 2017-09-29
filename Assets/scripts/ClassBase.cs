using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBase : MonoBehaviour {

    // The base class that all other player controllable classes should inherit from.        
    // See ClassMirror for example of inheritance.


    //The player controller. Use this to access/modify variables.
    public BaseController control;

    // TODO: Sprite Animation Hookup
    public Sprite sprite;
    float speed;
    Vector2 movement = new Vector2(0,0);

    // Use this for initialization
    public virtual void Start ()
    {
        if (transform.GetComponent<BaseController>())
            control = transform.GetComponent<BaseController>();
        speed = BaseController.walkSpeed;
    }

    public virtual void HandleInput()
    {
        // Basic Horizontal movement
        float xInput = Input.GetAxis("Horizontal");
        
        movement.x = xInput * control.walkSpeedMult * speed;

        // JUMP
        if (Input.GetButton("Jump") && control.isJumping == false)
        {
            control.isJumping = true;
            control.isGrounded = false;
            movement.y += control.maxJumpForce;
        }

        control.rb.AddForce(movement, ForceMode2D.Impulse);        

        // ATTACK
        if (Input.GetButton("Fire1"))
        {
            //does nothing for base class
        }
    }

    public virtual void UpdateSprite()
    {
        switch (control.playerState)
        {
            case BaseController.PlayerState.ATTACK:
                //attack sprite
                break;

            case BaseController.PlayerState.IDLE:
                //idle sprite
                break;

            case BaseController.PlayerState.DEATH:
                //death sprite
                break;

            case BaseController.PlayerState.MIMIC:
                //mimic sprite
                break;
        }
                
    }

    // Update is called once per frame
    public virtual void Update () {
        HandleInput();
        UpdateSprite();


        // GO back to after doing actions if not doing anything
        switch (control.playerState)
        {
            case BaseController.PlayerState.ATTACK:
                //go back to idle after certain time
                break;

            case BaseController.PlayerState.MIMIC:
                //go back to idle after certain time
                break;
        }

    }
}
