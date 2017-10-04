using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBase : MonoBehaviour {

    // The base class that all other player controllable classes should inherit from.        
    // See ClassMirror for example of inheritance.

    // Ground Checks
    public float HitDist = 1.2f;    
    public RaycastHit2D[] hits;
    public ContactFilter2D groundContacts;

    //The player controller. Use this to access/modify variables.
    public BaseController control;

    // TODO: Sprite Animation Hookup
    public SpriteRenderer sprite;
    public float speed;
    public Vector2 movement = new Vector2(0,0);

    Rigidbody2D rb;
    Vector2 position;

    // Use this for initialization
    public virtual void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        control = transform.GetComponent<BaseController>();
        speed = BaseController.walkSpeed;

        groundContacts.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        groundContacts.useTriggers = true;        

        control.fallSpeed = 2.5f;
        control.maxWalkSpeed = 3.5f;
        control.walkSpeedMult = 1.0f;
        control.minJumpForce = 2f;
        control.maxJumpForce = 5f;
    }

    public virtual void HandleJump()
    {

        if (control.isGrounded && Input.GetButton("Jump"))
        {            
            control.isGrounded = false;
            control.rb.velocity = new Vector2(control.rb.velocity.x, control.maxJumpForce);            
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (control.fallSpeed - 1) * Time.deltaTime;
        }

        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (control.minJumpForce - 1) * Time.deltaTime;
        }

        // Handle grounded
        Physics2D.Linecast(position, position - new Vector2(0, -1), groundContacts, hits);

        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[i])
            {
                control.isGrounded = true;
            }

            else
            {
                control.isGrounded = false;
            }
        }
        

        //if (Physics2D.Linecast(position, position - new Vector2(0.33f, -1), LayerMask.NameToLayer("Terrain")))
        //{
        //    control.isGrounded = true;
        //}
        //else if (Physics2D.Linecast(position, position - new Vector2(-0.33f, -1), LayerMask.NameToLayer("Terrain")))
        //{
        //    control.isGrounded = true;
        //}
    }

    public virtual void HandleInput()
    {
        if (control.isEnemyAI == false)
        {
            // Horizontal movement
            float xInput = Input.GetAxis("Horizontal");

            control.rb.velocity = new Vector2(xInput * control.maxWalkSpeed, rb.velocity.y);

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
        if (control.isEnemyAI == false)
        {
            //Basic movement
            HandleInput();

            //Jump
            HandleJump();
        }
    }
     
    // Update is called once per frame
    public virtual void Update () {

        position = new Vector2(transform.position.x, transform.position.y);

        UpdateSprite();

    }
}
