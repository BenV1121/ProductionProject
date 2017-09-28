using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBase : MonoBehaviour {

    // The base class that all other player controllable classes should inherit from.        
    // See ClassMirror for example of inheritance.

    public float HitDist = 1.2f;    
    RaycastHit2D[] hits;

    //The player controller. Use this to access/modify variables.
    public BaseController control;

    // TODO: Sprite Animation Hookup
    public Sprite sprite;
    float speed;
    Vector2 movement = new Vector2(0,0);

    // Use this for initialization
    public virtual void Start ()
    {        
        control = transform.GetComponent<BaseController>();
        speed = BaseController.walkSpeed;
    }

    public virtual void HandleJump()
    {
        hits = Physics2D.RaycastAll(transform.position, -transform.up, HitDist);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits != null && hits[i] != hits[i].collider.gameObject.tag.Equals("Player"))
            {
                Debug.Log(hits[i].collider.gameObject.name);
                control.isJumping = true;
            }
            else
            {
                control.isJumping = false;
            }
        }
    }

    public virtual void HandleInput()
    {
        // Basic Horizontal movement
        float xInput = Input.GetAxis("Horizontal");
        
        movement.x = xInput * control.walkSpeedMult * speed;
        control.rb.AddForce(movement, ForceMode2D.Impulse);

        // Movement Clamping
        if (control.rb.velocity.x > control.maxWalkSpeed)
            control.rb.velocity = new Vector2(control.maxWalkSpeed, control.rb.velocity.y);
        if (control.rb.velocity.x < -control.maxWalkSpeed)
            control.rb.velocity = new Vector2(-control.maxWalkSpeed, control.rb.velocity.y);



        if (control.isJumping == true && Input.GetKeyDown(KeyCode.Space))
        {
            control.rb.AddForce(Vector2.up * control.maxJumpForce, ForceMode2D.Impulse);

        }

        // Attack
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

    public virtual void FixedUpdate()
    {
        HandleInput();

        //Jump
        if (Input.GetButton("Jump"))
        {
            HandleJump();
        }
    }

    // Update is called once per frame
    public virtual void Update () {
        //HandleInput();
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
