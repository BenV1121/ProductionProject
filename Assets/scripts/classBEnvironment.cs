using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class classBEnvironment : MonoBehaviour {

    //im using this to indicate wether a wall is wood or rock
    public enum walltyp { ROCK, WOOD};
    public walltyp thiswallis;
    SpriteRenderer sr;

    private void Start()
    {
        if (GetComponent<SpriteRenderer>())
            sr = GetComponent<SpriteRenderer>();
    }

    //destroys the object this class is attached to
    void breakMe()
    {
        if (sr != null)
        {
            sr.enabled = false;
            Destroy(gameObject, .6f);
        }
        else
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //If the wall is rock and is attacked by a rock dude, destroy it
        
        if(thiswallis == walltyp.ROCK &&
           collider.gameObject.GetComponent<Rock_Enemy>() &&           
           collider.gameObject.GetComponent<BaseController>().playerState == BaseController.PlayerState.ATTACK)
        {
            breakMe();
        }

        //if the wall is wood and is hit by a fireball destroy it
        if(thiswallis == walltyp.WOOD &&
           collider.gameObject.tag == "FireBall")
           //collider.gameObject.GetComponent<ShotScript>())
           
        {
            breakMe();
        }
    }    
}
