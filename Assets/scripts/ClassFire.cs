using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassFire : ClassBase
{
    // Use this for initialization
    public override void Start()
    {
        if (transform.GetComponent<BaseController>())
            control = transform.GetComponent<BaseController>();
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

    // Update is called once per frame
    override public void Update()
    {

        //If this is an enemy AI, 
        if (control.isEnemyAI)
        {
            // do AI stuff
        }

        else
        {
            // do playerInput stuff
            HandleInput();
        }

        // Handle Death


    }
}
