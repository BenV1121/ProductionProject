using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    BaseController myControl;
    //BaseController otherControl;


	// Use this for initialization
	void Start ()
    {
        myControl = GetComponent<BaseController>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        //If I'm player
        if (myControl.isEnemyAI == false)
        {
            if (gameObject.GetComponent<Rock_Enemy>() && other.gameObject.GetComponent<ClassFire>())
            {
                Destroy(myControl.playerClass);
                myControl.playerClass = gameObject.AddComponent<ClassMirror>();
            }
            if (gameObject.GetComponent<ClassFire>() || gameObject.GetComponent<FireProjectileScript>() && other.gameObject.GetComponent<ClassTako>())
            {
                Destroy(myControl.playerClass);
                myControl.playerClass = gameObject.AddComponent<ClassMirror>();
            }
            if (gameObject.GetComponent<ClassTako>() && other.gameObject.GetComponent<Rock_Enemy>())
            {
                Destroy(myControl.playerClass);
                myControl.playerClass = gameObject.AddComponent<ClassMirror>();
            }

            //if (gameObject.GetComponent<Rock_Enemy>() || gameObject.GetComponent<ClassFire>() || gameObject.GetComponent<ClassTako>() && other.gameObject.GetComponent<ClassMirror>())
            //{
                 
            //}
        }
    }
}
