using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTako : ClassBase {

    public float HitDistance = 1.2f;
    public Rigidbody2D rb;
    float tempdt = 0f;
    RaycastHit2D[] hit;
    float startTime;
    float elapsedTime;

    // Use this for initialization
    public override void Start()
    {
         startTime = Time.deltaTime;

        control.isJumping = false;
        control.maxJumpForce = 5f;

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
                   
                    control.isJumping = false;

                }
                else if(control.isJumping == true)
                {
                    control.isGrounded = false;
                }
            }
            Debug.DrawRay(transform.position, -transform.up * HitDistance, Color.red);



            //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
            //if(hit.collider != null)
            //{
            //    float distance = Mathf.Abs(hit.point.y - transform.position.y);
            //    float heightError = floatHeight - distance;
            //    // float force = lifeForce * heightError - rb.velocity.y * damping
            //    return hit;

            //}
            if (control.isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                elapsedTime = Time.time - startTime;
                Debug.Log("Charging...");
            }
            if(control.isGrounded == true && Input.GetKeyUp(KeyCode.Space))
            {
                    rb.AddForce(Vector2.up * control.maxJumpForce , ForceMode2D.Impulse);
                    control.isJumping = true;
                Debug.Log("JAAAUP...");
            }

            
        }
	}
}
