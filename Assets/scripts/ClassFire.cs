using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassFire : ClassBase
{

    //The player controller. Use this to access/modify variables.
    public BaseController control;

    // TODO: Sprite Animation Hookup
    public Sprite sprite;

    // Use this for initialization
    public override void Start()
    {
        if (transform.GetComponent<BaseController>())
            control = transform.GetComponent<BaseController>();
    }

    public override void HandleInput()
    {

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
}
