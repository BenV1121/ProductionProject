using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTako : ClassBase {

    public Rigidbody2D rb;
   

    //raycast for jump targets
    public float HitDistance;
    RaycastHit2D[] hit;


    //the time current time the button has been helpd
    float GameTime;
    //temporary delta time
    float tempdt = 0f;
    float jumpTime = 0f;
    public float jumpforce;
    public float jumpMultiplyer;

 
 //// AI CODE
    //timer being used for AI
    float timer = 0;
    //last know enemy position
    Vector2 LastPosition;


    public override void HandleInput()
    {
        base.HandleInput();
    }



    public override void Start()
    {
        control = GetComponent<BaseController>();

        control.isJumping = false;
       // control.maxJumpForce = 0f;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("enter");

    }

    void OnTriggerStay2D(Collider2D other)
    {
        LastPosition = other.transform.position;
        //Debug.Log("stay");
    }

    void OnTriggerExit2D(Collider2D other)
    {
       LastPosition = gameObject.transform.position;
       //Debug.Log("exit");

    }

    public void CanJump()
    {
        hit = Physics2D.RaycastAll(transform.position, -transform.up, HitDistance);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit != null && hit[i] != hit[i].collider.gameObject.tag.Equals("Player"))
            {
                //Debug.Log(hit[i].collider.gameObject.name);
                control.isGrounded = true;


            }
            else
            {
                control.isGrounded = false;



            }

        }
        Debug.DrawRay(transform.position, -transform.up * HitDistance, Color.red);
    }
    public override void HandleJump()
    {
        CanJump();


        if (control.isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            //starting game time from button down
            GameTime = Time.time;
            Debug.Log("Charging...");

        }
        if (control.isGrounded == true && Input.GetKeyUp(KeyCode.Space))
        {
           

            //subtract the current game time by what it was when button first started getting held down
            jumpTime = Time.time - GameTime;
            Debug.Log(jumpTime);

            if ((jumpTime < .65))
            {
                rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
               //Debug.Log("JAAAUP...");
                rb.gravityScale = 3f;



            }
            else
            {
                rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
                rb.gravityScale = 3.5f;
               
                //Debug.Log("maxy");
                


            }

        }
        if(control.isGrounded == false)
        {
            GameTime = Time.time;

        }



    }

    // Update is called once per frame
    public override void Update ()
    {
        HandleInput();
        timer += Time.deltaTime;

        if (!control.isEnemyAI)
        {
            HandleJump();
        }
        if(control.isEnemyAI)
        {
            CanJump();
            if (timer > 1 && control.isGrounded == true)
            {
                rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
               
                timer = 0;
            }
           
        }
        if(control.isGrounded)
            Debug.Log("grounded");
        else
            Debug.Log("Air");


    }
}
