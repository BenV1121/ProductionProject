using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGuyController : MonoBehaviour
{
	public Vector2 speed = new Vector2(1,1);

	// Update is called once per frame
	void Update ()
    {
        float inputX = Input.GetAxis("Horizontal");

        float jumpHeight = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpHeight = 10;
        }

        Vector3 movement = new Vector3(speed.x * inputX, jumpHeight, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);

        //bool shoot = Input.GetButton("Fire1");
        //shoot |= Input.GetButton("Fire2");

        //if (shoot)
        //{
        //    FireProjectileScript weapon = GetComponent<FireProjectileScript>();
        //    if (weapon != null)
        //    {
        //        weapon.Attack(false);
        //    }
        //}
    }
}
