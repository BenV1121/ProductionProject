using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTako : ClassBase {

    public float HitDistance;
    public Rigidbody2D rb;
    float tempdt = 0f;
    float timer = 0;
    Vector2 LastPosition;
    RaycastHit2D[] hit;
    float currentBTime;
    float jumpForce;
    public float jumpMultiplyer;


    // Use this for initialization

    public override void HandleInput()
    {
        base.HandleInput();
    }



    public override void Start()
    {
        control = GetComponent<BaseController>();

        control.isJumping = false;
        control.maxJumpForce = 3f;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");

    }

    void OnTriggerStay2D(Collider2D other)
    {
        LastPosition = other.transform.position;
        Debug.Log("stay");
    }

    void OnTriggerExit2D(Collider2D other)
    {
       LastPosition = gameObject.transform.position;
        Debug.Log("exit");

    }

    public override void HandleJump()
    {
        hit = Physics2D.RaycastAll(transform.position, -transform.up, HitDistance);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit != null && hit[i] != hit[i].collider.gameObject.tag.Equals("Player"))
            {
                Debug.Log(hit[i].collider.gameObject.name);
                control.isGrounded = true;


            }
            else
            {
                control.isGrounded = false;


            }

        }
        Debug.DrawRay(transform.position, -transform.up * HitDistance, Color.red);



        if (control.isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            currentBTime = Time.time;
            Debug.Log("Charging...");
        }
        if (control.isGrounded == true && Input.GetKeyUp(KeyCode.Space))
        {
            jumpForce = Time.time - currentBTime;

            if ((jumpForce < 1))
            {
                rb.AddForce(Vector2.up * control.maxJumpForce, ForceMode2D.Impulse);
                Debug.Log("JAAAUP...");
                jumpForce = 0;


            }
            else
            {
                rb.AddForce(Vector2.up * control.maxJumpForce * jumpMultiplyer, ForceMode2D.Impulse);
                Debug.Log("maxy");
                jumpForce = 0;


            }

        }
        jumpForce = 0;

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
            if(timer > 1)
            {
                rb.AddForce(Vector2.up * control.maxJumpForce, ForceMode2D.Impulse);
                timer = 0;
            }
           
        }
        Debug.Log(timer);
	}
}
