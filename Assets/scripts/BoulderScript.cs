using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Yo!");
	    	if(col.gameObject.GetComponent<BaseController>())
        {
            Destroy(col.gameObject);
            Debug.Log("Fuck this dude!");
        }
	}
}
