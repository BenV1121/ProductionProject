using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;

    BaseController myControl;
    GameOverManager gom;

	// Use this for initialization
	void Start ()
    {
        myControl = player.GetComponent<BaseController>();
        gom = GetComponent<GameOverManager>();

        enemy.AddComponent<EnemyScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        //If I'm player
        if (other.gameObject.tag == "Player")
        {
            if (enemy.GetComponent<Rock_Enemy>() && myControl.playerClass == player.GetComponent<ClassFire>())
            {
                Destroy(myControl.playerClass);
                myControl.playerClass = player.AddComponent<ClassMirror>();
            }
            if (enemy.GetComponent<ClassFire>() || enemy.GetComponent<FireProjectileScript>() && myControl.playerClass == player.gameObject.GetComponent<ClassTako>())
            {
                Destroy(myControl.playerClass);
                myControl.playerClass = player.AddComponent<ClassMirror>();
            }
            if (enemy.GetComponent<ClassTako>() && myControl.playerClass == player.GetComponent<Rock_Enemy>())
            {
                Destroy(myControl.playerClass);
                myControl.playerClass = player.AddComponent<ClassMirror>();
            }

            if (enemy.GetComponent<Rock_Enemy>() || enemy.GetComponent<ClassFire>() || enemy.GetComponent<FireProjectileScript>() || enemy.GetComponent<ClassTako>() && myControl.playerClass == player.GetComponent<ClassMirror>())
            {
                myControl.isDead = true;
                Debug.Log("yeah");
            }
        }
    }
}
