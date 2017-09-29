using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTako : ClassBase {

    public float HitDistance;
    public Rigidbody2D rb;
    float tempdt = 0f;
    RaycastHit2D[] hit;
    float startTime = 0.0f;
    float currentBTime;
    float jumpForce;

    //for max height of charged jump
    public float maxVelocity;

    // Use this for initialization
    public override void Start()
    {
        control.isJumping = false;
        control.maxJumpForce = 3f;
        
        rb = GetComponent<Rigidbody2D>();


    }
	
	// Update is called once per frame
	public override void Update ()
    {
        if (!control.isEnemyAI)
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
            if (control.isGrounded == true && Input.GetKeyUp(KeyCode.Space) )
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
                    rb.AddForce(Vector2.up * control.maxJumpForce * 2f, ForceMode2D.Impulse);
                    Debug.Log("maxy");
                    jumpForce = 0;

                }

            }
          


        }
        Debug.Log(jumpForce);
	}
}
