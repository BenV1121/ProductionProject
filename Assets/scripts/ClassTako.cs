using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTako : ClassBase {

    public float HitDistance = 1.2f;
    public Rigidbody2D rb;
    RaycastHit2D[] hit;

	// Use this for initialization
	void Start ()
    {
        control.isJumping = false;
        control.maxJumpForce = 5f;

        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        hit = Physics2D.RaycastAll(transform.position, -transform.up, HitDistance);
        for (int i = 0; i < hit.Length; i++)    
        {
            if (hit != null && hit[i] != hit[i].collider.gameObject.tag.Equals("Player")) 
            {
                Debug.Log(hit[i].collider.gameObject.name);
                control.isJumping = true;
            }
            else
            {
                control.isJumping = false;
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
        if (control.isJumping == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * control.maxJumpForce, ForceMode2D.Impulse);
 
        }
	}
}
