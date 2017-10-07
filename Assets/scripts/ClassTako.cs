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
    float jumpTime = 0f;

 
 //// AI CODE
    //timer being used for AI
    float timer = 0;
    //last know enemy position
    Vector2 LastPosition;
    bool SetLastPosition;

    public override void HandleInput()
    {
        base.HandleInput();
    }



    public override void Start()
    {
        base.Start();
        control = GetComponent<BaseController>();

        control.isJumping = false;
       // control.maxJumpForce = 0f;
        rb = GetComponent<Rigidbody2D>();
        HitDistance = 1f;
        control.minJumpForce = 4.5f;
        control.maxJumpForce = 7f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //LastPosition = other.transform.position;
            SetLastPosition = true;
            Debug.Log("player enter");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            LastPosition = other.transform.position;            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetLastPosition = false;
            Debug.Log("player exit");
        }
    }

    public void CanJump()
    {
        hit = Physics2D.RaycastAll(transform.position, -transform.up, HitDistance);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit != null &&
                hit[i] != hit[i].collider.gameObject.tag.Equals("Player") &&
                hit[i] != hit[i].collider.gameObject.tag.Equals("SelfAI"))
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
                rb.AddForce(Vector2.up * control.minJumpForce, ForceMode2D.Impulse);
               //Debug.Log("JAAAUP...");
                rb.gravityScale = 3f;



            }
            else
            {
                rb.AddForce(Vector2.up * control.maxJumpForce, ForceMode2D.Impulse);
                rb.gravityScale = 3.5f;
               
                //Debug.Log("maxy");
                


            }

        }
        if(control.isGrounded == false)
        {
            GameTime = Time.time;

        }



    }

    void JumpTowardPoint()
    {
       // float gravity = Physics.gravity.magnitude;
      //  float initialVelocity = CalculateJumpSpeed(50, gravity) / 30;

        Vector2 direction = (LastPosition - rb.position);
        Debug.Log(direction);

        if(direction.x > 0 && SetLastPosition == true)
        {
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            rb.AddForce(Vector2.right * 2f, ForceMode2D.Impulse);

        }
        else if (direction.x < 0 && SetLastPosition == true)
        {
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            rb.AddForce(Vector2.left * 2f, ForceMode2D.Impulse);

        }
    }

    private float CalculateJumpSpeed(float jumpHeight, float gravity)
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
   
    public void AIscript()
    {
        CanJump();
       
        //default jump
        if (timer > 1 && control.isGrounded == true)
        {
            rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);

            timer = 0;
        }
        else if (LastPosition != null && SetLastPosition == true && control.isGrounded == true)
        {
          
            JumpTowardPoint();

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
            this.gameObject.tag = ("SelfAI");
            AIscript();
           // Invoke("AIscript", 2);
        }
        
       

    }
}
