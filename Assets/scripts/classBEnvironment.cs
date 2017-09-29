using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class classBEnvironment : MonoBehaviour {

    
    void breakMe()
    {
        Destroy(gameObject);   
    }

    void onCollisionEnter(Collision collider)
    {
        //New ClassBase() is a place holder, replace it with the Rock man class that aaron is working on.
        if(collider.gameObject.GetComponent<BaseController>().playerClass == new ClassBase() &&
           collider.gameObject.GetComponent<BaseController>().playerState == BaseController.PlayerState.ATTACK)
        {
            breakMe();
        }
    }
}
