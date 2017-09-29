using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBase : MonoBehaviour {

    // The base class that all other player controllable classes should inherit from.        
    // See ClassMirror for example of inheritance.

    // Ground Checks
    public float HitDist = 1.2f;    
    RaycastHit2D[] hits;

    //The player controller. Use this to access/modify variables.
    public BaseController control;

    // TODO: Sprite Animation Hookup
    public Sprite sprite;
    public float speed;
    public Vector2 movement = new Vector2(0,0);

    // Use this for initialization
    public virtual void Start ()
    {
        control = transform.GetComponent<BaseController>();
        speed = BaseController.walkSpeed;

        control.maxWalkSpeed = 2.5f;
        control.walkSpeedMult = 1.0f;
        control.maxJumpForce = 5f;
    }

    public virtual void HandleJump()
    {
        if (control.isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            control.rb.AddForce(Vector2.up * control.maxJumpForce, ForceMode2D.Impulse);
        }

        hits = Physics2D.RaycastAll(transform.position, -transform.up, HitDist);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits != null && hits[i] != hits[i].collider.gameObject.tag.Equals("Player"))
            {
                Debug.Log(hits[i].collider.gameObject.name);
                control.isGrounded = true;
            }
            else
            {
                control.isGrounded = false;
            }
        }
    }

    public virtual void HandleInput()
    {
        if (control.isEnemyAI == false)
        {
            // Horizontal movement
            float xInput = Input.GetAxis("Horizontal");

            movement.x = xInput * control.walkSpeedMult * speed;
            control.rb.AddForce(movement, ForceMode2D.Impulse);

            // Movement Speed Clamp
            if (control.rb.velocity.x > control.maxWalkSpeed)
                control.rb.velocity = new Vector2(control.maxWalkSpeed, control.rb.velocity.y);
            if (control.rb.velocity.x < -control.maxWalkSpeed)
                control.rb.velocity = new Vector2(-control.maxWalkSpeed, control.rb.velocity.y);


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
        
        UpdateSprite();

        if (control.isEnemyAI == false)
        {
            //Basic movement
            HandleInput();

            //Jump
            if (Input.GetButton("Jump"))
            {
                HandleJump();
            }
        }

    }
}
