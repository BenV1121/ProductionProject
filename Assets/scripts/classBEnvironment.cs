using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class classBEnvironment : MonoBehaviour {

    //im using this to indicate wether a wall is wood or rock
    public enum walltyp { ROCK, WOOD};
    public walltyp thiswallis;

    //destroys the object this class is attached to
    void breakMe()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //If the wall is rock and is attacked by a rock dude, destroy it
        //New ClassBase() is a place holder, replace it with the Rock man class that aaron is working on.
        if(thiswallis == walltyp.ROCK &&
           collider.gameObject.GetComponent<BaseController>().playerClass == new ClassBase() &&
           collider.gameObject.GetComponent<BaseController>().playerState == BaseController.PlayerState.ATTACK)
        {
            breakMe();
        }

        //if the wall is wood and is hit by a fireball destroy it
        if(thiswallis == walltyp.WOOD &&
           collider.gameObject.tag == "FireBall")
        {
            breakMe();
        }
    }
}
