//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ClassFire : MonoBehaviour
//{

//    //The player controller. Use this to access/modify variables.
//    public BaseController control;

//    // TODO: Sprite Animation Hookup
//    public Sprite sprite;

//    // Use this for initialization
//    public virtual void Start()
//    {
//        if (transform.GetComponent<BaseController>())
//            control = transform.GetComponent<BaseController>();
//    }

//    public virtual void HandleInput()
//    {

//    }

//    public virtual void UpdateSprite()
//    {
//        switch (control.playerState)
//        {
//            case BaseController.PlayerState.ATTACK:
//                //attack sprite
//                break;

//            case BaseController.PlayerState.IDLE:
//                //idle sprite
//                break;

//            case BaseController.PlayerState.DEATH:
//                //death sprite
//                break;

//            case BaseController.PlayerState.MIMIC:
//                //mimic sprite
//                break;
//        }

//    }
//}
