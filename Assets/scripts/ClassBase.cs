using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBase : MonoBehaviour {

    // The base class that all other player controllable classes should inherit from.        
    // See ClassMirror for example of inheritance.

    // Ground Checks
    public float HitDist;    
    public RaycastHit2D[] hits;
    public ContactFilter2D groundContacts;
    public float lastDistance;

    LayerMask terrainLayer;

    //The player controller. Use this to access/modify variables.
    public BaseController control;

    // TODO: Sprite Animation Hookup
    public SpriteRenderer sprite;
    public float speed;
    public Vector2 movement = new Vector2(0,0);

    //Rigidbody2D rb;
    Vector2 position;

    // Use this for initialization
    public virtual void Start ()
    {        
        control = transform.GetComponent<BaseController>();
        speed = BaseController.walkSpeed;

        terrainLayer = LayerMask.GetMask("Terrain");

        groundContacts.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        //groundContacts.useTriggers = true;        
        HitDist = 1f;
        HitDist = GetComponent<BoxCollider2D>().bounds.extents.y * 2;
        control.fallSpeed = 2.5f;
        control.maxWalkSpeed = 3.5f;
        control.walkSpeedMult = 1.0f;
        control.minJumpForce = 2f;
        control.maxJumpForce = 3f;
    }

    public virtual void HandleJump()
    {
<<<<<<< HEAD
        if (control.isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            control.rb.AddForce(Vector2.up * control.maxJumpForce, ForceMode2D.Impulse);
        }
=======
        //if (control.isGrounded && Input.GetButton("Jump"))
        //{            
        //    control.isGrounded = false;
        //    control.rb.velocity = new Vector2(control.rb.velocity.x, control.maxJumpForce);            
        //}

        //if (control.rb.velocity.y < 0)
        //{
        //    control.rb.velocity += Vector2.up * Physics2D.gravity.y * (control.fallSpeed - 1) * Time.deltaTime;

        //}
>>>>>>> dev

        //else if(control.rb.velocity.y > 0 && !Input.GetButton("Jump"))
        //{
        //    control.rb.velocity += Vector2.up * Physics2D.gravity.y * (control.minJumpForce - 1) * Time.deltaTime;

        //}

        //// Handle grounded        
        //RaycastHit2D hit2D = Physics2D.Raycast(position - new Vector2(0f, .5f), Vector2.down, HitDist, terrainLayer);

        //if (hit2D)
        //{
        //    control.isGrounded = true;
        //}

        //else
        //{
        //    control.isGrounded = false;

        //}
        hits = Physics2D.RaycastAll(control.transform.position, -control.transform.up, HitDist);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits != null && hits[i] != hits[i].collider.gameObject.tag.Equals("Player"))
                //hits[i] != hits[i].collider.gameObject.tag.Equals("SelfAI"))
            {
                //Debug.Log(hit[i].collider.gameObject.name);
                control.isGrounded = true;
            }
            else
            {
                control.isGrounded = false;
            }
<<<<<<< HEAD

            if (control.isGrounded && Input.GetButton("Jump"))
            {
                control.isGrounded = false;
                control.rb.velocity = new Vector2(control.rb.velocity.x, control.maxJumpForce);
            }

            if (control.rb.velocity.y < 0)
            {
                control.rb.velocity += Vector2.up * Physics2D.gravity.y * (control.fallSpeed - 1) * Time.deltaTime;

            }

            else if (control.rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                control.rb.velocity += Vector2.up * Physics2D.gravity.y * (control.minJumpForce - 1) * Time.deltaTime;

            }

            // Handle grounded        
            RaycastHit2D hit2D = Physics2D.Raycast(position - new Vector2(0f, .5f), Vector2.down, HitDist, terrainLayer);

            if (hit2D)
            {
                control.isGrounded = true;
            }

            else
            {
                control.isGrounded = false;
            }
=======

        }
        Debug.DrawRay(control.transform.position, -control.transform.up * HitDist, Color.red);

        if (control.isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            control.rb.AddForce(Vector2.up * control.maxJumpForce, ForceMode2D.Impulse);
            //Debug.Log("JAAAUP...");
            control.rb.gravityScale = 3f;
>>>>>>> dev
        }
    }

    public virtual void HandleInput()
    {
        if (control.isEnemyAI == false)
        {
            // Horizontal movement
            float xInput = Input.GetAxis("Horizontal");
<<<<<<< HEAD
=======

>>>>>>> dev

            movement.x = xInput * control.walkSpeedMult * speed;
            control.rb.AddForce(movement, ForceMode2D.Impulse);

            // Movement Speed Clamp
            if (control.rb.velocity.x > control.maxWalkSpeed)
                control.rb.velocity = new Vector2(control.maxWalkSpeed, control.rb.velocity.y);
            if (control.rb.velocity.x < -control.maxWalkSpeed)
                control.rb.velocity = new Vector2(-control.maxWalkSpeed, control.rb.velocity.y);

<<<<<<< HEAD

=======
>>>>>>> dev
            control.rb.velocity = new Vector2(xInput * control.maxWalkSpeed, control.rb.velocity.y);
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
