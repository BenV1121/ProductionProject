using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassFire : ClassBase
{
    FireProjectileScript fps;

    CircleCollider2D fireRange;

    // Use this for initialization
    public override void Start()
    {
        base.Start();        
        if (control.isEnemyAI == true)
        {
            fireRange = gameObject.AddComponent<CircleCollider2D>();
            fireRange.isTrigger = true;
            fireRange.radius = 1f;
        }

        if (transform.GetComponent<BaseController>())
            control = transform.GetComponent<BaseController>();

        fps = gameObject.AddComponent<FireProjectileScript>();

        fireRange.isTrigger = true;
        fireRange.radius = 1f;

    }

    public override void HandleInput()
    {
        base.HandleInput();

        bool shoot = Input.GetButton("Fire1");

        if (shoot)
        {
            FireProjectileScript weapon = GetComponent<FireProjectileScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }

    public override void UpdateSprite()
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

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    // Update is called once per frame
    override public void Update()
    {
        base.Update();        

        //if (control.isEnemyAI == false)
        //{
        //    //Basic movement
        //    HandleInput();

        //    //Jump
        //    if (Input.GetButton("Jump"))
        //    {
        //        HandleJump();
        //    }
        //}

        //// Handle Death
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        FireProjectileScript weapon = GetComponent<FireProjectileScript>();

        if (other.gameObject.tag == "Player")
        {
            weapon.Attack(true);

            //Debug.Log("hi");
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        FireProjectileScript weapon = GetComponent<FireProjectileScript>();

        if (other.gameObject.tag == "Player")
        {
            weapon.Attack(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        FireProjectileScript weapon = GetComponent<FireProjectileScript>();

        if (other.gameObject.tag == "Player")
        {
            weapon = null;
        }
    }
}